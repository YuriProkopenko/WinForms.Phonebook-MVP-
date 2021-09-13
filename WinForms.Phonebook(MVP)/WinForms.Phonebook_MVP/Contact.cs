using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WinForms.Phonebook_MVP
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Adress { get; set; }
    }
}
