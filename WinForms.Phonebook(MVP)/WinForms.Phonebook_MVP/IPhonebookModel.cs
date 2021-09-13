using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Phonebook_MVP
{
    public interface IPhonebookModel
    {
        public List<Contact> Contacts { get; set; }
        string SaveFileName { get; set; }
        string OpenFileName { get; set; }

        public void Save() { }
        public void Load() { }
    }
}
