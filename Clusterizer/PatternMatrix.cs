using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Класс матрицы паттернов
    /// </summary>
    /// <seealso cref="System.Collections.IEnumerable" />
    public class PatternMatrix : IEnumerable
    {
        #region Поля
        /// <summary>
        /// Множество паттернов
        /// </summary>
        private HashSet<Pattern> _patternCollection;
        #endregion

        #region Свойства        
        /// <summary>
        /// Количество паттернов
        /// </summary>
        public int Count => _patternCollection.Count;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="PatternMatrix"/>.
        /// </summary>
        public PatternMatrix()
        {
            _patternCollection = new HashSet<Pattern>();
        }
        #endregion

        #region Методы        
        /// <summary>
        /// Добавляет паттерн в множество
        /// </summary>
        /// <param name="pattern">Паттерн</param>
        public void AddPattern(Pattern pattern)
        {
            _patternCollection.Add(pattern);
        }

        /// <summary>
        /// Возвращает массив паттернов
        /// </summary>
        public Pattern[] GetPatterns()
        {
            return _patternCollection.ToArray<Pattern>();
        }

        /// <summary>
        /// Возвращает паттерн под заданым индексом 
        /// </summary>
        /// <param name="index">The index.</param>
        public Pattern GetPattern(int index)
        {
            return _patternCollection.ElementAt(index);
        }

        /// <summary>
        /// Возвращает enumerator для интерфейса IEnumerable
        /// </summary>
        /// <returns>
        public IEnumerator GetEnumerator()
        {
            return _patternCollection.GetEnumerator();
        }
        #endregion
    }
}
