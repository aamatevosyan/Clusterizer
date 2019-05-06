using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Класс для представления строки данных
    /// </summary>
    [Serializable]
    class CSVRow
    {
        /// <summary>
        /// Данные
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// Конструктор класса <see cref="CSVRow"/>.
        /// </summary>
        /// <param name="fields">Данные</param>
        public CSVRow(List<string> fields)
        {
            Fields = fields;
        }
    }
}
