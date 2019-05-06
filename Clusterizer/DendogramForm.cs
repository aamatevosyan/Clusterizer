using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{
    /// <summary>
    /// Класс для представления дендограммы
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class DendrogramForm : Form
    {
        #region Поля        
        /// <summary>
        /// Кластеры
        /// </summary>
        public Clusters _clusters;
        /// <summary>
        /// Поле рисования
        /// </summary>
        Graphics drawarea;
        /// <summary>
        /// Дерево класстеров
        /// </summary>
        private Node<string> root;
        /// <summary>
        /// Число листьев
        /// </summary>
        private int leaves;
        /// <summary>
        /// Число уровней
        /// </summary>
        private int levels;
        /// <summary>
        /// Ширина каждого уровня
        /// </summary>
        private int widthPerLevel;
        /// <summary>
        /// Текущий Y
        /// </summary>
        private int currentY;
        /// <summary>
        /// Высота
        /// </summary>
        private int height;
        /// <summary>
        /// Ширина
        /// </summary>
        private int width;
        #endregion

        #region Константы        
        /// <summary>
        /// Высота листья
        /// </summary>
        private const int heightPerLeaf = 40;
        /// <summary>
        /// Разница поля рисования
        /// </summary>
        private const int DrawingAreaMargin = 25;
        /// <summary>
        /// Отступ контента
        /// </summary>
        private const int ContestOffset = 80;
        /// <summary>
        /// Отступ поля рисования
        /// </summary>
        private const int DrawingAreaOffset = 35;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="DendrogramForm"/>.
        /// </summary>
        public DendrogramForm()
        {
            InitializeComponent();
            drawarea = drawingArea.CreateGraphics();
        }
        #endregion


        #region Методы        
        /// <summary>
        /// Создает единичное дерево с контентом
        /// </summary>
        /// <param name="contents">Контент</param>
        /// <returns></returns>
        private Node<string> Create(string contents)
        {
            return new Node<string>(contents);
        }

        /// <summary>
        /// Создает дерево с двумя поддеревами
        /// </summary>
        /// <param name="child0">Первое поддерево</param>
        /// <param name="child1">Второе поддерево</param>
        /// <returns></returns>
        private Node<string> Create(Node<string> child0, Node<string> child1)
        {
            return new Node<string>(child0, child1);
        }

        /// <summary>
        /// Считает количество листьев
        /// </summary>
        /// <param name="node">Дерево</param>
        /// <returns></returns>
        private int CountLeaves(Node<string> node)
        {
            List<Node<string>> children = node.ChildrenNodes;
            if (children.Count == 0)
            {
                return 1;
            }

            Node<string> child0 = children.ElementAt(0);
            Node<string> child1 = children.ElementAt(1);

            return CountLeaves(child0) + CountLeaves(child1);
        }

        /// <summary>
        /// Считает количество уровней
        /// </summary>
        /// <param name="node">Дерево</param>
        /// <returns></returns>
        private int CountLevels(Node<string> node)
        {
            List<Node<string>> children = node.ChildrenNodes;
            if (children.Count == 0)
            {
                return 1;
            }

            Node<string> child0 = children.ElementAt(0);
            Node<string> child1 = children.ElementAt(1);

            return 1 + Math.Max(CountLevels(child0), CountLevels(child1));

        }

        /// <summary>
        /// Строит дендограмму из кластеров
        /// </summary>
        /// <param name="clusters">Кластеры</param>
        /// <returns></returns>
        private Node<string> BuildDendrogram(Cluster[] clusters)
        {
            Node<string> child0;
            Node<string> child1;

            if (clusters.Count() == 2 && clusters.ElementAt(0).QuantityOfSubClusters == 0)
            {
                child0 = GetNodeFromCluster(clusters.ElementAt(0));
                child1 = GetNodeFromCluster(clusters.ElementAt(1));

                return Create(child0, child1);
            }

            if (clusters.Count() == 1 && clusters.ElementAt(0).QuantityOfSubClusters == 2)
            {
                return BuildDendrogram(clusters.ElementAt(0).GetSubClusters());
            }

            if (clusters.Count() == 2 && clusters.ElementAt(0).QuantityOfSubClusters == 2)
            {
                child0 = BuildDendrogram(clusters.ElementAt(0).GetSubClusters());

                if (clusters.ElementAt(1).QuantityOfSubClusters == 2)
                {
                    child1 = BuildDendrogram(clusters.ElementAt(1).GetSubClusters());
                }
                else
                {
                    child1 = GetNodeFromCluster(clusters.ElementAt(1));
                }


                return Create(child0, child1);
            }


            return root;

        }

        /// <summary>
        /// Получает дерево из кластера
        /// </summary>
        /// <param name="cluster">Кластера</param>
        private Node<string> GetNodeFromCluster(Cluster cluster)
        {
            return Create("Cluster" + cluster.Id.ToString());
        }

        /// <summary>
        /// Первоначальная установка
        /// </summary>
        public void Setup()
        {
            if (_clusters == null)
            {
                MessageBox.Show("Пожалуйста кластеризуйте сначала данные.");
                return;
            }

            root = BuildDendrogram(_clusters.GetClusters());

            leaves = CountLeaves(root); 
            levels = CountLevels(root);
        }

        /// <summary>
        /// Рисует дендограмму
        /// </summary>
        /// <param name="e">Аргумент события <see cref="PaintEventArgs"/> </param>
        public void DrawDendrogram(PaintEventArgs e)
        {
            this.drawingArea.Size = new Size(width, height);
            currentY = 0;
            drawarea = e.Graphics;

            drawarea.TranslateTransform(DrawingAreaMargin, DrawingAreaMargin);
            draw(drawarea, root, 0);
        }

        /// <summary>
        /// Рисует дендограмму
        /// </summary>
        /// <param name="g">Графика</param>
        /// <param name="node">Дерево</param>
        /// <param name="y">Координат Y</param>
        /// <returns></returns>
        private Point draw(Graphics g, Node<string> node, int y)
        {
            List<Node<string>> children = node.ChildrenNodes;

            if (children.Count == 0)
            {
                int x = Width - ContestOffset - widthPerLevel - 2 * DrawingAreaMargin;

                g.DrawString(node.Contents, new Font("Times New Roman", 8.0f), Brushes.Black, x + 8, currentY - 8);
                int resultX = x;
                int resultY = currentY;
                currentY += heightPerLeaf;
                return new Point(resultX, resultY);
            }

            if (children.Count >= 2)
            {
                Node<string> child0 = children.ElementAt(0);
                Node<string> child1 = children.ElementAt(1);
                Point p0 = draw(g, child0, y);
                Point p1 = draw(g, child1, y + heightPerLeaf);

                g.FillRectangle(Brushes.Black, p0.X - 2, p0.Y - 2, 4, 4);
                g.FillRectangle(Brushes.Black, p1.X - 2, p1.Y - 2, 4, 4);

                int dx = widthPerLevel;
                int vx = Math.Min(p0.X - dx, p1.X - dx);

                Pen blackPen = new Pen(Color.Black);
                g.DrawLine(blackPen, vx, p0.Y, p0.X, p0.Y);
                g.DrawLine(blackPen, vx, p1.Y, p1.X, p1.Y);
                g.DrawLine(blackPen, vx, p0.Y, vx, p1.Y);

                Point p = new Point(vx, p0.Y + (p1.Y - p0.Y) / 2);
                return p;
            }

            return new Point();
        }

        /// <summary>
        /// Действие при событии Paint поля drawingArea
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Аргумент события <see cref="PaintEventArgs"/>.</param>
        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            DrawDendrogram(e);
        }

        /// <summary>
        /// Действие при событии SizeChanged формы
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/>.</param>
        private void DendrogramFrm_SizeChanged(object sender, EventArgs e)
        {
            width = Width - DrawingAreaOffset;
            widthPerLevel = (width - ContestOffset - DrawingAreaMargin - DrawingAreaMargin) / levels;
            height = (heightPerLeaf * leaves) + 2 * DrawingAreaMargin + 50;
            drawingArea.Invalidate();
        }

        /// <summary>
        /// Действие при нажатии кнопок
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void DendrogramForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                Graphics g = drawingArea.CreateGraphics();
                Bitmap bmp = new Bitmap(drawingArea.Width, drawingArea.Height);
                drawingArea.DrawToBitmap(bmp, new Rectangle(0, 0, drawingArea.Width, drawingArea.Height));
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG File(*.png)|*.png"; ;
                saveFileDialog.Title = "Сохранить дендограмму...";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    bmp.Save(saveFileDialog.FileName);
            }
        }
        #endregion


    }
}
