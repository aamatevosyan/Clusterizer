using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{

    struct StatisticPoint
    {
        public int groupID;
        public double value;
        public int index;
    }

    public partial class StatisticsForm : Form
    {
        internal Clusters _clusters;
        internal string[] contentsHeadings;
        private DataTable _dataTable;
        private StatisticPoint[][] contents;

        public StatisticsForm()
        {
            InitializeComponent();
        }

        public void Setup()
        {
            _dataTable = new DataTable();
            _dataTable.Columns.Add("Название кластера");
            for (int i = 0; i < Tools.DataPointsNames.Length; i++)
                _dataTable.Columns.Add(Tools.DataPointsNames[i]);
            _dataTable.Columns.Add("Число обьектов");
            contents = new StatisticPoint[contentsHeadings.Length][];

            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                contents[j] = new StatisticPoint[_clusters.Count];
            }

            for (int i = 0; i < _clusters.Count; i++)
            {
                for (int j = 0; j < contentsHeadings.Length; j++)
                {
                    contents[j][i] = new StatisticPoint();
                    contents[j][i].value = _clusters.GetCluster(i)._centroid.GetPoint(j);
                    contents[j][i].groupID = 0;
                    contents[j][i].index = i;
                }
            }

            for (int j = 0; j < contentsHeadings.Length; j++)
            {
                contents[j] = contents[j].OrderBy((x) => x.value).ToArray();
                var points = contents[j].Select(x => x.value).ToArray();
                var IDs = GroupBy(points);
                for (int i = 0; i < contents[j].Length; i++)
                    contents[j][i].groupID = IDs[i];
                contents[j] = contents[j].OrderBy((x) => x.index).ToArray();
            }


            for (int i = 0; i < _clusters.Count; i++)
            {
                var list = _clusters.GetCluster(i)._centroid.GetPoints().Select(x => $"{x}").ToList();
                list.Insert(0, $"Cluster{_clusters.GetCluster(i).Id}");
                list.Add($"{_clusters.GetCluster(i).UpdateTotalQuantityOfPatterns()}");
                _dataTable.Rows.Add(list.ToArray());
            }


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.DataSource = _dataTable;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.Refresh();





        }

        public int[] GroupBy(double[] points)
        {
            double _max = points.Max();
            double _min = points.Min();

            int[] groupIds = new int[points.Length];

            double _minRes = double.MaxValue;
            int _minI = 0;
            int _minJ = 0;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = (points[i] - _min) / (_max - _min);
            }
            double _avg = points[points.Length / 2];

            for (int i = 1; i < points.Length / 2; i++)
            {
                for (int j = points.Length / 2; j < points.Length; j++)
                {
                    var minArr = points.Slice(0, i);
                    var avgArr = points.Slice(i, j);
                    var maxArr = points.Slice(j, points.Length);

                    double tmp = 2 * getStandartDeviation(avgArr, _avg) -getStandartDeviation(minArr, _avg) - getStandartDeviation(maxArr, _avg);
                    if (tmp < _minRes)
                    {
                        _minRes = tmp;
                        _minI = i;
                        _minJ = j;
                    }
                }
            }

            for (int i = 0; i < _minI; i++)
            {
                groupIds[i] = 1;
            }

            for (int i = _minI; i < _minJ; i++)
            {
                groupIds[i] = 2;
            }

            for (int i = _minJ; i < groupIds.Length; i++)
            {
                groupIds[i] = 3;
            }

            Debug.WriteLine(string.Join(" ", groupIds.Select(x => $"{x}")));
            return groupIds;
        }

        public double getStandartDeviation(double[] points, double average)
        {
            double sum = 0;
            foreach (var point in points)
            {
                sum += Math.Pow((point - average), 2);
            }

            return Math.Sqrt(sum / (points.Length - 1));
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
    }
}
