using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clusterizer.Properties;

namespace Clusterizer
{
    /// <summary>
    /// The application's Main Form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        #region Fields        
        /// <summary>
        /// The data points before normalization
        /// </summary>
        private List<DataPoint> _dataPointsBeforeNormalization;

        /// <summary>
        /// The statistics form
        /// </summary>
        private StatisticsForm statisticsForm;
        #endregion


        #region Constructor       
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ResetComponents();
            ResetData();
        }

        #endregion


        #region Methods            
        /// <summary>
        /// Resets the components.
        /// </summary>
        private void ResetComponents()
        {
            // deletes temporary files
            DeleteTempFiles();

            // resets all UI components
            dataTableGridView.DataSource = null;

            filteredColumnSelectComboBox.Items.Clear();
            filteredColumnSelectComboBox.SelectedItem = null;
            sortColumnSelectComboBox.Items.Clear();
            sortColumnSelectComboBox.SelectedItem = null;
            operandSelectComboBox.Items.Clear();

            clusterTreeView.Nodes.Clear();
            clusterTableGridView.Rows.Clear();
            clusteringToolStrip.Enabled = false;
            searchExpressionTextBox.Text = "";

            // Disables using clustering
            DisableClustering();
        }

        /// <summary>
        /// Resets the data.
        /// </summary>
        private void ResetData()
        {
            Tools.Data = null;
            Tools.Clusters = null;
            Tools.isChosen = null;
        }

        /// <summary>
        /// Restores the cluster set before normalization.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        private void RestoreClusterSet(Cluster cluster)
        {
            for (var i = 0; i < cluster.DataPoints.Count; i++)
                cluster.DataPoints[i] = _dataPointsBeforeNormalization[cluster.DataPoints[i].Id];

            foreach (var subCluster in cluster.SubClusters)
                RestoreClusterSet(subCluster);

            cluster.SetCentroid();
        }

        /// <summary>
        /// Deletes the temporary files.
        /// </summary>
        public void DeleteTempFiles()
        {
            if (File.Exists("tmpOverview.csv"))
                File.Delete("tmpOverview.csv");
            if (File.Exists("tmpTable.csv"))
                File.Delete("tmpTable.csv");
            if (File.Exists("tmpDendogramm.png"))
                File.Delete("tmpDendogramm.png");
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            // resets components
            ResetComponents();

            // loads data table
            dataTableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataTableGridView.ColumnHeadersVisible = false;
            dataTableGridView.DataSource = Tools.Data.DataSetTable;
            dataTableGridView.ColumnHeadersVisible = true;
            dataTableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataTableGridView.Refresh();

            // load filter and sort fields
            filteredColumnSelectComboBox.Items.AddRange(Tools.Data.StringHeadings);
            filteredColumnSelectComboBox.Items.AddRange(Tools.Data.NumericHeadings);
            sortColumnSelectComboBox.Items.AddRange(Tools.Data.StringHeadings);

            filteredColumnSelectComboBox.SelectedIndex = 0;
            sortColumnSelectComboBox.SelectedIndex = 0;

            // enables clustering
            EnableClustering();
        }

        /// <summary>
        /// Builds the result table.
        /// </summary>
        private void BuildResultTable()
        {
            // resets result table
            clusterTableGridView.Rows.Clear();
            clusterTableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            clusterTableGridView.ColumnHeadersVisible = false;

            // saves table to temp file
            using (var fileStream = new FileStream("tmpTable.csv", FileMode.Create))
            {
                var streamWriter = new StreamWriter(fileStream);
                // gets table from clusters
                for (var i = 0; i < Tools.Clusters.ClustersList.Count; i++)
                {
                    var baseId = Tools.Clusters.GetCluster(i).Id;
                    foreach (var pattern in Tools.Clusters.GetCluster(i).DataPoints)
                    {
                        clusterTableGridView.Rows.Add(Tools.Data.Rows[pattern.Id].Fields[0], $"Cluster{pattern.Id}",
                            $"Cluster{baseId}");
                        streamWriter.WriteLine(
                            $"{Tools.Data.Rows[pattern.Id].Fields[0]};Cluster{pattern.Id};Cluster{baseId}");
                    }
                }

                streamWriter.Flush();
            }

            // load data to table
            clusterTableGridView.ColumnHeadersVisible = true;
            clusterTableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            clusterTableGridView.Refresh();
            exportClusterTableToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Builds the TreeView.
        /// </summary>
        private void BuildTreeView()
        {
            clusterTreeView.Nodes.Clear();
            foreach (var cluster in Tools.Clusters.ClustersList)
            {
                var rootNode = clusterTreeView.Nodes.Add($"Cluster{cluster.Id}");
                AddNodes(cluster.SubClusters.ToArray(), rootNode);
            }

            clusterTreeView.CollapseAll();
        }

        /// <summary>
        /// Adds the nodes to node
        /// </summary>
        /// <param name="clusters">The clusters.</param>
        /// <param name="node">The node.</param>
        private void AddNodes(Cluster[] clusters, TreeNode node)
        {
            foreach (var cluster in clusters)
            {
                var childNode = node.Nodes.Add($"Cluster{cluster.Id}");
                if (cluster.QuantityOfSubClusters > 0)
                    AddNodes(cluster.SubClusters.ToArray(), childNode);
            }
        }

        /// <summary>
        /// Disables the clustering.
        /// </summary>
        private void DisableClustering()
        {
            tabControl.TabPages[1].Enabled = false;
            clusterizationToolStripMenuItem.Enabled = false;
            buildDendrogramToolStripMenuItem.Enabled = false;
            showClusterOverviewToolStripMenuItem.Enabled = false;
            exportToolStripMenuItem.Enabled = false;
            exportClusterDendogrammToolStripMenuItem.Enabled = false;
            exportClusterOverviewToolStripMenuItem.Enabled = false;
            exportClusterTableToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Enables the clustering.
        /// </summary>
        private void EnableClustering()
        {
            tabControl.TabPages[1].Enabled = true;
            clusterizationToolStripMenuItem.Enabled = true;
            clusteringToolStrip.Enabled = true;
        }

        #endregion

        #region Events

        #region Menu - File
        /// <summary>
        /// Handles the Click event of the openToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Clusterizer.CustomException">Проверьте корректность данных и доступность файла. - Ошибка при открытии входных данных</exception>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog {Title = "Открыть файл", Filter = "CSV File(*.csv)|*.csv"};
                // check if user clicked ok
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    var data = new CSVData(filePath);
                    data.CreateDataTable();
                    Tools.Data = data;
                    LoadData();
                }
            }
            catch
            {
                throw new CustomException("Проверьте корректность данных и доступность файла.", "Ошибка при открытии входных данных");
            }
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Clusterizer.CustomException">Произошла ошибка при сохранении файла. - Ошибка сохранения файла</exception>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Tools.Data != null)
                {
                    // updates data
                    Tools.Data.UpdateRows();
                    // saves data
                    CSVData.SaveToCsv(Tools.Data, Tools.Data.FilePath);
                }
            }
            catch
            {
                throw new CustomException("Произошла ошибка при сохранении файла.", "Ошибка сохранения файла");
            }
        }

        /// <summary>
        /// Handles the Click event of the saveAsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Clusterizer.CustomException">Произошла ошибка при сохранении файла. - Ошибка сохранения файла</exception>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog = new SaveFileDialog {Title = "Сохранить как...", Filter = "CSV File(*.csv)|*.csv"};
                // check if user selected ok
                if (Tools.Data != null && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = saveFileDialog.FileName;
                    // updates data
                    Tools.Data.UpdateRows();
                    // saves data
                    CSVData.SaveToCsv(Tools.Data, filePath);
                }
            }
            catch
            {
                throw new CustomException("Произошла ошибка при сохранении файла.", "Ошибка сохранения файла");
            }
        }

        /// <summary>
        /// Handles the Click event of the closeToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetData();
            ResetComponents();
        }



        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the exportClusterDendogrammToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exportClusterDendogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog {Title = "Сохранить как...", Filter = "PNG File(*.png)|*.png"};
            if (saveFileDialog.ShowDialog() == DialogResult.OK) File.Move("tmpDendogramm.png", saveFileDialog.FileName);
        }

        /// <summary>
        /// Handles the Click event of the exportClusterTableToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exportClusterTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog {Title = "Сохранить как...", Filter = "CSV File(*.csv)|*.csv"};
            if (saveFileDialog.ShowDialog() == DialogResult.OK) File.Move("tmpTable.csv", saveFileDialog.FileName);
        }

        /// <summary>
        /// Handles the Click event of the exportClusterOverviewToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exportClusterOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog {Title = "Сохранить как...", Filter = "CSV File(*.csv)|*.csv"};
            if (saveFileDialog.ShowDialog() == DialogResult.OK) File.Move("tmpOverview.csv", saveFileDialog.FileName);
        }

        #endregion

        #region Menu - Clusterization        
        /// <summary>
        /// Handles the Click event of the clusterizeToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clusterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // shows form
            var clusterizeForm = new ClusterizeForm();
            clusterizeForm.ShowDialog();

            if (Tools.Data != null && clusterizeForm.isParametersSelected)
            {
                // updates data
                Tools.Data.UpdateRows();

                // get clusterset
                var clusters = Tools.Data.GetClusterSet(Tools.isChosen);
                Tools.Clusters = clusters;

                // backups clusters before normalization
                _dataPointsBeforeNormalization = new List<DataPoint>();
                for (var i = 0; i < clusters.ClustersList.Count; i++)
                {
                    _dataPointsBeforeNormalization.Add(
                        new DataPoint(new List<double>(clusters[i].DataPoints[0].Points)));
                    _dataPointsBeforeNormalization[i].Id = i;
                }

                // normalize clusters
                clusters.Normalize(clusterizeForm.normalizeMethod);
                var agnes = new Agnes(clusters,
                    clusterizeForm.distanceMetric, clusterizeForm.strategy);

                // execute clustering
                Tools.Clusters = agnes.ExecuteClustering(clusterizeForm.countOfClusters);

                // builds components
                BuildTreeView();
                BuildResultTable();
                tabControl.SelectTab(1);

                // enables functions
                buildDendrogramToolStripMenuItem.Enabled = true;
                showClusterOverviewToolStripMenuItem.Enabled = true;
                exportToolStripMenuItem.Enabled = true;

                Task.Factory.StartNew(() =>
                {
                    // shows form
                    statisticsForm = new StatisticsForm
                    {
                        contentsHeadings = Tools.Data.GetChosenDataPointNames(Tools.isChosen),
                        Clusters = new ClusterSet
                        {
                            ClustersList = Tools.Clusters.ClustersList.GetRange(0, Tools.Clusters.Count)
                        }
                    };

                    // setup form
                    statisticsForm.Clusters.ClustersList.ForEach(RestoreClusterSet);
                    statisticsForm.Setup();

                });
            }
        }


        /// <summary>
        /// Handles the Click event of the buildDendrogramToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buildDendrogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tools.Clusters != null)
            {
                // show form
                var dendrogramFrm = new DendrogramForm();

                // setup form
                //dendrogramFrm._clusters = Tools.Clusters;
                dendrogramFrm.Setup();
                dendrogramFrm.ShowDialog();
                exportClusterDendogrammToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the showClusterOverviewToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void showClusterOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Tools.Clusters != null)
            {
                statisticsForm.ShowDialog();
                exportClusterOverviewToolStripMenuItem.Enabled = true;
            }
        }
        #endregion

        #region Menu - About        
        /// <summary>
        /// Handles the Click event of the aboutToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }


        #endregion

        #region DataTableGridView

        /// <summary>
        /// Handles the DataError event of the dataTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewDataErrorEventArgs"/> instance containing the event data.</param>
        private void dataTableGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
            throw new CustomException("Введено не корректное значение.", "Ошибка при редактировании таблицы");
        }

        /// <summary>
        /// Handles the DefaultValuesNeeded event of the dataTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowEventArgs"/> instance containing the event data.</param>
        private void dataTableGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int i;
            for (i = 0; i < Tools.Data.StringHeadings.Length; i++)
                e.Row.Cells[i].Value = "Text";
            for (; i < Tools.Data.FieldsCount; i++)
                e.Row.Cells[i].Value = 0.0;
        }

        /// <summary>
        /// Handles the RowPostPaint event of the dataTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPostPaintEventArgs"/> instance containing the event data.</param>
        private void dataTableGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // add indexes of rows
            using (var b = new SolidBrush(dataTableGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Handles the DataSourceChanged event of the dataTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dataTableGridView_DataSourceChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < dataTableGridView.ColumnCount; i++) dataTableGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        #endregion

        #region ClusterTableGridView        
        /// <summary>
        /// Handles the DataSourceChanged event of the clusterTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clusterTableGridView_DataSourceChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < clusterTableGridView.ColumnCount; i++) clusterTableGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        /// <summary>
        /// Handles the RowPostPaint event of the clusterTableGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPostPaintEventArgs"/> instance containing the event data.</param>
        private void clusterTableGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (var b = new SolidBrush(clusterTableGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b,
                    e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        #endregion

        #region ToolStrip        
        /// <summary>
        /// Handles the Click event of the filterButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            if (Tools.Data != null)
                Tools.Data.Filter(filterExpressionTextBox.Text, filteredColumnSelectComboBox.SelectedIndex,
                    operandSelectComboBox.SelectedIndex);
        }

        /// <summary>
        /// Handles the Click event of the sortByAZButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sortByAZButton_Click(object sender, EventArgs e)
        {
            if (Tools.Data != null)
                Tools.Data.Sort(sortColumnSelectComboBox.SelectedIndex, true);
        }

        /// <summary>
        /// Handles the Click event of the sortByZAButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sortByZAButton_Click(object sender, EventArgs e)
        {
            if (Tools.Data != null)
                Tools.Data.Sort(sortColumnSelectComboBox.SelectedIndex, false);
        }

        /// <summary>
        /// Handles the Click event of the undoButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void undoButton_Click(object sender, EventArgs e)
        {
            if (Tools.Data != null)
                Tools.Data.Undo();
        }

        /// <summary>
        /// Handles the Click event of the redoButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void redoButton_Click(object sender, EventArgs e)
        {
            if (Tools.Data != null)
                Tools.Data.Redo();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the filteredColumnSelectComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>

        private void filteredColumnSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ((ToolStripComboBox)sender).SelectedIndex;
            if (selectedIndex >= Tools.StringDataHeadings.Length && Tools.Data != null)
            {
                operandSelectComboBox.Items.Clear();
                operandSelectComboBox.Items.Add("=");
                operandSelectComboBox.Items.Add(">=");
                operandSelectComboBox.Items.Add("<=");
                operandSelectComboBox.Items.Add(">");
                operandSelectComboBox.Items.Add("<");
                operandSelectComboBox.SelectedIndex = 0;
            }
            else if (selectedIndex < Tools.StringDataHeadings.Length && Tools.Data != null)
            {
                operandSelectComboBox.Items.Clear();
                operandSelectComboBox.Items.Add("=");
                operandSelectComboBox.SelectedIndex = 0;
            }
        }


        #endregion

        #region ClusteringToolStrip        
        /// <summary>
        /// Handles the Click event of the searchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            foreach (var row in clusterTableGridView.Rows.Cast<DataGridViewRow>())
            {
                row.Cells[0].Style.BackColor = Color.AliceBlue;
                if (((string)row.Cells[0].Value).Contains(searchExpressionTextBox.Text))
                    row.Cells[0].Style.BackColor = Color.Aqua;
            }
        }

        #endregion

        #region MainForm        
        /// <summary>
        /// Handles the FormClosing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteTempFiles();
        }
        #endregion

        #endregion


    }
}