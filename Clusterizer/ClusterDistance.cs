namespace Clusterizer
{
    /// <summary>
    /// Статистический класс для расчета растояния между кластерами
    /// </summary>
    public static class ClusterDistance
    {
        #region Strategy
        /// <summary>
        /// Перечисление стратегии объединения кластеров
        /// </summary>
        public enum Strategy
        {
            SingleLinkage, // Одиночная связь (расстояния ближайшего соседа)
            CompleteLinkage, // Полная связь (расстояние наиболее удаленных соседей)
            AverageLinkageWPGMA, // Невзвешенное попарное среднее
            AverageLinkageUPGMA, // Взвешенное попарное среднее
            CentroidLinkage, // Растояние центроидов
            MinimalSOELinkage // Метод минимальным сумм квадратов
        }
        #endregion

        #region Методы
        /// <summary>
        /// Считает растояние между двумя кластерами
        /// </summary>
        /// <param name="cluster1">Первый кластер</param>
        /// <param name="cluster2">Второй кластер</param>
        /// <returns></returns>
        public static double ComputeDistance(Cluster cluster1, Cluster cluster2, Distance.DistanceMetric distanceMetric)
        {
            double distance = 0;

            // Если синглтон кластер то считает растояние между ними
            if (cluster1.QuantityOfPatterns == 1 && cluster2.QuantityOfPatterns == 1)
                distance = Distance.GetDistance(cluster1.GetPattern(0), cluster2.GetPattern(0), distanceMetric);

            return distance;
        }


        /// <summary>
        /// Считает растояние между двумя кластерами если они имеют подкластеры(
        /// </summary>
        /// <param name="cluster1">Первый кластер</param>
        /// <param name="cluster2">Второй кластер</param>
        /// <param name="dissimilarityMatrix">Матрица разностей</param>
        /// <param name="strategy">Стратегия обьеденения</param>
        public static double ComputeDistance(Cluster cluster1, Cluster cluster2, DissimilarityMatrix dissimilarityMatrix, Strategy strategy)
        {
            double distance1, distance2, distance = 0;
            // Растояние между cluster1 и первым подкластером cluster2
            distance1 = dissimilarityMatrix.ReturnClusterPairDistance(new ClusterPair(cluster1, cluster2.GetSubCluster(0)));
            // Растояние между cluster1 и вторым подкластером cluster2
            distance2 = dissimilarityMatrix.ReturnClusterPairDistance(new ClusterPair(cluster1, cluster2.GetSubCluster(1)));

            switch (strategy)
            {
                case Strategy.SingleLinkage: distance = _MinValue(distance1, distance2); break;
                case Strategy.CompleteLinkage: distance = _MaxValue(distance1, distance2); break;
                case Strategy.AverageLinkageWPGMA: distance = (distance1 + distance2) / 2; break;
                case Strategy.AverageLinkageUPGMA:
                    distance = ((cluster2.GetSubCluster(0).TotalQuantityOfPatterns * distance1) / cluster2.TotalQuantityOfPatterns) + ((cluster2.GetSubCluster(1).TotalQuantityOfPatterns * distance2) / cluster2.TotalQuantityOfPatterns);
                    break;
                case Strategy.CentroidLinkage:
                    cluster1.GetAllPatterns();
                    cluster2.GetAllPatterns();
                    cluster1.SetCentroid();
                    cluster2.SetCentroid();
                    distance = Distance.GetDistance(cluster1._centroid, cluster2._centroid,
                        Distance.DistanceMetric.SquareEuclidianDistance);
                    break;
                case Strategy.MinimalSOELinkage:

                    Cluster newCluster = new Cluster();
                    newCluster.AddSubCluster(cluster1);
                    newCluster.AddSubCluster(cluster2);
                    newCluster.GetAllPatterns();
                    newCluster.SetCentroid();

                    distance = newCluster.getSumOfSquaredError(Distance.DistanceMetric.EuclidianDistance) - cluster1.getSumOfSquaredError(Distance.DistanceMetric.EuclidianDistance) - cluster2.getSumOfSquaredError(Distance.DistanceMetric.EuclidianDistance);
                    break;
            }

            return distance;

        }

        /// <summary>
        /// Возвращает минимальное значение двух вещественных чисел
        /// </summary>
        /// <param name="value1">Первое число</param>
        /// <param name="value2">Второе число</param>
        /// <returns></returns>
        private static double _MinValue(double value1, double value2)
        {
            return value1 < value2 ? value1 : value2;
        }

        /// <summary>
        /// Возвращает максимальное значение двух вещественных чисел
        /// </summary>
        /// <param name="value1">Первое число</param>
        /// <param name="value2">Второе число</param>
        /// <returns></returns>
        private static double _MaxValue(double value1, double value2)
        {
            return value1 > value2 ? value1 : value2;
        }
        #endregion
    }
}
