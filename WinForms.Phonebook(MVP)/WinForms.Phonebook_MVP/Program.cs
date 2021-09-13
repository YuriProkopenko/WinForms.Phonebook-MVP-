using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Phonebook_MVP
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PhonebookView_Form1 view = new PhonebookView_Form1();
            IPhonebookModel model = new PhonebookModel();
            PhonebookPresenter presenter = new(model, view);
            Application.Run(view);
        }
    }
}
