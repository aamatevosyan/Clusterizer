using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Clusterizer
{
    /// <summary>
    /// Static class for app wide used settings, methods and data
    /// </summary>
    public static class Tools
    {
        #region User-Defined Data

        /// <summary>
        /// The string data headings
        /// </summary>
        public static string[] StringDataHeadings;

        /// <summary>
        /// The numeric data headings
        /// </summary>
        public static string[] NumericDataHeadings;

        /// <summary>
        /// The group names
        /// </summary>
        public static string[] GroupNames;

        /// <summary>
        /// The group items count
        /// </summary>
        public static int[] GroupItemsCount;
        #endregion

        #region App Data        
        /// <summary>
        /// The group items names
        /// </summary>
        public static string[][] GroupItemsNames;

        /// <summary>
        /// The group items indexes
        /// </summary>
        public static int[][] GroupItemsIndexes;

        /// <summary>
        /// The is chosen
        /// </summary>
        public static bool[] isChosen;

        /// <summary>
        /// The data
        /// </summary>
        public static CSVData Data;

        /// <summary>
        /// The clusters
        /// </summary>
        public static ClusterSet Clusters;
        #endregion

        #region Methods        
        /// <summary>
        /// Minimums-maximum normalization.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public static void MinMaxNormalize(ref double[] arr)
        {
            var max = arr.Max();
            var min = arr.Min();

            for (var i = 0; i < arr.Length; i++)
                arr[i] = (arr[i] - min) / (max - min);
        }

        /// <summary>
        /// Z-Score normalization.
        /// </summary>
        /// <param name="arr">The arr.</param>
        public static void ZScoreNormalize(ref double[] arr)
        {
            var mean = arr.Sum() / arr.Length;
            double bigSum = 0;
            foreach (var d in arr) bigSum += Math.Pow(d - mean, 2);

            var standartDeviation = Math.Sqrt(bigSum / (arr.Length - 1));

            for (var i = 0; i < arr.Length; i++)
                arr[i] = (arr[i] - mean) / standartDeviation;
        }

        /// <summary>
        /// Gets the standart deviation.
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>Standart deviation of given points</returns>
        public static double GetStandartDeviation(double[] points)
        {
            var max = points.Max();
            var min = points.Min();
            var avg = (max + min) / 2;
            double sum = 0;
            foreach (var point in points) sum += Math.Pow(point - avg, 2);

            return Math.Sqrt(sum / (points.Length - 1));
        }

        /// <summary>
        /// Groups sequence of points to three subsequences using minimal difference in standart deviation
        /// </summary>
        /// <param name="points">The points.</param>
        /// <returns>Grouped indexes</returns>
        public static int[] GroupBy(double[] points)
        {
            // group indexes
            var groupIds = new int[points.Length];
            var newPoints = points;
            MinMaxNormalize(ref newPoints);

            var min = double.MaxValue;
            int mi = 1, mj = newPoints.Length - 2;

            // custom cases
            if (points.Length == 1)
            {
                groupIds[0] = 1;
            }
            else if (points.Length == 2)
            {
                groupIds[0] = 1;
                groupIds[1] = 2;
            }
            else if (points.Length == 3)
            {
                groupIds[0] = 1;
                groupIds[1] = 2;
                groupIds[2] = 3;
            }
            else
            {
                // overall case
                for (var i = 1; i < newPoints.Length - 2; i++)
                    for (var j = i + 1; j < newPoints.Length - 1; j++)
                    {
                        // get all posible three subsequences
                        var one = newPoints.Slice(0, i);
                        var two = newPoints.Slice(i, j);
                        var three = newPoints.Slice(j, newPoints.Length);

                        // compute sum of standart deviations
                        var avg = GetStandartDeviation(one) + GetStandartDeviation(two) + GetStandartDeviation(three);
                        // get minimum one
                        if (avg < min)
                        {
                            min = avg;
                            mi = i;
                            mj = j;
                        }
                    }

                // setting group ids
                for (var i = 0; i < newPoints.Length; i++)
                    if (i < mi)
                        groupIds[i] = 1;
                    else if (i >= mi && i < mj)
                        groupIds[i] = 2;
                    else
                        groupIds[i] = 3;
            }

            return groupIds;
        }

        /// <summary>
        /// Slices array from the specified index to other index.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr">The arr.</param>
        /// <param name="indexFrom">The index from.</param>
        /// <param name="indexTo">The index to.</param>
        /// <returns>Sliced array</returns>
        public static T[] Slice<T>(this T[] arr, int indexFrom, int indexTo)
        {
            var length = indexTo - indexFrom;
            var result = new T[length];
            Array.Copy(arr, indexFrom, result, 0, length);

            return result;
        }

        /// <summary>
        /// Saves current settings to config file.
        /// </summary>
        public static void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
            Configuration configuration = new Configuration();
            configuration.StringHeadings = StringDataHeadings;
            configuration.NumericHeadings = NumericDataHeadings;
            configuration.GroupNames = GroupNames;
            configuration.GroupItemsCount = GroupItemsCount;
            xmlSerializer.Serialize(new FileStream("dataconfig.xml", FileMode.Create), configuration);
        }

        /// <summary>
        /// Loads current settings from config file
        /// </summary>
        /// <exception cref="Clusterizer.CustomException">Конфигурационный файл dataconfig.xml поврежден. - Произошла ошибка при чтении конфигурационного файла.</exception>
        public static void Load()
        {
            try
            {
                using (FileStream fileStream = new FileStream("dataconfig.xml", FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                    Configuration configuration = (Configuration) xmlSerializer.Deserialize(fileStream);
                    Tools.StringDataHeadings = configuration.StringHeadings;
                    Tools.NumericDataHeadings = configuration.NumericHeadings;
                    Tools.GroupNames = configuration.GroupNames;
                    Tools.GroupItemsCount = configuration.GroupItemsCount;

                    // Generates group Items
                    var groupCount = GroupNames.Length;
                    GroupItemsNames = new string[groupCount][];
                    GroupItemsIndexes = new int[groupCount][];

                    var ind = 0;
                    for (var i = 0; i < groupCount; i++)
                    {
                        var count = GroupItemsCount[i];
                        GroupItemsNames[i] = new string[count];
                        GroupItemsIndexes[i] = new int[count];
                        for (var j = 0; j < count; j++)
                        {
                            GroupItemsIndexes[i][j] = ind;
                            GroupItemsNames[i][j] = NumericDataHeadings[ind];
                            ind++;
                        }
                    }
                }
                    
            }
            catch
            {
                throw new CustomException("Конфигурационный файл dataconfig.xml поврежден.","Произошла ошибка при чтении конфигурационного файла.");
            }
        }
        #endregion

    }
}