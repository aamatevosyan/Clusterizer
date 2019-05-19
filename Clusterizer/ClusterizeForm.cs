using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{
    /// <summary>
    /// Form for selecting parameters of clustering
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ClusterizeForm : Form
    {
        #region Fields       

        /// <summary>
        /// The merge strategy
        /// </summary>
        internal MergeStrategy strategy;

        /// <summary>
        /// The distance metric
        /// </summary>
        internal DistanceMetric distanceMetric;

        /// <summary>
        /// The normalize method
        /// </summary>
        internal NormalizeMethod normalizeMethod;

        /// <summary>
        /// The count of clusters
        /// </summary>
        internal int countOfClusters = 1;

        /// <summary>
        /// Indicates if parameters selected
        /// </summary>
        internal bool isParametersSelected;

        /// <summary>
        /// Indicates if TreeView busy
        /// </summary>
        private bool _isTreeViewBusy;

        #endregion

        #region Конструктор        

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterizeForm"/> class.
        /// </summary>
        public ClusterizeForm()
        {
            InitializeComponent();

            isParametersSelected = false;
            pointsSelectTreeView.CheckBoxes = true;

            // Loads Parameters from defined configuration
            for (int i = 0; i < Tools.GroupNames.Length; i++)
            {
                TreeNode rootNode = new TreeNode(Tools.GroupNames[i]) {Checked = true};
                for (int j = 0; j < Tools.GroupItemsNames[i].Length; j++)
                {
                    TreeNode node = new TreeNode(Tools.GroupItemsNames[i][j]);
                    rootNode.Nodes.Add(node);
                    node.Checked = true;
                }

                pointsSelectTreeView.Nodes.Add(rootNode);
            }

            distanceSelectComboBox.SelectedIndex = 0;
            strategySelectComboBox.SelectedIndex = 0;
            normalizeMethodSelectComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Events        
        /// <summary>
        /// Handles the Click event of the doClusteringButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Clusterizer.CustomException">
        /// Введите правилное количество кластеров. - Ошибка при вводе числа кластеров
        /// or
        /// Не было выбрано не одного показателя. - Ощибка при выборе показателей
        /// </exception>
        private void doClusteringButton_Click(object sender, EventArgs e)
        {
            // Gets selected parameters of clustering
            distanceMetric = (DistanceMetric) distanceSelectComboBox.SelectedIndex;
            strategy = (MergeStrategy) strategySelectComboBox.SelectedIndex;
            normalizeMethod = (NormalizeMethod) normalizeMethodSelectComboBox.SelectedIndex;

            // checks for correct cluster number
            if (int.TryParse(clusterCountTextBox.Text, out var tmp) && tmp > 0 && tmp < Tools.Data.Rows.Count)
                countOfClusters = tmp;
            else
                throw new CustomException("Введите правилное количество кластеров.", "Ошибка при вводе числа кластеров");

            // gets selected datapoints
            var isChosen = new bool[Tools.NumericDataHeadings.Length];
            bool isAllFalse = true;
            int ind = 0;
            for (int i = 0; i < pointsSelectTreeView.Nodes.Count; i++)
            {
                for (int j = 0; j < pointsSelectTreeView.Nodes[i].Nodes.Count; j++)
                {
                    isChosen[ind] = pointsSelectTreeView.Nodes[i].Nodes[j].Checked;
                    if (isAllFalse)
                        isAllFalse = !isChosen[ind];
                    ind++;
                }
            }

            // check if no datapoint is selected
            if (isAllFalse)
                throw new CustomException("Не было выбрано не одного показателя.", "Ощибка при выборе показателей");

            Tools.isChosen = isChosen;
            isParametersSelected = true;
            Close();
        }

        /// <summary>
        /// Handles the Click event of the calculateClusterCountButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Clusterizer.CustomException">Не было выбрано ни одного показателя. - Ощибка при выборе показателей</exception>
        private void calculateClusterCountButton_Click(object sender, EventArgs e)
        {
            // gets selected parameters of clustering
            distanceMetric = (DistanceMetric)distanceSelectComboBox.SelectedIndex;
            strategy = (MergeStrategy)strategySelectComboBox.SelectedIndex;
            normalizeMethod = (NormalizeMethod)normalizeMethodSelectComboBox.SelectedIndex;

            // gets selected datapoints
            var isChosen = new bool[Tools.NumericDataHeadings.Length];
            bool isAllFalse = true;
            int ind = 0;
            for (int i = 0; i < pointsSelectTreeView.Nodes.Count; i++)
            {
                for (int j = 0; j < pointsSelectTreeView.Nodes[i].Nodes.Count; j++)
                {
                    isChosen[ind] = pointsSelectTreeView.Nodes[i].Nodes[j].Checked;
                    if (isAllFalse)
                        isAllFalse = !isChosen[ind];
                    ind++;
                }
            }

            // check if no datapoint is selected
            if (isAllFalse)
                throw new CustomException("Не было выбрано ни одного показателя.", "Ощибка при выборе показателей");


            // gets cluster set from data
            var clusters = Tools.Data.GetClusterSet(Tools.isChosen);
            clusters.Normalize(normalizeMethod);

            // executes clustering for determining recomended count of clusters
            Agnes agnes = new Agnes(clusters,
                distanceMetric, strategy);
            agnes.ExecuteClustering(2, true);

            // gets recomended count of clusters
            countOfClusters = agnes.GetRecommendedCountOfClusters();
            clusterCountTextBox.Text = $"{countOfClusters}";
        }

        /// <summary>
        /// Handles the AfterCheck event of the pointsSelectTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeViewEventArgs"/> instance containing the event data.</param>
        private void pointsSelectTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (_isTreeViewBusy) return;
            _isTreeViewBusy = true;
            try
            {
                CheckNodes(e.Node, e.Node.Checked);
            }
            finally
            {
                _isTreeViewBusy = false;
            }
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Checks the nodes.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="check">if set to <c>true</c> [check].</param>
        private void CheckNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                CheckNodes(child, check);
            }
        }
        #endregion
    }
}
