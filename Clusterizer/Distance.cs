using System;

namespace Clusterizer
{
    public static class Distance
    {
        /// <summary>
        ///     Gets the distance.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="distanceMetric">The distance metric.</param>
        /// <returns>Datapoints distance</returns>
        /// <exception cref="ArgumentException">Неравное колличество точек.</exception>
        public static double GetDistance(DataPoint x, DataPoint y, DistanceMetric distanceMetric)
        {
            double distance = 0;
            double diff;

            // checks for dimensions match
            if (x.Count != y.Count)
                throw new ArgumentException("Неравное колличество точек.");

            switch (distanceMetric)
            {
                case DistanceMetric.EuclidianDistance: // calculates by using Euclidian Distance
                    for (var i = 0; i < x.Count; i++)
                    {
                        diff = x[i] - y[i];
                        distance += diff * diff;
                    }

                    distance = Math.Sqrt(distance);
                    break;
                case DistanceMetric.SquareEuclidianDistance: // calculates by using Square of Euclidian Distance
                    for (var i = 0; i < x.Count; i++)
                    {
                        diff = x[i] - y[i];
                        distance += diff * diff;
                    }

                    break;
                case DistanceMetric.ManhattanDistance: // calculates by using Manhattan Distance
                    for (var i = 0; i < x.Count; i++)
                    {
                        diff = x[i] - y[i];
                        distance += Math.Abs(diff);
                    }

                    break;
                case DistanceMetric.ChebyshevDistance: // calculates by using Chebyshev Distance
                    for (var i = 0; i < x.Count; i++)
                    {
                        diff = Math.Abs(x[i] - y[i]);
                        distance = distance > diff ? distance : diff;
                    }

                    break;
            }

            return distance;
        }
    }

    #region DistanceMetric

    public enum DistanceMetric
    {
        EuclidianDistance, // Euclidian Metric
        SquareEuclidianDistance, // Square of Euclidian Metric
        ManhattanDistance, // Manhattan Metric
        ChebyshevDistance // Chebyshev Metric
    }

    #endregion
}