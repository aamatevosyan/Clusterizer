using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for storing data file configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The string headings
        /// </summary>
        public string[] StringHeadings;
        /// <summary>
        /// The numeric headings
        /// </summary>
        public string[] NumericHeadings;
        /// <summary>
        /// The group names
        /// </summary>
        public string[] GroupNames;
        /// <summary>
        /// The group items count
        /// </summary>
        public int[] GroupItemsCount;
    }
}
