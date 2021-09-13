using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Phonebook_MVP
{
    public class PhonebookModel : IPhonebookModel
    {
        List<Contact> contacts = new List<Contact>();
        public string SaveFileName { get; set; }
        public string OpenFileName { get; set; }
        public List<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

        public void Save()
        {
            try
            {
                FileStream stream = new FileStream(SaveFileName, FileMode.Create, FileAccess.Write);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Contact>));
                jsonFormatter.WriteObject(stream, contacts);
                stream.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Load()
        {
            try
            {
                FileStream stream = new FileStream(OpenFileName, FileMode.Open, FileAccess.Read);
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Contact>));
                contacts = (List<Contact>)jsonFormatter.ReadObject(stream);
                stream.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
