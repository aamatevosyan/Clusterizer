using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Data structure of Cluster's set
    /// </summary>
    public class ClusterSet : IEnumerable
    {
        #region Properties             
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count => ClustersList.Count;

        /// <summary>
        /// Gets or sets the clusters list.
        /// </summary>
        /// <value>
        /// The clusters list.
        /// </value>
        public List<Cluster> ClustersList { get; set; }
        #endregion

        #region Конструктор                
        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterSet"/> class.
        /// </summary>
        public ClusterSet()
        {
            ClustersList = new List<Cluster>();
        }

        #endregion

        #region Method                
        /// <summary>
        /// Adds the cluster.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        public void AddCluster(Cluster cluster)
        {
            ClustersList.Add(cluster);
        }

        /// <summary>
        /// Removes the cluster.
        /// </summary>
        /// <param name="cluster">The cluster.</param>
        public void RemoveCluster(Cluster cluster)
        {
            ClustersList.Remove(cluster);
        }

        /// <summary>
        /// Gets the cluster.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Cluster GetCluster(int index)
        {
            return ClustersList.ElementAt(index);
        }

        /// <summary>
        /// Gets the <see cref="Cluster"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="Cluster"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Cluster this[int index] => ClustersList[index];

        /// <summary>
        /// Removes the cluster pair.
        /// </summary>
        /// <param name="clusterPair">The cluster pair.</param>
        public void RemoveClusterPair(ClusterPair clusterPair)
        {
            RemoveCluster(clusterPair.Cluster1);
            RemoveCluster(clusterPair.Cluster2);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return ClustersList.GetEnumerator();
        }

        /// <summary>
        /// Normalizes cluster's datapoints using the specified normalize method.
        /// </summary>
        /// <param name="normalizeMethod">The normalize method.</param>
        public void Normalize(NormalizeMethod normalizeMethod)
        {
            // if there is no normalization
            if (normalizeMethod == NormalizeMethod.None)
                return;

            
            int pointCount = ClustersList[0].DataPoints[0].Count; // datapoints count
            int clustersCount = ClustersList.Count; // clusters count

            // gets all data subgrouped by their datapoints
            double[][] dataArray = new double[pointCount][];

            for (int i = 0; i < pointCount; i++)
            {
                dataArray[i] = new double[clustersCount];
                for (int j = 0; j < clustersCount; j++)
                    dataArray[i][j] = ClustersList[j].DataPoints[0][i];
            }

            // normalizes data
            if (normalizeMethod == NormalizeMethod.MinMax)
            {
                for(int i = 0; i < pointCount; i++)
                    Tools.MinMaxNormalize(ref dataArray[i]);
            } else if (normalizeMethod == NormalizeMethod.ZScore)
            {
                for (int i = 0; i < pointCount; i++)
                    Tools.ZScoreNormalize(ref dataArray[i]);
            }

            // updates data with normalized one
            for(int i = 0; i < pointCount; i++) {
                for (int j = 0; j < ClustersList.Count; j++)
                {
                    ClustersList[j].DataPoints[0][i] = dataArray[i][j];
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Enum for Normalize Method
    /// </summary>
    public enum NormalizeMethod
    {
        None, // No Normalization
        MinMax, // Min-Max Normalization
        ZScore // Z-Score Normalization
    }
}
