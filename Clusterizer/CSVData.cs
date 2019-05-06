using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clusterizer
{
    /// <summary>
    /// Класс данных
    /// </summary>
    /// <seealso cref="System.ICloneable" />
    [Serializable]
    class CSVData : ICloneable
    {
        #region Свойства        
        /// <summary>
        /// Количество полей
        /// </summary>
        public int FieldsCount => Headings.Length;
        /// <summary>
        /// Строки
        /// </summary>
        public List<CSVRow> Rows { get; set; }
        /// <summary>
        /// Заголовки
        /// </summary>
        public string[] Headings { get; set; }
        /// <summary>
        /// Строковые столбцы
        /// </summary>
        public string[] StringHeadings { get; set; }
        /// <summary>
        /// Столбцы показателей
        /// </summary>
        public string[] NumericHeadings { get; set; }
        /// <summary>
        /// Массив значении
        /// </summary>
        public bool[] IsRealValue { get; set; }
        /// <summary>
        /// Таблица данных
        /// </summary>
        public DataTable DataSetTable;
        /// <summary>
        /// Путь файла
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Стэк данных
        /// </summary>
        public Stack<List<CSVRow>> BackupedRows;
        /// <summary>
        /// Максимальный размер стэка
        /// </summary>
        const int MaxBackupCount = 15;
        #endregion

        #region Конструктор        
        /// <summary>
        /// Конструктор без параметров класса <see cref="CSVData"/>.
        /// </summary>
        public CSVData()
        {
            Rows = new List<CSVRow>();
            DataSetTable = new DataTable();
            BackupedRows = new Stack<List<CSVRow>>();
        }
        #endregion

        /// <summary>
        /// Задает заголовки показателей
        /// </summary>
        public void SetPointsHeadings()
        {
            List<string> points = new List<string>();
            for (int i = 0; i < IsRealValue.Length; i++)
            {
                if (IsRealValue[i])
                    points.Add(Headings[i]);
            }

            NumericHeadings = points.ToArray();
        }

        /// <summary>
        /// Задает строковые показатели
        /// </summary>
        public void SetNamedHeadings()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Headings.Length; i++)
                if (!IsRealValue[i])
                    list.Add(Headings[i]);
            StringHeadings = list.ToArray();
        }

        /// <summary>
        /// Создает матрицу паттернов
        /// </summary>
        /// <param name="isChosen">Выбранные показатели</param>
        public PatternMatrix GetPatternMatrix(bool[] isChosen)
        {
            PatternMatrix _patternMatrix = new PatternMatrix();
            Pattern _pattern;
            int _patternIndex = 0;

            for (int i = 0; i < Rows.Count; i++)
            {
                _pattern = new Pattern();
                _pattern.Id = i;
                for (int j = 0; j < Rows[i].Fields.Count; j++)
                    if (IsRealValue[j])
                    {
                        int startIndex = j;
                        for (; j < Rows[i].Fields.Count; j++)
                        {
                            if (isChosen[j - startIndex])
                                _pattern.Add(double.Parse(Rows[i].Fields[j]));
                        }
                        //_pattern.Add(double.Parse(Rows[i].fields[j]));
                    }

                _patternMatrix.AddPattern(_pattern);
            }

            return _patternMatrix;
        }

        /// <summary>
        /// Задает заголовки
        /// </summary>
        /// <param name="line">Строка</param>
        public void SetHeadingsFromLine(string line)
        {
            var headings = line.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(new char[] {' ', '\"'})).ToArray();
            Headings = headings;
        }

        /// <summary>
        /// Получает Row
        /// </summary>
        /// <param name="line">Строка</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException">Исходный файл некорректен</exception>
        public CSVRow GetRowFromLine(string line)
        {
            var fields = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim(new char[] { ' ', '\"' })).ToList();
            if (fields.Count != FieldsCount)
                throw new InvalidDataException("Исходный файл некорректен");
            CSVRow csvRow = new CSVRow(fields);
            return csvRow;
        }

        /// <summary>
        /// Получает строку Row
        /// </summary>
        /// <param name="csvRow">Row</param>
        /// <returns></returns>
        public string GetCSVLineFromRow(CSVRow csvRow)
        {
            return string.Join(";", csvRow.Fields);
        }

        /// <summary>
        /// Получает строку заголовок
        /// </summary>
        /// <returns></returns>
        public string GetCSVLineFromHeadings()
        {
            return string.Join(";", Headings);
        }

        /// <summary>
        /// Резервирует Rows
        /// </summary>
        public void BackupRows()
        {
            if (BackupedRows.Count != MaxBackupCount)
            {
                BackupedRows.Push(Rows.GetRange(0, Rows.Count));
            }
        }

        /// <summary>
        /// Востанавливает Rows
        /// </summary>
        public void RestoreRows()
        {
            if (BackupedRows.Count != 0)
            {
                Rows = BackupedRows.Peek();
                BackupedRows.Pop();
                UpdateData();
            }
        }

        /// <summary>
        /// Обнавляет Rows
        /// </summary>
        public void UpdateRows()
        {
            Rows.Clear();
            List<string> fieldList;
            foreach (DataRow row in DataSetTable.Rows)
            {
                fieldList = new List<string>();
                for (int i = 0; i < row.ItemArray.Length; i++)
                    fieldList.Add(row[i].ToString());
                Rows.Add(new CSVRow(fieldList));
            }
            Console.WriteLine(Rows.Count);
        }

        /// <summary>
        /// Сортирует значения по столбцу
        /// </summary>
        /// <param name="index">Индекс</param>
        public void Sort(int index)
        {
            BackupRows();
            var sorted = Rows.OrderBy(row => row.Fields[index]);
            Rows = sorted.ToList();
            UpdateData();
        }

        /// <summary>
        /// Фильтрует стоблцы
        /// </summary>
        /// <param name="expression">Значения</param>
        /// <param name="index">Индекс</param>
        public void Filter(string expression, int index)
        {
            BackupRows();
            var filtered = Rows.FindAll(row => row.Fields[index].Contains(expression));
            Rows = filtered.ToList();
            UpdateData();
        }

        /// <summary>
        /// Создает заголовки столбцов
        /// </summary>
        public void CreateDataTableColumns()
        {
            Type type;
            for (int i = 0; i < FieldsCount; i++)
            {
                type = (IsRealValue[i]) ? typeof(double) : typeof(string);
                DataSetTable.Columns.Add(Headings[i], type);
            }
        }

        /// <summary>
        /// Создает таблицу данных
        /// </summary>
        public void CreateDataTable()
        {
            DataSetTable = new DataTable();
            CreateDataTableColumns();
            UpdateData();
        }

        /// <summary>
        /// Обновляет данные
        /// </summary>
        public void UpdateData()
        {
            DataSetTable.Clear();
            foreach (var row in Rows)
            {
                DataSetTable.Rows.Add(row.Fields.ToArray());
            }
        }

        /// <summary>
        /// Читает из файла
        /// </summary>
        /// <param name="filePath">Путь файла</param>
        /// <returns></returns>
        public static CSVData ReadFromCSV(string filePath)
        {
            CSVData data = new CSVData();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                data.FilePath = filePath;
                StreamReader streamReader = new StreamReader(fileStream);
                string line;
                data.SetHeadingsFromLine(streamReader.ReadLine());
                while ((line = streamReader.ReadLine()) != null && line != "")
                {
                    data.Rows.Add(data.GetRowFromLine(line));
                }
            }

            return data;
        }

        /// <summary>
        /// Сохраняет в файл
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="filePath">The file path.</param>
        public static void SaveToCSV(CSVData data, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                StreamWriter streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(data.GetCSVLineFromHeadings());
                streamWriter.AutoFlush = true;
                foreach (var row in data.Rows)
                {
                    streamWriter.WriteLine(data.GetCSVLineFromRow(row));
                }
            }
        }

        /// <summary>
        /// Клонирует класс
        /// </summary>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
