using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Класс оболочки файла CSF
    /// </summary>
    [Serializable]
    class CSFContainer
    {
        /// <summary>
        /// Данные
        /// </summary>
        public CSVData Data { get; set; }
        /// <summary>
        /// Кластеры
        /// </summary>
        public Clusters Clusters { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="CSFContainer"/>.
        /// </summary>
        /// <param name="data">Данные</param>
        /// <param name="clusters">Кластеры</param>
        public CSFContainer(CSVData data, Clusters clusters)
        {
            Data = data;
            Clusters = clusters;
        }
    }
}
