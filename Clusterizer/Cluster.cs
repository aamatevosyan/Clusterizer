using System;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Класс Кластер
    /// </summary>
    [Serializable]
    public class Cluster
    {
        #region Поля        
        /// <summary>
        /// Синглтог кластер реализованный как множество паттернов
        /// </summary>
        private HashSet<Pattern> _singletonCluster;
        /// <summary>
        /// Подкластеры(дети) кластера
        /// </summary>
        private HashSet<Cluster> _subClusters;
        /// <summary>
        /// Список всех паттернов кластера и его детей
        /// </summary>
        private List<Pattern> _patternList;
        #endregion

        #region Свойства        
        /// <summary>
        /// ID Кластера
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Количество паттернов в синглтон кластере
        /// </summary>
        public int QuantityOfPatterns => _singletonCluster.Count;
        /// <summary>
        /// Общее количество паттернов в кластере
        /// </summary>
        public int TotalQuantityOfPatterns { get; set; }
        /// <summary>
        /// Количество подкластеров кластера
        /// </summary>
        public int QuantityOfSubClusters => _subClusters.Count;
        #endregion


        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров <see cref="Cluster"/> class.
        /// </summary>
        public Cluster()
        {
            _singletonCluster = new HashSet<Pattern>();
            _subClusters = new HashSet<Cluster>();
        }
        #endregion

        #region Методы        
        /// <summary>
        /// Добавляет паттерн в синглтон кластер
        /// </summary>
        /// <param name="pattern">Паттерн</param>
        public void AddPattern(Pattern pattern)
        {
            _singletonCluster.Add(pattern);
        }
        /// <summary>
        /// Возвращает массив со всеми паттернами синглтон кластера
        /// </summary>
        public Pattern[] GetPatterns()
        {
            return _singletonCluster.ToArray<Pattern>();
        }
        /// <summary>
        /// Возвращает паттерн под заданым индексом в синглтон кластере
        /// </summary>
        /// <param name="index">Индекс</param>
        public Pattern GetPattern(int index)
        {
            return _singletonCluster.ElementAt(index);
        }
        /// <summary>
        /// Добавляет подкластер в кластер
        /// </summary>
        /// <param name="subCluster">The sub cluster.</param>
        public void AddSubCluster(Cluster subCluster)
        {
            _subClusters.Add(subCluster);
        }
        /// <summary>
        /// Возвращает массив подкластеров
        /// </summary>
        /// <returns></returns>
        public Cluster[] GetSubClusters()
        {
            return _subClusters.ToArray<Cluster>();
        }
        /// <summary>
        /// Возвращает подкластер под заданым индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        public Cluster GetSubCluster(int index)
        {
            return _subClusters.ElementAt(index);
        }

        public int UpdateTotalQuantityOfPatterns()
        {
            //if cluster has subclustes, then calculate how many patterns there is in each subcluster
            if (_subClusters.Count > 0)
            {
                TotalQuantityOfPatterns = 0;
                foreach (Cluster subcluster in this.GetSubClusters())
                    TotalQuantityOfPatterns = TotalQuantityOfPatterns + subcluster.UpdateTotalQuantityOfPatterns();
            }

            // if there is no subcluster, it is because is a singleton cluster (i.e., totalNumberOfPatterns = 1)
            return TotalQuantityOfPatterns;
        }
        /// <summary>
        /// Возвращает список со всеми паттернами кластера
        /// </summary>
        /// <returns></returns>
        public List<Pattern> GetAllPatterns()
        {
            _patternList = new List<Pattern>();
            if (QuantityOfSubClusters == 0)
                foreach (Pattern pattern in this.GetPatterns())
                    _patternList.Add(pattern);
            else
                foreach (Cluster subCluster in this.GetSubClusters())
                    _GetSubClusterPattern(subCluster);
   
            return _patternList;
        }
        /// <summary>
        /// Возвращает список со всеми паттернами подклассатера
        /// </summary>
        /// <returns></returns>
        private void _GetSubClusterPattern(Cluster subCluster)
        {
            if (subCluster.QuantityOfSubClusters == 0)
                foreach (Pattern pattern in subCluster.GetPatterns())
                    _patternList.Add(pattern);
            else
                foreach (Cluster _subCluster in subCluster.GetSubClusters())
                    _GetSubClusterPattern(_subCluster);
        }

        #endregion
    }
}
