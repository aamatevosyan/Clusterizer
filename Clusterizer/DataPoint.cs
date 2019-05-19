using System;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for presenting set of points
    /// </summary>
    public class DataPoint
    {

        #region Properties               
        /// <summary>
        /// Gets or sets the points.
        /// </summary>
        /// <value>
        /// The points.
        /// </value>
        public List<double> Points { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets the Point's count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => Points.Count;
        #endregion

        #region Конструктор                
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPoint"/> class.
        /// </summary>
        public DataPoint()
        {
            Points = new List<double>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataPoint"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public DataPoint(List<double> points)
        {
            Points = points;
        }
        #endregion

        #region Methods               
        /// <summary>
        /// Adds the specified point.
        /// </summary>
        /// <param name="point">The point.</param>
        public void Add(double point)
        {
            Points.Add(point);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Double"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public double this[int index]
        {
            get { return Points[index]; }
            set { Points[index] = value; }
        }
        #endregion

    }
}
