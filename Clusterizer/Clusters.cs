using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Класс кластеров
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    [Serializable]
    public class Clusters : IEnumerable
    {
        #region Поля
        /// <summary>
        /// Множество кластеров
        /// </summary>
        private HashSet<Cluster> _clusters;
        #endregion

        #region Свойства        
        /// <summary>
        /// ID Кластеров
        /// </summary>
        public int Id { get; private set; }

        public int Count => _clusters.Count;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="Clusters"/>.
        /// </summary>
        public Clusters()
        {
            _clusters = new HashSet<Cluster>();
        }
        #endregion

        #region Методы        
        /// <summary>
        /// Добавляет кластер в список кластеров
        /// </summary>
        /// <param name="cluster">Кластер</param>
        public void AddCluster(Cluster cluster)
        {
            _clusters.Add(cluster);
        }

        /// <summary>
        /// Удаляет кластер из списка кластеров
        /// </summary>
        /// <param name="cluster">Кластер</param>
        public void RemoveCluster(Cluster cluster)
        {
            _clusters.Remove(cluster);
        }

        /// <summary>
        /// Возвращает кластер под заданым индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        public Cluster GetCluster(int index)
        {
            return _clusters.ElementAt(index);
        }

        /// <summary>
        /// Возвращает массив кластеров
        /// </summary>
        public Cluster[] GetClusters()
        {
            return _clusters.ToArray<Cluster>();
        }

        /// <summary>
        /// Создает синглтон кластер из матрицы паттернов
        /// </summary>
        /// <param name="patternMatrix">Матрица паттернов</param>
        public void BuildSingletonCluster(PatternMatrix patternMatrix)
        {
            int clusterId = 0;
            Cluster cluster;

            foreach (Pattern item in patternMatrix)
            {
                cluster = new Cluster();
                cluster.Id = clusterId;
                cluster.AddPattern(item);
                cluster.TotalQuantityOfPatterns = 1;
                _clusters.Add(cluster);
                clusterId++;
            }
        }

        /// <summary>
        /// Удаляет пару кластеров из списка
        /// </summary>
        /// <param name="clusterPair">Пара кластеров</param>
        public void RemoveClusterPair(ClusterPair clusterPair)
        {
            this.RemoveCluster(clusterPair.Cluster1);
            this.RemoveCluster(clusterPair.Cluster2);
        }

        /// <summary>
        /// Возвращает enumerator для колекции
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            return _clusters.GetEnumerator();
        }
        #endregion
    }
}
