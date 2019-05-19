namespace Clusterizer
{
    /// <summary>
    /// Static class for computing distance between clusters
    /// </summary>
    public static class ClusterDistance
    {
        /// <summary>
        /// Computes the distance between singleton clusters.
        /// </summary>
        /// <param name="cluster1">The cluster1.</param>
        /// <param name="cluster2">The cluster2.</param>
        /// <param name="distanceMetric">The distance metric.</param>
        /// <returns>Distance between singleton clusters</returns>
        public static double ComputeDistance(Cluster cluster1, Cluster cluster2, DistanceMetric distanceMetric)
        {
            double distance = 0;

            // check if clusters are singleton
            if (cluster1.QuantityOfDataPoints == 1 && cluster2.QuantityOfDataPoints == 1)
                distance = Distance.GetDistance(cluster1.DataPoints[0], cluster2.DataPoints[0], distanceMetric);

            return distance;
        }


        /// <summary>
        /// Computes the distance.
        /// </summary>
        /// <param name="cluster1">The cluster1.</param>
        /// <param name="cluster2">The cluster2.</param>
        /// <param name="dissimilarityMatrix">The dissimilarity matrix.</param>
        /// <param name="strategy">The strategy.</param>
        /// <returns>Distance between clusters</returns>
        public static double ComputeDistance(Cluster cluster1, Cluster cluster2, DissimilarityMatrix dissimilarityMatrix, MergeStrategy strategy)
        {
            double distance1, distance2, distance = 0;
            distance1 = dissimilarityMatrix.ReturnClusterPairDistance(new ClusterPair(cluster1, cluster2.GetSubCluster(0)));
            distance2 = dissimilarityMatrix.ReturnClusterPairDistance(new ClusterPair(cluster1, cluster2.GetSubCluster(1)));

            // computes distance by using merge strategy
            switch (strategy)
            {
                case MergeStrategy.SingleLinkage:
                    distance = _MinValue(distance1, distance2); // Min(x, y)
                    break;
                case MergeStrategy.CompleteLinkage:
                    distance = _MaxValue(distance1, distance2); // Max(x, y)
                    break;
                case MergeStrategy.AverageLinkageWPGMA:
                    distance = (distance1 + distance2) / 2; // Avg(x, y)
                    break;
                case MergeStrategy.AverageLinkageUPGMA:
                    distance = ((cluster2.GetSubCluster(0).QuantityOfDataPoints * distance1) / cluster2.QuantityOfDataPoints) 
                               + ((cluster2.GetSubCluster(1).QuantityOfDataPoints * distance2) / cluster2.QuantityOfDataPoints); // WeightedAvg(x, y)
                    break;
                case MergeStrategy.CentroidMethod:
                    cluster1.SetCentroid();
                    cluster2.SetCentroid();
                    distance = Distance.GetDistance(cluster1.Centroid, cluster2.Centroid,
                        DistanceMetric.SquareEuclidianDistance); // Distance of centroids
                    break;
                case MergeStrategy.WardsMethod:

                    Cluster newCluster = new Cluster();
                    newCluster.AddSubCluster(cluster1);
                    newCluster.AddSubCluster(cluster2);
                    newCluster.SetCentroid();

                    distance = newCluster.GetSumOfSquaredError(DistanceMetric.EuclidianDistance) 
                               - cluster1.GetSumOfSquaredError(DistanceMetric.EuclidianDistance) 
                               - cluster2.GetSumOfSquaredError(DistanceMetric.EuclidianDistance);
                    // SEO(xy) - SEO(x) - SEO(y)
                    break;
            }

            return distance;

        }

        /// <summary>
        /// Calculate the minimal of the given values
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Minimum of the values</returns>
        private static double _MinValue(double value1, double value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        /// <summary>
        /// Calculate the minimal of the given values
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Maximum of the values</returns>
        private static double _MaxValue(double value1, double value2)
        {
            return value1 > value2 ? value1 : value2;
        }
    }

    #region Merge Strategy  
    /// <summary>
    /// Enum of merge strategies
    /// </summary>
    public enum MergeStrategy
    {
        SingleLinkage, // Single Linkage
        CompleteLinkage, // Complete Linkage
        AverageLinkageWPGMA, // Average Linkage (WPGMA)
        AverageLinkageUPGMA, // Average Linkage (UPGMA)
        CentroidMethod, // Centroid Method
        WardsMethod // Wards Method
    }
    #endregion
}
