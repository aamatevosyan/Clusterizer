using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for one line of CSV File
    /// </summary>
    class CSVRow
    {
        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public List<string> Fields { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVRow"/> class.
        /// </summary>
        /// <param name="fields">The fields.</param>
        public CSVRow(List<string> fields)
        {
            Fields = fields;
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="System.String"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns>Field with specified index.</returns>
        public string this[int index]
        {
            get => Fields[index];
            set => Fields[index] = value;
        }
    }
}
