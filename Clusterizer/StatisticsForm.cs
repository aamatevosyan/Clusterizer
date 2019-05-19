using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{

    /// <summary>
    /// Data structure for storing value with its index and groupID
    /// </summary>
    struct StatisticPoint
    {
        /// <summary>
        /// The group identifier
        /// </summary>
        public int groupID;

        /// <summary>
        /// The value
        /// </summary>
        public double value;

        /// <summary>
        /// The index
        /// </summary>
        public int index;
    }

    /// <summary>
    /// Form for presenting overview of clusters
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class StatisticsForm : Form
    {
        #region Fields
        /// <summary>
        /// The clusters
        /// </summary>
        internal ClusterSet _clusters;

        /// <summary>
        /// The contents headings
        /// </summary>
        internal string[] contentsHeadings;

        /// <summary>
        /// The data table
        /// </summary>
        private DataTable _dataTable;

        /// <summary>
        /// The contents
        /// </summary>
        private StatisticPoint[][] contents;

        /// <summary>
        /// The is calculation over
        /// </summary>
        private bool _isCalculationOver;

        #endregion

        public StatisticsForm()
        {
            InitializeComponent();
        }

        public void Setup()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Название кластера");
            for (int i = 0; i < Tools.NumericDataHeadings.Length; i++)
                _dataTable.Columns.Add(Tools.NumericDataHeadings[i]);
            _dataTable.Columns.Add("Число обьектов");
            contents = new StatisticPoint[contentsHeadings.Length][];

            for (int i = 0; i < _clusters.Count; i++)
            {
                var list = _clusters.GetCluster(i).Centroid.Points.Select(x => $"{x}").ToList();
                list.Insert(0, $"Cluster{_clusters.GetCluster(i).ID}");
                list.Add($"{_clusters.GetCluster(i).QuantityOfDataPoints}");
                _dataTable.Rows.Add(list.ToArray());
            }




            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                contents[j] = new StatisticPoint[_clusters.Count];
            }

            for (int i = 0; i < _clusters.Count; i++)
            {
                for (int j = 0; j < contentsHeadings.Length; j++)
                {
                    contents[j][i] = new StatisticPoint();
                    contents[j][i].value = _clusters.GetCluster(i).Centroid[j];
                    contents[j][i].groupID = 0;
                    contents[j][i].index = i;
                }
            }

            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                contents[j] = contents[j].OrderBy((x) => x.value).ToArray();
                var points = contents[j].Select(x => x.value).ToArray();
                var IDs = Tools.GroupBy(points);
                for (int i = 0; i < contents[j].Length; i++)
                    contents[j][i].groupID = IDs[i];
                contents[j] = contents[j].OrderBy((x) => x.index).ToArray();
            }
            

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.DataSource = _dataTable;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();
        }

       



        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
    
            for (int i = 0; i < _clusters.Count; i++)
            {
                Debug.Write($"Index {i}: ");
                for (int j = 0; j < contentsHeadings.Length; j++)
                {
                    Color color;
                    if (contents[j][i].groupID == 1)
                        color = Color.Aqua;
                    else if (contents[j][i].groupID == 2)
                        color = Color.AliceBlue;
                    else
                        color = Color.DarkCyan;
                    Debug.Write($"{j}: {color.Name} ,");
                    dataGridView1.Rows[i].Cells[j + 1].Style.BackColor = color;

                }
                Debug.WriteLine("");
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fileStream = new FileStream("tmpOverview.csv", FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                for (int i = 0; i < _clusters.Count; i++)
                {
                    var tmpContent = _clusters[i].Centroid.Points.ToList();
                    tmpContent.Add(_clusters[i].QuantityOfDataPoints);
                    streamWriter.WriteLine(string.Join(";", tmpContent));
                }
                streamWriter.Flush();
            }
        }
    }
}
