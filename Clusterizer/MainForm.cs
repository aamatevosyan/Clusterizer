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
    /// Класс основной формы программы
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        #region Поля        
        /// <summary>
        /// Данные
        /// </summary>
        private CSVData _data;
        /// <summary>
        /// Кластеры
        /// </summary>
        private Clusters _clusters;

        private bool[] isChosen;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ResetComponents();
            Settings.Default.Save();
            Settings.Default.Upgrade();
        }
        #endregion


        #region Методы        
        /// <summary>
        /// Сбрасывает компоненты
        /// </summary>
        public void ResetComponents()
        {
            dataGridView.DataSource = null;
            filterToolStripComboBox.Items.Clear();
            filterToolStripComboBox.SelectedItem = null;
            sortToolStripComboBox.ComboBox.Items.Clear();
            sortToolStripComboBox.SelectedItem = null;
            //listBox1.Items.Clear();
            treeView.Nodes.Clear();
            DisableClustering();
        }

        /// <summary>
        /// Сбрасывает данные
        /// </summary>
        public void ResetData()
        {
            _data = null;
            _clusters = null;
        }

        /// <summary>
        /// Зогружает данные
        /// </summary>
        public void LoadData()
        {
            ResetComponents();

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.DataSource = _data.DataSetTable;
            dataGridView.ColumnHeadersVisible = true;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.Refresh();

            filterToolStripComboBox.Items.AddRange(_data.StringHeadings);
            sortToolStripComboBox.Items.AddRange(_data.StringHeadings);

            filterToolStripComboBox.SelectedIndex = 0;
            sortToolStripComboBox.SelectedIndex = 0;

            EnableClustering();
        }

        /// <summary>
        /// Обновляет изминения
        /// </summary>
        public void UpdateChanges()
        {
            _data.UpdateRows();
        }

        /// <summary>
        /// Заполняет ListBox
        /// </summary>
        private void FillListBox()
        {
            resultGridView.Rows.Clear();
            resultGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            resultGridView.ColumnHeadersVisible = false;
            for (int i = 0; i < _clusters._clusters.Count; i++)
            {
                int baseId = _clusters.GetCluster(i).Id;
                foreach (var pattern in _clusters.GetCluster(i)._patternList)
                {
                    resultGridView.Rows.Add(_data.Rows[pattern.Id].Fields[0], $"Cluster{pattern.Id}",
                        $"Cluster{baseId}");
                }
            }


            //dataGridView.DataSource = _data.DataSetTable;
            resultGridView.ColumnHeadersVisible = true;
            resultGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            resultGridView.Refresh();
            //listBox1.Items.Clear();
            //for (int i = 0; i < _data.Rows.Count; i++)
            //    listBox1.Items.Add($"Cluster{i} : \"{_data.Rows[i].Fields[0]}\"");
        }

        /// <summary>
        /// Строит TreeView.
        /// </summary>
        private void BuildTreeView()
        {
            treeView.Nodes.Clear();
            foreach (var cluster in _clusters._clusters)
            {
                TreeNode rootNode = treeView.Nodes.Add($"Cluster{cluster.Id}");
                this.AddNodes(cluster.GetSubClusters(), rootNode);
            }
            
            treeView.ExpandAll();
        }

        /// <summary>
        /// Добавляет деревья
        /// </summary>
        /// <param name="clusters">Кластеры</param>
        /// <param name="node">Дерево</param>
        private void AddNodes(Cluster[] clusters, TreeNode node)
        {
            TreeNode childNode;
            foreach (var cluster in clusters)
            {
                childNode = node.Nodes.Add($"Cluster{cluster.Id}");
                if (cluster.QuantityOfSubClusters > 0)
                    this.AddNodes(cluster.GetSubClusters(), childNode);
            }
        }

        /// <summary>
        /// Отключает кластеризацию
        /// </summary>
        private void DisableClustering()
        {
            tabControl.TabPages[1].Enabled = false;
            clusterizationToolStripMenuItem.Enabled = false;
            buildDendrogramToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Включает кластеризацию
        /// </summary>
        private void EnableClustering()
        {
            tabControl.TabPages[1].Enabled = true;
            clusterizationToolStripMenuItem.Enabled = true;
        }
        #endregion

        #region События
        /// <summary>
        /// Действие при нажатии на кнопку openToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenForm openForm = new OpenForm();
            //openForm.ShowDialog();
            //_data = openForm.data;
            //if (_data != null)
            //    LoadData();
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Открыть файл";
                openFileDialog.Filter = "CSV File(*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    //filePathtextBox.Text = filePath;
                    //var task = Task.Run(() =>
                    //{
                    //    _data = CSVData.ReadFromCSV(filePath);
                    //});
                    //task.Wait();
                    _data = CSVData.ReadFromCSV(filePath);
                    _data.SetPointsHeadings();
                    _data.SetNamedHeadings();
                    _data.CreateDataTable();
                    LoadData();
                }

            }
            catch
            {
                MessageBox.Show("Произошла ошибка при имспорте файла. Проверьте корректность файла.", "Ошибка импорта.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при заполнении значении по умолчанию в dataGridView
        /// </summary>
        /// <param name="sender">dataGridView</param>
        /// <param name="e">Аргумент события <see cref="DataGridViewDataErrorEventArgs"/></param>
        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            for (int i = 0; i < _data.IsRealValue.Length; i++)
                if (_data.IsRealValue[i])
                    e.Row.Cells[i].Value = 0.0;
                else
                    e.Row.Cells[i].Value = "Строка";
        }

        /// <summary>
        /// Действие при ошыбке ввода значении в dataGridView
        /// </summary>
        /// <param name="sender">dataGridView</param>
        /// <param name="e">Аргумент события <see cref="DataGridViewDataErrorEventArgs"/></param>
        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введено не корректное значение.", "Ошибка при редактировании таблицы.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
            e.Cancel = false;
        }

        /// <summary>
        /// Действие при нажатии на кнопку sortToolStripButton
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void sortToolStripButton_Click(object sender, EventArgs e)
        {
            if (_data != null)
                _data.Sort(sortToolStripComboBox.SelectedIndex);
        }

        /// <summary>
        /// Действие при нажатии на кнопку filterStripButton
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void filterStripButton_Click(object sender, EventArgs e)
        {
            if (_data != null)
                _data.Filter(filterToolStripTextBox.Text, filterToolStripComboBox.SelectedIndex);
        }

        /// <summary>
        /// Действие при нажатии на кнопку undoToolStripButton
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            if (_data != null)
                _data.RestoreRows();
        }

        /// <summary>
        /// Действие при нажатии на кнопку clusterizeToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void clusterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ClusterizeForm clusterizeForm = new ClusterizeForm(_data.NumericHeadings);
            clusterizeForm._data = _data;
            clusterizeForm.ShowDialog();

            if (_data != null && clusterizeForm.isChosen != null)
            {
                Agnes agnes = new Agnes(_data.GetPatternMatrix(clusterizeForm.isChosen),
                    clusterizeForm.distanceMetric, clusterizeForm.strategy);
                isChosen = clusterizeForm.isChosen;
                _clusters = agnes.ExecuteClustering(clusterizeForm.k);



                this.BuildTreeView();
                this.FillListBox();
                tabControl.SelectTab(1);
                buildDendrogramToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Для кластеризации сначала откройте данные.", "Некорректные данные");
            }
        }



        /// <summary>
        /// Действие при нажатии на кнопку buildDendrogramToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void buildDendrogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_clusters != null)
            {
                DendrogramForm dendrogramFrm = new DendrogramForm();
                dendrogramFrm._clusters = _clusters;
                dendrogramFrm.Setup();
                dendrogramFrm.ShowDialog();
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку importToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Импорт файла";
                openFileDialog.Filter = "CSF File(*.csf)|*.csf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                    {
                        CSFContainer container = (CSFContainer)binaryFormatter.Deserialize(fileStream);
                        _data = container.Data;
                        _data.FilePath = Path.ChangeExtension(filePath, ".csv");
                        _clusters = container.Clusters;
                        LoadData();
                        this.BuildTreeView();
                        this.FillListBox();
                        buildDendrogramToolStripMenuItem.Enabled = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при имспорте файла.", "Ошибка импорта.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку exportToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Экспорт файла";
                saveFileDialog.Filter = "CSF File(*.csf)|*.csf";
                if (_data != null && _clusters != null && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        UpdateChanges();
                        CSFContainer csfContainer = new CSFContainer(_data, _clusters);
                        binaryFormatter.Serialize(fileStream, csfContainer);
                        tabControl.SelectTab(1);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при экспорте файла.", "Ошибка экспорта.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку closeToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetData();
            ResetComponents();
        }

        /// <summary>
        /// Действие при нажатии на кнопку saveToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_data != null)
                {
                    _data.UpdateRows();
                    CSVData.SaveToCSV(_data, _data.FilePath);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении файла.", "Ошибка сохранения.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку saveAsToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Сохранить как...";
                saveFileDialog.Filter = "CSV File(*.csv)|*.csv";
                if (_data != null && saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    _data.UpdateRows();
                    CSVData.SaveToCSV(_data, filePath);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при сохранении файла.", "Ошибка сохранения.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку exitToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Действие при нажатии на кнопку aboutToolStripMenuItem
        /// </summary>
        /// <param name="sender">Сама кнопка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }


        #endregion

        private void dataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView.ColumnCount; i++)
            //{
            //    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
        }

        private void показатьСтатисикуКласстераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.contentsHeadings = Tools.GetChosenDataPointNames(isChosen);
            statisticsForm._clusters = _clusters;
            statisticsForm.Setup();
            statisticsForm.ShowDialog();
        }
    }
}
