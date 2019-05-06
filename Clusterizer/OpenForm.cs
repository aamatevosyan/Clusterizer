using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{
    /// <summary>
    /// Класс для открытия файла
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class OpenForm : Form
    {
        /// <summary>
        /// Данные
        /// </summary>
        internal CSVData data { get; set; }

        /// <summary>
        /// Конструктор без параметров класса <see cref="OpenForm"/>.
        /// </summary>
        public OpenForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действие при нажатии на кнопку browseButton
        /// </summary>
        /// <param name="sender">Сама конпка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Открыть файл";
                openFileDialog.Filter = "CSV File(*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    filePathtextBox.Text = filePath;
                    data = CSVData.ReadFromCSV(filePath);
                    foreach (var heading in data.Headings)
                    {
                        checkedListBox.Items.Add(heading, true);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при имспорте файла. Проверьте корректность файла.", "Ошибка импорта.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Действие при нажатии на кнопку openButton
        /// </summary>
        /// <param name="sender">Сама конпка</param>
        /// <param name="e">Аргумент события <see cref="EventArgs"/></param>
        private void openButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (data != null)
                {
                    data.IsRealValue = new bool[data.FieldsCount];
                    for (int i = 0; i < data.FieldsCount; i++)
                        data.IsRealValue[i] = (checkedListBox.GetItemChecked(i));
                    data.SetPointsHeadings();
                    data.SetNamedHeadings();
                    data.CreateDataTable();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при обработке файла. Проверьте корректность выбранных показателей.", "Ошибка импорта.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
