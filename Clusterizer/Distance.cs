using System;

namespace Clusterizer
{
    public static class Distance
    {
        #region DistanceMetric        
        /// <summary>
        /// Меры расстояний
        /// </summary>
        public enum DistanceMetric
        {
            EuclidianDistance, // Евклидово расстояние
            SquareEuclidianDistance, // Квадрат евклидова расстояния
            ManhattanDistance, // Расстояние городских кварталов (манхэттенское расстояние)
            ChebyshevDistance // Расстояние Чебышева
        }


        #endregion
        #region Методы
        //double GetDistance(double[] x, double[] y);

        /// <summary>
        /// Возвращает растояение между точками X и Y
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="distanceMetric">Мера расстояния</param>
        /// <exception cref="ArgumentException">Неравное колличество точек.</exception>
        public static double GetDistance(double[] x, double[] y, DistanceMetric distanceMetric)
        {
            double distance = 0;
            double diff = 0;

            if (x.Length != y.Length)
                throw new ArgumentException("Неравное колличество точек.");

            switch (distanceMetric)
            {
                case DistanceMetric.EuclidianDistance:
                    for (int i = 0; i < x.Length; i++)
                    {
                        diff = x[i] - y[i];
                        distance += diff * diff;
                    }
                    distance = Math.Sqrt(distance);
                    break;
                case DistanceMetric.SquareEuclidianDistance:
                    for (int i = 0; i < x.Length; i++)
                    {
                        diff = x[i] - y[i];
                        distance += diff * diff;
                    }
                    break;
                case DistanceMetric.ManhattanDistance:
                    for (int i = 0; i < x.Length; i++)
                    {
                        diff = x[i] - y[i];
                        distance += Math.Abs(diff);
                    }
                    break;
                case DistanceMetric.ChebyshevDistance:
                    for (int i = 0; i < x.Length; i++)
                    {
                        diff = x[i] - y[i];
                        distance = (distance > diff) ? distance : diff;
                    }
                    break;
            }

            return distance;
        }

        /// <summary>
        /// Возвращает растояение между двумя паттернами
        /// </summary>
        /// <param name="pattern1">Первый паттерн</param>
        /// <param name="pattern2">Второй паттерн</param>
        /// <param name="distanceMetric">Мера расстояния</param>
        /// <returns></returns>
        public static double GetDistance(Pattern pattern1, Pattern pattern2, DistanceMetric distanceMetric)
        {
            return GetDistance(pattern1.GetPoints(), pattern2.GetPoints(), distanceMetric);
        }
        #endregion
    }
}
