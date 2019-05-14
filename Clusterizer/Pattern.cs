using System;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{   
    /// <summary>
    /// Класс для хранения множества точек  
    /// </summary>
    [Serializable]
    public class Pattern
    {

        #region Поля        
        /// <summary>
        /// Список точек
        /// </summary>
        private List<double> _points;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров для класса <see cref="Pattern"/>.
        /// </summary>
        public Pattern()
        {
            _points = new List<double>();
        }

        /// <summary>
        /// Конструктор класса <see cref="Pattern"/> class.
        /// </summary>
        /// <param name="points">Точки</param>
        public Pattern(List<double> points)
        {
            _points = points;
        }
        #endregion

        #region Свойства        
        /// <summary>
        /// Id паттерна
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Количество точек
        /// </summary>
        public int Count => _points.Count;
        #endregion

        #region Методы        
        /// <summary>
        /// Добавляет точку в множество
        /// </summary>
        /// <param name="point">Точка</param>
        public void Add(double point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// Удаляет точку с заданым индексом
        /// </summary>
        /// <param name="i">Индекс</param>
        public void RemovePointAt(int index)
        {
            _points.RemoveAt(index);
        }

        /// <summary>
        /// Возвращает точку с заданым индексом
        /// </summary>
        /// <param name="index">Индекс</param>
        public double GetPoint(int index)
        {
            return _points[index];
        }

        /// <summary>
        /// Добавляет множество точек
        /// </summary>
        /// <param name="points">Точки</param>
        public void AddAttributes(double[] points)
        {
            _points.AddRange(points);
        }

        /// <summary>
        /// Возвращает массив точек
        /// </summary>
        public double[] GetPoints()
        {
            return _points.ToArray<double>();
        }
        #endregion

    }
}
