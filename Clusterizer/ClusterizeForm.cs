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
            foreach (var point in points)
            {
                checkedListBox1.Items.Add(point, true);
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
            distanceMetric = (Distance.DistanceMetric)comboBox1.SelectedIndex;
            strategy = (ClusterDistance.Strategy)comboBox2.SelectedIndex;
            isChosen = new bool[pointsNames.Length];
            for (int i = 0; i < isChosen.Length; i++)
            {
                isChosen[i] = checkedListBox1.GetItemChecked(i);
            }
            this.Close();
        }
    }
}
