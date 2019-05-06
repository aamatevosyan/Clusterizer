using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Класс реализующий алгоритм аггломеративной иерархической кластеризации
    /// </summary>
    public class Agnes
    {

        #region Поля        
        /// <summary>
        /// Матрица паттернов
        /// </summary>
        private PatternMatrix _patternMatrix;
        /// <summary>
        /// Кластеры
        /// </summary>
        private Clusters _clusters;
        /// <summary>
        /// Матрица различии
        /// </summary>
        private DissimilarityMatrix _dissimilarityMatrix;
        /// <summary>
        /// Мера расстояния
        /// </summary>
        private Distance.DistanceMetric _distanceMetric;
        /// <summary>
        /// Стратегия обьеденения
        /// </summary>
        private ClusterDistance.Strategy _strategy;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор класса <see cref="Agnes"/>.
        /// </summary>
        /// <param name="patternMatrix">Матрица паттернов</param>
        /// <param name="distanceMetric">Мера расстояния</param>
        /// <param name="strategy">Стратегия обьеденения</param>
        public Agnes(PatternMatrix patternMatrix, Distance.DistanceMetric distanceMetric, ClusterDistance.Strategy strategy)
        {
            _clusters = new Clusters();
            _patternMatrix = patternMatrix;
            this._distanceMetric = distanceMetric;
            this._strategy = strategy;
        }
        #endregion

        #region Методы

        /// <summary>
        /// Создает матрицу различии
        /// </summary>
        private void _BuildDissimilarityMatrix()
        {
            double distanceBetweenTwoClusters;
            _dissimilarityMatrix = new DissimilarityMatrix();

            ClusterPair clusterPair;

            for (int i = 0; i < _clusters.Count - 1; i++)
            {
                for (int j = i + 1; j < _clusters.Count; j++)
                {
                    clusterPair = new ClusterPair();
                    clusterPair.Cluster1 = _clusters.GetCluster(i);
                    clusterPair.Cluster2 = _clusters.GetCluster(j);

                    distanceBetweenTwoClusters = ClusterDistance.ComputeDistance(clusterPair.Cluster1, clusterPair.Cluster2, _distanceMetric);
                    _dissimilarityMatrix.AddClusterPairAndDistance(clusterPair, distanceBetweenTwoClusters);
                }
            }

            //Parallel.ForEach(_ClusterPairCollection(), clusterPair =>
            //{
            //    distanceBetweenTwoClusters = ClusterDistance.ComputeDistance(clusterPair.Cluster1, clusterPair.Cluster2, distanceMetric);
            //    _dissimilarityMatrix.AddClusterPairAndDistance(clusterPair, distanceBetweenTwoClusters);
            //});
        }

        //private IEnumerable<ClusterPair> _ClusterPairCollection()
        //{
        //    ClusterPair clusterPair;

        //    for (int i = 0; i < _clusters.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < _clusters.Count; j++)
        //        {
        //            clusterPair = new ClusterPair();
        //            clusterPair.Cluster1 = _clusters.GetCluster(i);
        //            clusterPair.Cluster2 = _clusters.GetCluster(j);

        //            yield return clusterPair;
        //        }
        //    }

        //}

        /// <summary>
        /// Создает список класстеров
        /// </summary>
        private void _BuildSingletonCluster()
        {
            _clusters.BuildSingletonCluster(_patternMatrix);
        }


        /// <summary>
        /// Обновляет матрицу различии при добавлении нового кластера
        /// </summary>
        /// <param name="newCluster">Новый кластер</param>
        /// <param name="_strategy">Стратегия</param>
        private void _UpdateDissimilarityMatrix(Cluster newCluster)
        {
            double distanceBetweenClusters;
            for (int i = 0; i < _clusters.Count; i++)
            {
                // compute the distance between old clusters to the new cluster
                distanceBetweenClusters = ClusterDistance.ComputeDistance(_clusters.GetCluster(i), newCluster, _dissimilarityMatrix, _strategy);
                // insert the new cluster's distance
                _dissimilarityMatrix.AddClusterPairAndDistance(new ClusterPair(newCluster, _clusters.GetCluster(i)), distanceBetweenClusters);
                //remove all old distance values of the old clusters (subclusters of the newcluster)
                _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(0), _clusters.GetCluster(i)));
                _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(1), _clusters.GetCluster(i)));
            }

            // finally, remove the distance of the old cluster pair
            _dissimilarityMatrix.RemoveClusterPair(new ClusterPair(newCluster.GetSubCluster(0), newCluster.GetSubCluster(1)));

        }

        /// <summary>
        /// Возвращает пару кластеров с минимальным растоянием
        /// </summary>
        /// <returns></returns>
        private ClusterPair _GetClosestClusterPairInDissimilarityMatrix()
        {
            return _dissimilarityMatrix.GetClosestClusterPair();
        }

        /// <summary>
        /// Выполняет кластеризацию
        /// </summary>
        /// <param name="indexNewCluster">Индекс нового кластера</param>
        /// <param name="k">Число выходных кластеров</param>
        private void BuildHierarchicalClustering(int indexNewCluster, int k)
        {

            ClusterPair closestClusterPair = this._GetClosestClusterPairInDissimilarityMatrix();

            // Создает новый кластер путем обьеденения пары кластеров с минимальным расстоянием
            Cluster newCluster = new Cluster();
            newCluster.AddSubCluster(closestClusterPair.Cluster1);
            newCluster.AddSubCluster(closestClusterPair.Cluster2);
            newCluster.Id = indexNewCluster;
            newCluster.UpdateTotalQuantityOfPatterns(); // Обновляет количество паттернов после обьеденения
     
            // Удаляет пару кластеров из матризы различии
            _clusters.RemoveClusterPair(closestClusterPair);
            _UpdateDissimilarityMatrix(newCluster);
            // Добавляет новый кластер к списку кластеров
            _clusters.AddCluster(newCluster);
            //closestClusterPair = null;

            // Остановка алгоритма (если выходное число кластеров равно k
            if (_clusters.Count > k)
                this.BuildHierarchicalClustering(indexNewCluster + 1, k);
        }


        /// <summary>
        /// Начальная точка алгоритмаы
        /// </summary>
        /// <param name="k">Число выходных кластеров</param>
        /// <returns></returns>
        public Clusters ExecuteClustering(int k)
        {

            // Шаг 1
            // Создает синглтон кластеры из матрицы паттернов так как в начале каждый паттерн является кластером
            this._BuildSingletonCluster();

            // Шаг 2
            // Создаем изначальную матрицу различии
            this._BuildDissimilarityMatrix();

            // Шаг 3
            // Выполняем кластеризацию 
            this.BuildHierarchicalClustering(_clusters.Count, k);

            return _clusters; // Возвращаем кластер
        }
        #endregion
    }
}
