using System;
using System.Collections.Generic;

namespace Clusterizer
{
    /// <summary>
    /// Data structure for presenting pair of clusters
    /// </summary>
    public class ClusterPair
    {

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterPair"/> class.
        /// </summary>
        /// <param name="cluster1">The cluster1.</param>
        /// <param name="cluster2">The cluster2.</param>
        /// <exception cref="ArgumentNullException">
        /// cluster1
        /// or
        /// cluster2
        /// </exception>
        public ClusterPair(Cluster cluster1, Cluster cluster2)
        {

            if (cluster1 == null)
                throw new ArgumentNullException("cluster1");

            if (cluster2 == null)
                throw new ArgumentNullException("cluster2");

            this.Cluster1 = cluster1;
            this.Cluster2 = cluster2;
        }
        #endregion

        #region Properties        
        /// <summary>
        /// Gets or sets the cluster1.
        /// </summary>
        /// <value>
        /// The cluster1.
        /// </value>
        public Cluster Cluster1 { get; set; }

        /// <summary>
        /// Gets or sets the cluster2.
        /// </summary>
        /// <value>
        /// The cluster2.
        /// </value>
        public Cluster Cluster2 { get; set; }

        #endregion

        #region EqualityComparer        
        /// <summary>
        /// EqualityComparer for class ClusterPair
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEqualityComparer{Clusterizer.ClusterPair}" />
        public class EqualityComparer : IEqualityComparer<ClusterPair>
        {  
            // As ClusterPair is defined class, we need to specify its equality for using in Dictionary as keys

            /// <summary>
            /// Determines whether the specified objects are equal.
            /// </summary>
            /// <param name="x">The first object of type <paramref name="T" /> to compare.</param>
            /// <param name="y">The second object of type <paramref name="T" /> to compare.</param>
            /// <returns>
            ///   <see langword="true" /> if the specified objects are equal; otherwise, <see langword="false" />.
            /// </returns>
            public bool Equals(ClusterPair x, ClusterPair y)
            {
                return x.Cluster1.ID == y.Cluster1.ID && x.Cluster2.ID == y.Cluster2.ID;
            }

            /// <summary>
            /// Returns a hash code for this instance.
            /// </summary>
            /// <param name="x">The x.</param>
            /// <returns>
            /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ClusterPair x)
            {
                return x.Cluster1.ID ^ x.Cluster2.ID;
            }
        }
        #endregion

    }
}
