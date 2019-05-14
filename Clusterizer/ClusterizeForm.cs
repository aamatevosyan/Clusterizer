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
    /// Класс выбора опции кластеризации
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ClusterizeForm : Form
    {
        #region Поля        

        /// <summary>
        /// Массив выборов
        /// </summary>
        internal bool[] isChosen;

        /// <summary>
        /// Стратегия обьеденения
        /// </summary>
        internal ClusterDistance.Strategy strategy;

        /// <summary>
        /// Мера расстояния
        /// </summary>
        internal Distance.DistanceMetric distanceMetric;

        /// <summary>
        /// Заголовки показателей
        /// </summary>
        internal string[] pointsNames;

        internal CSVData _data;
        internal int k = 1;

        #endregion

        #region Конструктор        

        /// <summary>
        /// Конструктор без параметров класса <see cref="ClusterizeForm"/>.
        /// </summary>
        public ClusterizeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор без параметров класса <see cref="ClusterizeForm"/>.
        /// </summary>
        /// <param name="points">Заголовки точек</param>
        public ClusterizeForm(string[] points)
        {
            InitializeComponent();
            pointsNames = points;
            treeView1.CheckBoxes = true;
            for (int i = 0; i < Tools.GroupCount; i++)
            {
                TreeNode rootNode = new TreeNode(Tools.GroupNames[i]);
                rootNode.Checked = true;
                for (int j = 0; j < Tools.GroupItemsNames[i].Length; j++)
                {
                    TreeNode node = new TreeNode(Tools.GroupItemsNames[i][j]);
                    rootNode.Nodes.Add(node);
                    node.Checked = true;
                }

                treeView1.Nodes.Add(rootNode);
            }

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        #endregion

        /// <summary>
        /// Действие при нажатии на кнопку clusteringButton
        /// </summary>      
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void clusteringButton_Click(object sender, EventArgs e)
        {
            distanceMetric = (Distance.DistanceMetric) comboBox1.SelectedIndex;
            strategy = (ClusterDistance.Strategy) comboBox2.SelectedIndex;

            int tmp;
            if (int.TryParse(textBox1.Text, out tmp) && tmp > 0 && tmp < _data.Rows.Count)
            {
                k = tmp;
            }
            else
            {
                MessageBox.Show("Ощибка при вводе", "Введите правилное количество кластеров", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isChosen = new bool[Tools.DataPointCount];
            int ind = 0;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    isChosen[ind] = treeView1.Nodes[i].Nodes[j].Checked;
                    ind++;
                }
            }

            this.Close();
        }

        bool busy = false;

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            finally
            {
                busy = false;
            }
        }

        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // undefined if only one cluster
            double maxCoeff = double.MinValue;
            int maxIndex = 0;
            double currentCoeff = 0;

            distanceMetric = (Distance.DistanceMetric)comboBox1.SelectedIndex;
            strategy = (ClusterDistance.Strategy)comboBox2.SelectedIndex;

            isChosen = new bool[Tools.DataPointCount];
            int ind = 0;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                {
                    isChosen[ind] = treeView1.Nodes[i].Nodes[j].Checked;
                    ind++;
                }
            }

            Agnes agnes = new Agnes(_data.GetPatternMatrix(isChosen),
                distanceMetric, strategy);
            var _clusters = agnes.ExecuteClustering(1, true);


            k = agnes.GetMaximumIndex();
            textBox1.Text = $"{k}";
            int a = 5;
            //Agnes agnes = new Agnes(_data.GetPatternMatrix(clusterizeForm.isChosen),
            //    clusterizeForm.distanceMetric, clusterizeForm.strategy);
            //_clusters = agnes.ExecuteClustering(1);

            //if (clusterSet.Count < 2) return double.NaN;

            //// gets clusters' centroids and overall centroid
            //var centroids = new List<TInstance>();
            //Cluster<TInstance> allPoints = null;
            //for (var i = 0; i < clusterSet.Count; i++)
            //{
            //    allPoints = allPoints == null
            //        ? new Cluster<TInstance>(clusterSet[i])
            //        : new Cluster<TInstance>(allPoints, clusterSet[i], 0);
            //    centroids.Add(this._centroidFunc(clusterSet[i]));
            //}

            //var overallCentroid = this._centroidFunc(allPoints);

            //var betweenVar = 0d;
            //var withinVar = 0d;
            //for (var i = 0; i < clusterSet.Count; i++)
            //{
            //    // updates overall between-cluster variance
            //    var betweenDist = this.DissimilarityMetric.Calculate(centroids[i], overallCentroid);
            //    betweenVar += betweenDist * betweenDist * clusterSet[i].Count;

            //    // updates overall within-cluster variance
            //    foreach (var instance in clusterSet[i])
            //    {
            //        var withinDist = this.DissimilarityMetric.Calculate(instance, centroids[i]);
            //        withinVar += withinDist * withinDist;
            //    }
            //}

            //return Math.Abs(withinVar) < double.Epsilon
            //    ? double.NaN
            //    : betweenVar * (allPoints.Count - clusterSet.Count) / (withinVar * (clusterSet.Count - 1));
        }

        static IList<double> FindPeaks(IList<double> values, int rangeOfPeaks)
        {
            List<double> peaks = new List<double>();

            int checksOnEachSide = rangeOfPeaks / 2;
            for (int i = 0; i < values.Count; i++)
            {
                double current = values[i];
                IEnumerable<double> range = values;
                if (i > checksOnEachSide)
                    range = range.Skip(i - checksOnEachSide);
                range = range.Take(rangeOfPeaks);
                if (current == range.Max())
                    peaks.Add(current);
            }
            return peaks;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
