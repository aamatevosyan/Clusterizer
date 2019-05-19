using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Class for AGNES Clustering
    /// </summary>
    public class Agnes
    {

        #region Fields              
        /// <summary>
        /// The clusters
        /// </summary>
        private readonly ClusterSet _clusters;

        /// <summary>
        /// The dissimilarity matrix
        /// </summary>
        private DissimilarityMatrix _dissimilarityMatrix;

        /// <summary>
        /// The distance metric
        /// </summary>
        private readonly DistanceMetric _distanceMetric;

        /// <summary>
        /// The strategy
        /// </summary>
        private readonly MergeStrategy _strategy;

        /// <summary>
        /// The initial number of clusters
        /// </summary>
        private readonly int _initialNumberOfClusters;

        /// <summary>
        /// The list of indexes for selected CH value
        /// </summary>
        private readonly List<int> _chIndex;

        /// <summary>
        /// The list of CH values
        /// </summary>
        private readonly List<double> _chValue;
        #endregion

        #region Constructor            
        /// <summary>
        /// Initializes a new instance of the <see cref="Agnes"/> class.
        /// </summary>
        /// <param name="clusters">The clusters.</param>
        /// <param name="distanceMetric">The distance metric.</param>
        /// <param name="strategy">The strategy.</param>
        public Agnes(ClusterSet clusters, DistanceMetric distanceMetric, MergeStrategy strategy)
        {
            _clusters = clusters;
            _initialNumberOfClusters = clusters.Count;
            _distanceMetric = distanceMetric;
            _strategy = strategy;

            // creating initial dissimilarity matrix from _clusters
            BuildDissimilarityMatrix();

            _chValue = new List<double>();
            _chIndex = new List<int>();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Builds the dissimilarity matrix.
        /// </summary>
        private void BuildDissimilarityMatrix()
        {
            _dissimilarityMatrix = new DissimilarityMatrix();

            for (int i = 0; i < _clusters.Count - 1; i++)
            {
                for (int j = i + 1; j < _clusters.Count; j++)
                {
                    var clusterPair = new ClusterPair(_clusters.GetCluster(i), _clusters.GetCluster(j));

                    var distanceBetweenTwoClusters = ClusterDistance.ComputeDistance(clusterPair.Cluster1, clusterPair.Cluster2, _distanceMetric);
                    _dissimilarityMatrix.AddClusterPairAndDistance(clusterPair, distanceBetweenTwoClusters); // adds distance to matrix
                }
            }
        }

        /// <summary>
        /// Updates the dissimilarity matrix after adding new cluster to matrix.
        /// </summary>
        /// <param name="newCluster">The new cluster.</param>
        private void _UpdateDissimilarityMatrix(Cluster newCluster)
        {
            for (int i = 0; i < _clusters.Count; i++)
            {
                // distance between newCluster and one of the _clusters one
                var distanceBetweenClusters = ClusterDistance.ComputeDistance(_clusters.GetCluster(i), newCluster, _dissimilarityMatrix, _strategy); 
                _dissimilarityMatrix.AddClusterPairAndDistance(new ClusterPair(newCluster, _clusters.GetCluster(i)), distanceBetweenClusters); // adds distane to matrix

                // removes old cluster distance because they are useless
                _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(0), _clusters.GetCluster(i)));
                _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(1), _clusters.GetCluster(i)));
            }

            // remove the distance of the the initial cluster subclusters
            _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(0), newCluster.GetSubCluster(1)));

        }

        /// <summary>
        /// Builds the hierarchical clustering.
        /// </summary>
        /// <param name="indexNewCluster">The index new cluster.</param>
        /// <param name="k">The k.</param>
        /// <param name="isWithIndex">if set to <c>true</c> [is with index].</param>
        private void BuildHierarchicalClustering(int indexNewCluster, int k, bool isWithIndex = false)
        {
            ClusterPair closestClusterPair = _dissimilarityMatrix.GetClosestClusterPair(); // gets the clusterpair with minimal distance

            // creates new cluster by merging clusters from closestClusterPair
            Cluster newCluster = new Cluster();
            newCluster.AddSubCluster(closestClusterPair.Cluster1);
            newCluster.AddSubCluster(closestClusterPair.Cluster2);
            newCluster.Id = indexNewCluster;
            newCluster.SetCentroid();
     
            // removes cluster pair from _clusters
            _clusters.RemoveClusterPair(closestClusterPair);
            _UpdateDissimilarityMatrix(newCluster);
            // add new cluster to _clusters
            _clusters.AddCluster(newCluster);

            if (isWithIndex) // checks is executed for calculating CH index
            {
                _chValue.Add(GetCHIndex()); // adds index to array of CH values
                _chIndex.Add(_clusters.ClustersList.Count); // adds number of clusters for current CH value
            }

            // exit point of algorithm (Where _clusters count is equal to k)
            if (_clusters.Count > k)
                BuildHierarchicalClustering(indexNewCluster + 1, k, isWithIndex);
        }

        /// <summary>
        /// Executes the clustering.
        /// </summary>
        /// <param name="k">The k.</param>
        /// <param name="isWithIndex">if set to <c>true</c> [is with index].</param>
        /// <returns>Computed ClustersSet</returns>
        public ClusterSet ExecuteClustering(int k, bool isWithIndex = false)
        {
            BuildHierarchicalClustering(_clusters.Count, k, isWithIndex);
            return _clusters;
        }

        /// <summary>
        /// Gets the index of the ch.
        /// </summary>
        /// <returns>Current CH Index</returns>
        private double GetCHIndex()
        {
            // merging all clusters into one
            Cluster overallCluster = new Cluster();
            _clusters.ClustersList.ForEach(c => overallCluster.AddSubCluster(c));
            overallCluster.SetCentroid();

            int currentNumberOfClusters = _clusters.Count;
            if (_clusters.ClustersList.Count < 2) // CH can't be computed for one cluster
                return double.NaN;

            double withinSumOfSquares = 0,
                betweenSumOfSquares = 0;

            foreach (var cluster in _clusters.ClustersList)
            {
                // computes sum of squares within cluster
                withinSumOfSquares += cluster.GetSumOfSquaredError(_distanceMetric);
                // computes som of squares with overallcluster (outside of cluster)
                betweenSumOfSquares += Math.Pow(Distance.GetDistance(overallCluster.Centroid, cluster.Centroid, _distanceMetric), 2);
            }

            // checks if withinSumOfSquares is less then epsilon (CH is NaN)
            // else returns CH using formula
            return Math.Abs(withinSumOfSquares) < double.Epsilon
                ? double.NaN
                : (betweenSumOfSquares / withinSumOfSquares / (currentNumberOfClusters - 1)) *
                  (_initialNumberOfClusters - currentNumberOfClusters);
        }

        /// <summary>
        /// Gets the recomended count of clusters by calculating local Max f.
        /// </summary>
        /// <returns></returns>
        public int GetRecommendedCountOfClusters()
        {
            int maxIndex = _initialNumberOfClusters - 1; // index of Local Max CH
            double maxCoeff = 0; // local Max CH
            
            // finds local Max of CH Values
            for (int i = 1; i < _chValue.Count - 1; i++)
            {
                if (_chValue[i] > _chValue[i - 1] && _chValue[i] > _chValue[i + 1] && _chValue[i] > maxCoeff)
                {
                    maxCoeff = _chValue[i];
                    maxIndex = _chIndex[i];
                }
            }

            return maxIndex;
        }
        #endregion
    }
}
