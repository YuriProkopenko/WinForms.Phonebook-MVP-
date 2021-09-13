using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Phonebook_MVP
{
    public interface IPhonebookView
    {
        public string[] valueName { get; set; }
        public string[] Surname { get; set; }
        public string[] Phone { get; set; }
        public string[] Adress { get; set; }
        public string SaveFileName { get; set; }
        public string OpenFileName { get; set; }
        public event EventHandler<EventArgs> PhonebookViewOpen;
        public event EventHandler<EventArgs> PhonebookViewSave;
        public event EventHandler<EventArgs> FillListView;
        public event EventHandler<EventArgs> FillModel;
    }
}
