using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for presenting dissimilarity matrix
    /// </summary>
    public class DissimilarityMatrix
    {
        #region Поля                
        /// <summary>
        /// The distance matrix
        /// </summary>
        private readonly Dictionary<ClusterPair, double> _distanceMatrix;
        #endregion

        #region Constructor                
        /// <summary>
        /// Initializes a new instance of the <see cref="DissimilarityMatrix"/> class.
        /// </summary>
        public DissimilarityMatrix()
        {
            _distanceMatrix = new Dictionary<ClusterPair, double>(new ClusterPair.EqualityComparer());
        }
        #endregion

        #region Методы                
        /// <summary>
        /// Adds the cluster pair and distance.
        /// </summary>
        /// <param name="clusterPair">The cluster pair.</param>
        /// <param name="distance">The distance.</param>
        public void AddClusterPairAndDistance(ClusterPair clusterPair, double distance)
        {
            _distanceMatrix.Add(clusterPair, distance);
        }

        /// <summary>
        /// Removes the cluster pair.
        /// </summary>
        /// <param name="clusterPair">The cluster pair.</param>
        public void RemoveClusterPair(ClusterPair clusterPair)
        {
            _distanceMatrix.Remove(_distanceMatrix.ContainsKey(clusterPair)
                ? clusterPair
                : new ClusterPair(clusterPair.Cluster2, clusterPair.Cluster1));
        }

        /// <summary>
        /// Gets the closest cluster pair.
        /// </summary>
        /// <returns></returns>
        public ClusterPair GetClosestClusterPair()
        {
            double minDistance = double.MaxValue;
            ClusterPair closestClusterPair = null;

            foreach (var item in _distanceMatrix)
            {
                if (item.Value < minDistance)
                {
                    minDistance = item.Value;
                    closestClusterPair = item.Key;
                }
            }

            return closestClusterPair;
        }


        /// <summary>
        /// Returns the cluster pair distance.
        /// </summary>
        /// <param name="clusterPair">The cluster pair.</param>
        /// <returns></returns>
        public double ReturnClusterPairDistance(ClusterPair clusterPair)
        {
            double clusterPairDistance;

            clusterPairDistance = _distanceMatrix.ContainsKey(clusterPair) ? _distanceMatrix[clusterPair] : _distanceMatrix[new ClusterPair(clusterPair.Cluster2, clusterPair.Cluster1)];
            return clusterPairDistance;
        }
        #endregion
    }
}
