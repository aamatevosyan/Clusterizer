using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Clusterizer
{
    /// <summary>
    /// Class for working with input data
    /// </summary>
    public class CSVData
    {
        #region Свойства        

        /// <summary>
        /// Gets the fields count.
        /// </summary>
        /// <value>
        /// The fields count.
        /// </value>
        public int FieldsCount => StringHeadings.Length + NumericHeadings.Length;

        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public List<CSVRow> Rows { get; set; }

        /// <summary>
        ///     Строковые столбцы
        /// </summary>
        public string[] StringHeadings { get; set; }

        /// <summary>
        /// Gets or sets the numeric headings.
        /// </summary>
        /// <value>
        /// The numeric headings.
        /// </value>
        public string[] NumericHeadings { get; set; }

        /// <summary>
        /// The data set table
        /// </summary>
        public DataTable DataSetTable;

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string FilePath { get; set; }

        /// <summary>
        /// The undo stack
        /// </summary>
        public Stack<List<CSVRow>> UndoStack;

        /// <summary>
        /// The redo stack
        /// </summary>
        public Stack<List<CSVRow>> RedoStack;

        /// <summary>
        /// The maximum stack count
        /// </summary>
        private const int MaxStackCount = 30;

        #endregion

        #region Constructor                        
        /// <summary>
        /// Initializes a new instance of the <see cref="CSVData"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public CSVData(string filePath)
        {
            // initializes main components
            FilePath = filePath;
            Rows = new List<CSVRow>();
            DataSetTable = new DataTable();
            UndoStack = new Stack<List<CSVRow>>();
            RedoStack = new Stack<List<CSVRow>>();
            StringHeadings = Tools.StringDataHeadings;
            NumericHeadings = Tools.NumericDataHeadings;

            // load data from file
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var streamReader = new StreamReader(fileStream);
                string line;
                // adds single line data to rows
                while ((line = streamReader.ReadLine()) != null && line != "") Rows.Add(GetRowFromLine(line));
            }
        }

        #endregion

        #region Methods        
        /// <summary>
        /// Generates cluster set using selected datapoints
        /// </summary>
        /// <param name="isChosen">Is datapoint is chosen</param>
        /// <returns></returns>
        public ClusterSet GetClusterSet(bool[] isChosen)
        {
            var clusterSet = new ClusterSet();

            // generates datapoint
            for (var i = 0; i < Rows.Count; i++)
            {
                var dataPoint = new DataPoint {Id = i};
                // gets all points of datapoint
                for (var j = StringHeadings.Length; j < FieldsCount; j++)
                    dataPoint.Add(double.Parse(Rows[i][j]));

                // new cluster
                var cluster = new Cluster {Id = i};
                cluster.AddDataPoint(dataPoint);
                cluster.SetCentroid();

                // add to set
                clusterSet.AddCluster(cluster);
            }

            return clusterSet;
        }

        /// <summary>
        /// Gets the row from line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public CSVRow GetRowFromLine(string line)
        {
            // gets all fields from line
            var fields = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(' ', '\"'))
                .ToList();
            // checks for correctness
            if (fields.Count != FieldsCount)
                throw new InvalidDataException();
            var csvRow = new CSVRow(fields);
            return csvRow;
        }

        /// <summary>
        /// Gets the CSV line from row.
        /// </summary>
        /// <param name="csvRow">The CSV row.</param>
        /// <returns></returns>
        public string GetCsvLineFromRow(CSVRow csvRow)
        {
            return string.Join(";", csvRow.Fields);
        }

        /// <summary>
        /// Updates the rows.
        /// </summary>
        public void UpdateRows()
        {
            Rows.Clear();
            foreach (DataRow row in DataSetTable.Rows)
            {
                var fieldList = new List<string>();
                for (var i = 0; i < row.ItemArray.Length; i++)
                    fieldList.Add(row[i].ToString());
                Rows.Add(new CSVRow(fieldList));
            }
        }

        /// <summary>
        /// Creates the data table columns.
        /// </summary>
        public void CreateDataTableColumns()
        {
            foreach (var heading in StringHeadings)
                DataSetTable.Columns.Add(heading, typeof(string));

            foreach (var numericHeading in NumericHeadings)
                DataSetTable.Columns.Add(numericHeading, typeof(double));
        }

        /// <summary>
        /// Creates the data table.
        /// </summary>
        public void CreateDataTable()
        {
            DataSetTable = new DataTable();
            CreateDataTableColumns();
            UpdateData();
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        public void UpdateData()
        {
            DataSetTable.Clear();
            foreach (var row in Rows) DataSetTable.Rows.Add(row.Fields.ToArray());
        }

        /// <summary>
        /// Gets the chosen data point names.
        /// </summary>
        /// <param name="isChosen">The is chosen.</param>
        /// <returns></returns>
        public string[] GetChosenDataPointNames(bool[] isChosen)
        {
            var tmpList = new List<string>();
            for (var i = 0; i < isChosen.Length; i++)
                if (isChosen[i])
                    tmpList.Add(NumericHeadings[i]);
            return tmpList.ToArray();
        }

        /// <summary>
        /// Saves data to CSV file.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="filePath">The file path.</param>
        public static void SaveToCsv(CSVData data, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                var streamWriter = new StreamWriter(fileStream);
                foreach (var row in data.Rows) streamWriter.WriteLine(data.GetCsvLineFromRow(row));
                streamWriter.Flush();
            }
        }


        /// <summary>
        /// Sorts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="isAscending">if set to <c>true</c> [is ascending].</param>
        public void Sort(int index, bool isAscending)
        {
            SaveToStack();
            IEnumerable<CSVRow> sorted = isAscending ? Rows.OrderBy(row => row.Fields[index]) : Rows.OrderByDescending(row => row.Fields[index]);

            Rows = sorted.ToList();
            UpdateData();
        }

        /// <summary>
        /// Filters the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="index">The index.</param>
        /// <param name="selectedOperation">The selected operation.</param>
        public void Filter(string expression, int index, int selectedOperation)
        {
            SaveToStack();
            List<CSVRow> filteredList;
            switch (selectedOperation)
            {
                case 0:
                    filteredList = Rows.FindAll(row => row.Fields[index].Contains(expression));
                    break;
                case 1:
                    filteredList = Rows.FindAll(row => double.Parse(row.Fields[index]) >= double.Parse(expression));
                    break;
                case 2:
                    filteredList = Rows.FindAll(row => double.Parse(row.Fields[index]) <= double.Parse(expression));
                    break;
                case 3:
                    filteredList = Rows.FindAll(row => double.Parse(row.Fields[index]) > double.Parse(expression));
                    break;
                default:
                    filteredList = Rows.FindAll(row => double.Parse(row.Fields[index]) < double.Parse(expression));
                    break;
            }

            Rows = filteredList;
            UpdateData();
        }

        /// <summary>
        /// Redoes this instance.
        /// </summary>
        public void Redo()
        {
            if (RedoStack.Count != 0 && UndoStack.Count < MaxStackCount)
            {
                UndoStack.Push(Rows.GetRange(0, Rows.Count));
                Rows = RedoStack.Pop();
                UpdateData();
            }
        }

        /// <summary>
        /// Undoes this instance.
        /// </summary>
        public void Undo()
        {
            if (UndoStack.Count != 0 && RedoStack.Count < MaxStackCount)
            {
                RedoStack.Push(Rows.GetRange(0, Rows.Count));
                Rows = UndoStack.Pop();
                UpdateData();
            }
        }

        /// <summary>
        /// Saves to stack.
        /// </summary>
        public void SaveToStack()
        {
            if (UndoStack.Count < MaxStackCount)
            {
                RedoStack.Clear();
                UndoStack.Push(Rows.GetRange(0, Rows.Count));
            }
        }

        #endregion
   
    }
}