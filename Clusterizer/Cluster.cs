using System;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for presenting cluster
    /// </summary>
    public class Cluster
    {
        #region Fields        
        /// <summary>
        /// Gets or sets the sub clusters.
        /// </summary>
        /// <value>
        /// The sub clusters.
        /// </value>
        public List<Cluster> SubClusters { get; set; }

        /// <summary>
        /// Gets or sets the data points.
        /// </summary>
        /// <value>
        /// The data points.
        /// </value>
        public List<DataPoint> DataPoints { get; set; }

        /// <summary>
        /// Gets or sets the centroid.
        /// </summary>
        /// <value>
        /// The centroid.
        /// </value>
        public DataPoint Centroid { get; set; }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets the quantity of data points.
        /// </summary>
        /// <value>
        /// The quantity of data points.
        /// </value>
        public int QuantityOfDataPoints => DataPoints.Count;


        /// <summary>
        /// Gets the quantity of sub clusters.
        /// </summary>
        /// <value>
        /// The quantity of sub clusters.
        /// </value>
        public int QuantityOfSubClusters => SubClusters.Count;
        #endregion


        #region Конструктор                
        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        public Cluster()
        {
            DataPoints = new List<DataPoint>();
            SubClusters = new List<Cluster>();
        }
        #endregion

        #region Methods                    
        /// <summary>
        /// Adds the data point.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        public void AddDataPoint(DataPoint dataPoint)
        {
            DataPoints.Add(dataPoint);
        }

        /// <summary>
        /// Adds the sub cluster.
        /// </summary>
        /// <param name="subCluster">The sub cluster.</param>
        public void AddSubCluster(Cluster subCluster)
        {
            SubClusters.Add(subCluster);
            DataPoints.AddRange(subCluster.DataPoints);
        }

        /// <summary>
        /// Gets the sub cluster.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Cluster GetSubCluster(int index)
        {
            return SubClusters.ElementAt(index);
        }

        /// <summary>
        /// Sets the centroid of cluster.
        /// </summary>
        public void SetCentroid()
        {
            int dataPointsCount = DataPoints[0].Count;
            double[] tmpPoints = Enumerable.Repeat(0.0, dataPointsCount).ToArray();

            // sum all datapoints of cluster
            foreach (var dataPoint in DataPoints)
                for (int i = 0; i < dataPointsCount; i++)
                    tmpPoints[i] += dataPoint[i];

            // get mean of datapoints
            for (int i = 0; i < dataPointsCount; i++)
                tmpPoints[i] /= QuantityOfDataPoints;

            Centroid = new DataPoint(tmpPoints.ToList());
        }

        /// <summary>
        /// Gets the sum of squared error.
        /// </summary>
        /// <param name="distanceMetric">The distance metric.</param>
        /// <returns>Sum of squared error of cluster</returns>
        public double GetSumOfSquaredError(DistanceMetric distanceMetric)
        {
            double squaredErrorSum = 0;
            double distToCenter;

            //distance of each element to clustercenter
            foreach (var pattern in DataPoints)
            {
                distToCenter = Distance.GetDistance(Centroid, pattern, distanceMetric);
                squaredErrorSum += Math.Pow(distToCenter, 2);
            }
            return squaredErrorSum;

        }
        #endregion


    }
}
