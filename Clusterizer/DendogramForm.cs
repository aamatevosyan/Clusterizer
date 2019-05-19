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
    /// Form for visualizing Dendogram
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class DendrogramForm : Form
    {
        #region Properties                
        /// <summary>
        /// The drawarea
        /// </summary>
        private Graphics _drawarea;

        /// <summary>
        /// The root
        /// </summary>
        private Node<string> _root;

        /// <summary>
        /// The current count of leaves
        /// </summary>
        private int _leaves;

        /// <summary>
        /// The current count of levels
        /// </summary>
        private int _levels;

        /// <summary>
        /// The curent color
        /// </summary>
        private Color _color;

        /// <summary>
        /// The width per level
        /// </summary>
        private int _widthPerLevel;

        /// <summary>
        /// The maximum level
        /// </summary>
        private int _maxLevel;

        /// <summary>
        /// The current y
        /// </summary>
        private int _currentY;

        /// <summary>
        /// The height
        /// </summary>
        private int _height;

        /// <summary>
        /// The width
        /// </summary>
        private int _width;

        /// <summary>
        /// The root list
        /// </summary>
        private readonly List<Node<string>> _rootList;

        /// <summary>
        /// The leaves list
        /// </summary>
        private readonly List<int> _leavesList;

        /// <summary>
        /// The levels list
        /// </summary>
        private readonly List<int> _levelsList;

        /// <summary>
        /// The colors
        /// </summary>
        private readonly List<Color> _colors;

        /// <summary>
        /// The random
        /// </summary>
        static readonly Random random = new Random();
        #endregion

        #region Constants             
        /// <summary>
        /// The height per leaf
        /// </summary>
        private const int HeightPerLeaf = 40;

        /// <summary>
        /// The drawing area margin
        /// </summary>
        private const int DrawingAreaMargin = 25;

        /// <summary>
        /// The contest offset
        /// </summary>
        private const int ContestOffset = 80;

        /// <summary>
        /// The drawing area offset
        /// </summary>
        private const int DrawingAreaOffset = 35;
        #endregion

        #region Constructor               
        /// <summary>
        /// Initializes a new instance of the <see cref="DendrogramForm"/> class.
        /// </summary>
        public DendrogramForm()
        {
            InitializeComponent();
            _drawarea = dendogramControl.CreateGraphics();
            _rootList = new List<Node<string>>();
            _leavesList = new List<int>();
            _levelsList = new List<int>();
            _colors = new List<Color>();
        }
        #endregion


        #region Methods                
        /// <summary>
        /// Creates the specified contents.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <returns></returns>
        private Node<string> Create(string contents)
        {
            return new Node<string>(contents);
        }

        /// <summary>
        /// Creates the specified child0.
        /// </summary>
        /// <param name="child0">The child0.</param>
        /// <param name="child1">The child1.</param>
        /// <returns></returns>
        private Node<string> Create(Node<string> child0, Node<string> child1)
        {
            return new Node<string>(child0, child1);
        }

        /// <summary>
        /// Counts the leaves.
        /// </summary>
        /// <param name="node">The node.</param>
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
        /// Counts the levels.
        /// </summary>
        /// <param name="node">The node.</param>
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
        /// Builds the dendrogram.
        /// </summary>
        /// <param name="clusters">The clusters.</param>
        /// <returns>Return overall node</returns>
        private Node<string> BuildDendrogram(Cluster[] clusters)
        {
            Node<string> child0;
            Node<string> child1;

            // cluster with two clusters and without subcluster
            if (clusters.Length == 2 && clusters.ElementAt(0).QuantityOfSubClusters == 0)
            {
                child0 = GetNodeFromCluster(clusters.ElementAt(0));
                child1 = GetNodeFromCluster(clusters.ElementAt(1));

                return Create(child0, child1);
            }

            // singleton cluster with two subclusters
            if (clusters.Length == 1 && clusters.ElementAt(0).QuantityOfSubClusters == 2)
            {
                return BuildDendrogram(clusters.ElementAt(0).SubClusters.ToArray());
            }

            // cluster with two clusters and by 2 subclusters
            if (clusters.Length == 2 && clusters.ElementAt(0).QuantityOfSubClusters == 2)
            {
                child0 = BuildDendrogram(clusters.ElementAt(0).SubClusters.ToArray());

                child1 = clusters.ElementAt(1).QuantityOfSubClusters == 2 ? BuildDendrogram(clusters.ElementAt(1).SubClusters.ToArray()) : GetNodeFromCluster(clusters.ElementAt(1));


                return Create(child0, child1);
            }


            return _root;

        }

        /// <summary>
        /// Gets the node from cluster.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        /// <returns></returns>
        private Node<string> GetNodeFromCluster(Cluster cluster)
        {
            return Create("Cluster" + cluster.Id.ToString());
        }

        /// <summary>
        /// Setups this instance.
        /// </summary>
        public void Setup()
        {  
            for (int i = 0; i < Tools.Clusters.ClustersList.Count; i++)
            {
                // get overall root
                _root = BuildDendrogram(new Cluster[] { Tools.Clusters.ClustersList.ElementAt(i) });

                // check if singleton cluster
                if (Tools.Clusters.GetCluster(i).QuantityOfSubClusters == 0)
                    _root = GetNodeFromCluster(Tools.Clusters.GetCluster(i));

                // calculate values
                _leaves = CountLeaves(_root);
                _levels = CountLevels(_root);

                // get maxLevel count
                if (_levels > _maxLevel)
                    _maxLevel = _levels;

                // add calculated values to list
                _rootList.Add(_root);
                _levelsList.Add(_levels);
                _leavesList.Add(_leaves);

                // generate new random color
                Random rand = random;
                int max = byte.MaxValue + 1; // 256
                int r = rand.Next(max);
                int g = rand.Next(max);
                int b = rand.Next(max);
                Color c = Color.FromArgb(r, g, b);
                _colors.Add(c);
            }
        }

        /// <summary>
        /// Draws the specified g.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="node">The node.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Point Draw(Graphics g, Node<string> node, int y)
        {
            // children of node
            List<Node<string>> children = node.ChildrenNodes;
            // pen for drawing
            Pen pen = new Pen(_color);
            // brush for drawing
            SolidBrush brush = new SolidBrush(_color);

            // if singleton cluster
            if (children.Count == 0)
            {
                int x = Width - ContestOffset - _widthPerLevel - 2 * DrawingAreaMargin;
                // draws string with cluster nam
                g.DrawString(node.Contents, new Font("Times New Roman", 8.0f), brush, x + 8, _currentY - 8);
                int resultX = x;
                int resultY = _currentY;
                _currentY += HeightPerLeaf;
                return new Point(resultX, resultY);
            }

            // if cluster have subclusters
            if (children.Count >= 2)
            {
                Node<string> child0 = children.ElementAt(0);
                Node<string> child1 = children.ElementAt(1);

                // get points of the childs by order
                Point p0 = Draw(g, child0, y);
                Point p1 = Draw(g, child1, y + HeightPerLeaf);

                // fill rectanbles of them
                g.FillRectangle(brush, p0.X - 2, p0.Y - 2, 4, 4);
                g.FillRectangle(brush, p1.X - 2, p1.Y - 2, 4, 4);

                // calculate parameters
                int dx = _widthPerLevel;
                int vx = Math.Min(p0.X - dx, p1.X - dx);

                // combine line with each other
                Pen blackPen = pen;
                g.DrawLine(blackPen, vx, p0.Y, p0.X, p0.Y);
                g.DrawLine(blackPen, vx, p1.Y, p1.X, p1.Y);
                g.DrawLine(blackPen, vx, p0.Y, vx, p1.Y);

                // returns new point
                Point p = new Point(vx, p0.Y + (p1.Y - p0.Y) / 2);
                return p;
            }

            return new Point();
        }

        #endregion

        #region Events
        /// <summary>
        /// Handles the SizeChanged event of the DendrogramFrm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DendrogramForm_SizeChanged(object sender, EventArgs e)
        {
            // gets size of form
            _width = Width - DrawingAreaOffset;
            _height = 0;

            for (int i = 0; i < _levelsList.Count; i++)
            {
                _height += (HeightPerLeaf * _leavesList[i]);
            }

            // calculates new parameters of drawing
            _height += 2 * DrawingAreaMargin + 50;
            _widthPerLevel = (_width - ContestOffset - DrawingAreaMargin - DrawingAreaMargin) / _maxLevel;

            // redraw
            dendogramControl.Invalidate();
        }

        /// <summary>
        /// Handles the FormClosing event of the DendrogramForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void DendrogramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save image to file before closing
            Bitmap bmp = new Bitmap(dendogramControl.Width, dendogramControl.Height);
            dendogramControl.DrawToBitmap(bmp, new Rectangle(0, 0, dendogramControl.Width, dendogramControl.Height));
            bmp.Save("tmpDendogramm.png");
        }

        /// <summary>
        /// Handles the Paint event of the dendogramControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void dendogramControl_Paint(object sender, PaintEventArgs e)
        {
            // setup draw area
            dendogramControl.Size = new Size(_width, _height);
            _currentY = 0;
            _drawarea = e.Graphics;
            _drawarea.TranslateTransform(DrawingAreaMargin, DrawingAreaMargin);

            // gets all self-dependent elements and draw them
            for (int i = 0; i < Tools.Clusters.ClustersList.Count; i++)
            {
                _root = _rootList[i];
                _levels = _levelsList[i];
                _leaves = _leavesList[i];
                _color = _colors[i];

                _widthPerLevel = (_width - ContestOffset - DrawingAreaMargin - DrawingAreaMargin) / _maxLevel;

                // draw element
                Draw(_drawarea, _root, _currentY);
            }
        }
        #endregion


    }
}
