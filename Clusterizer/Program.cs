using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clusterizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is CustomException)
            {
                var exception = (CustomException)e.Exception;
                MessageBox.Show(exception.Text, exception.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var exception = e.Exception;
                MessageBox.Show(exception.Message, "Ошибка во время выполнения программы", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the UnhandledException event of the CurrentDomain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is CustomException)
            {
                var exception = (CustomException) e.ExceptionObject;
                MessageBox.Show(exception.Text, exception.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var exception = (Exception) e.ExceptionObject;
                MessageBox.Show(exception.Message, "Ошибка во время выполнения программы", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
