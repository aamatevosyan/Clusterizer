using System;
using System.Collections.Concurrent;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Класс Матрицы различии
    /// </summary>
    public class DissimilarityMatrix
    {
        #region Поля        
        /// <summary>
        /// Матрица различии
        /// </summary>
        private ConcurrentDictionary<ClusterPair, double> _distanceMatrix;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="DissimilarityMatrix"/>.
        /// </summary>
        public DissimilarityMatrix()
        {
            _distanceMatrix = new ConcurrentDictionary<ClusterPair, double>(new ClusterPair.EqualityComparer());
        }
        #endregion

        #region Методы        
        /// <summary>
        /// Добавляет растояние между парой класстеров в матрицу
        /// </summary>
        /// <param name="clusterPair">Пара кластеров</param>
        /// <param name="distance">Растояние</param>
        public void AddClusterPairAndDistance(ClusterPair clusterPair, double distance)
        {
            _distanceMatrix.TryAdd(clusterPair, distance);
        }

        /// <summary>
        /// Удаляет расстояние между парой кластеров из матрицы
        /// </summary>
        /// <param name="clusterPair">Пара кластеров</param>
        public void RemoveClusterPair(ClusterPair clusterPair)
        {
            double outvalue;

            if (_distanceMatrix.ContainsKey(clusterPair))
                _distanceMatrix.TryRemove(clusterPair, out outvalue);
            else
                _distanceMatrix.TryRemove(new ClusterPair(clusterPair.Cluster2, clusterPair.Cluster1), out outvalue);
        }
     
        /// <summary>
        /// Вовзращает пару кластеров с минимальным расстоянием
        /// </summary>
        public ClusterPair GetClosestClusterPair()
        {
            double minDistance = double.MaxValue;
            ClusterPair closestClusterPair = new ClusterPair();

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
        /// Возвращает расстояние пары класстеров
        /// </summary>
        /// <param name="clusterPair">The cluster pair.</param>
        /// <returns></returns>
        public double ReturnClusterPairDistance(ClusterPair clusterPair)
        {
            double clusterPairDistance = Double.MaxValue;

            if (_distanceMatrix.ContainsKey(clusterPair))
                clusterPairDistance = _distanceMatrix[clusterPair];
            else
                clusterPairDistance = _distanceMatrix[new ClusterPair(clusterPair.Cluster2, clusterPair.Cluster1)]; // Матрица симметричная но кластеры могут поменяться местами
            return clusterPairDistance;
        }
        #endregion
    }
}
