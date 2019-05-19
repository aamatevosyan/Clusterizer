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
        public int GroupId;

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
        internal ClusterSet Clusters;

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
        private StatisticPoint[][] _contents;

        /// <summary>
        /// The default colors
        /// </summary>
        private Color[] _colors = new Color[]
        {
            Color.Aquamarine, Color.CornflowerBlue, Color.OrangeRed
        };

        #endregion

        #region Constructor                
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsForm"/> class.
        /// </summary>
        public StatisticsForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Setups this instance.
        /// </summary>
        public void Setup()
        {
            // creates data tables
            _dataTable = new DataTable();
            // add columns to datatable
            _dataTable.Columns.Add("Название кластера");
            for (int i = 0; i < Tools.NumericDataHeadings.Length; i++)
                _dataTable.Columns.Add(Tools.NumericDataHeadings[i]);
            _dataTable.Columns.Add("Число обьектов");
            _contents = new StatisticPoint[contentsHeadings.Length][];

            // fill data table
            for (int i = 0; i < Clusters.Count; i++)
            {
                var list = Clusters.GetCluster(i).Centroid.Points.Select(x => $"{x}").ToList();
                list.Insert(0, $"Cluster{Clusters.GetCluster(i).Id}");
                list.Add($"{Clusters.GetCluster(i).QuantityOfDataPoints}");
                _dataTable.Rows.Add(list.ToArray());
            }

            // init contents
            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                _contents[j] = new StatisticPoint[Clusters.Count];
            }

            // gets contents
            for (int i = 0; i < Clusters.Count; i++)
            {
                for (int j = 0; j < contentsHeadings.Length; j++)
                {
                    _contents[j][i] = new StatisticPoint();
                    _contents[j][i].value = Clusters.GetCluster(i).Centroid[j];
                    _contents[j][i].GroupId = 0;
                    _contents[j][i].index = i;
                }
            }

            // group contents
            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                _contents[j] = _contents[j].OrderBy((x) => x.value).ToArray();
                var points = _contents[j].Select(x => x.value).ToArray();
                var indentifiers = Tools.GroupBy(points);
                for (int i = 0; i < _contents[j].Length; i++)
                    _contents[j][i].GroupId = indentifiers[i];
                _contents[j] = _contents[j].OrderBy((x) => x.index).ToArray();
            }

            // fill data gridview
            clustersOverviewGridView.ColumnHeadersVisible = true;
            clustersOverviewGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            clustersOverviewGridView.DataSource = _dataTable;
        }
        #endregion

        #region Events        
        /// <summary>
        /// Handles the FormClosing event of the StatisticsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void StatisticsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (FileStream fileStream = new FileStream("tmpOverview.csv", FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                for (int i = 0; i < Clusters.Count; i++)
                {
                    var tmpContent = Clusters[i].Centroid.Points.ToList();
                    tmpContent.Add(Clusters[i].QuantityOfDataPoints);
                    streamWriter.WriteLine(string.Join(";", tmpContent));
                }
                streamWriter.Flush();
            }
        }

        /// <summary>
        /// Handles the Load event of the StatisticsForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Clusters.Count; i++)
            for (int j = 0; j < contentsHeadings.Length; j++)
                clustersOverviewGridView.Rows[i].Cells[j + 1].Style.BackColor = _colors[_contents[j][i].GroupId - 1];
        }

        /// <summary>
        /// Handles the RowPostPaint event of the clustersOverviewGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewRowPostPaintEventArgs"/> instance containing the event data.</param>
        private void clustersOverviewGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(clustersOverviewGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        /// <summary>
        /// Handles the DataSourceChanged event of the clustersOverviewGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clustersOverviewGridView_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clustersOverviewGridView.ColumnCount; i++)
            {
                clustersOverviewGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        #endregion
    }
}
