using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Phonebook_MVP
{
    public class PhonebookPresenter
    {
        public string[] Name { get; set; }
        public string[] Surname { get; set; }
        public string[] Phone { get; set; }
        public string[] Adress { get; set; }
        private readonly IPhonebookModel model;
        private readonly IPhonebookView view;

        public PhonebookPresenter(IPhonebookModel _model, IPhonebookView _view)
        {
            model = _model;
            view = _view;
            view.PhonebookViewOpen += new EventHandler<EventArgs>(getFromBase);
            view.PhonebookViewSave += new EventHandler<EventArgs>(setToBase);
            view.FillListView += new EventHandler<EventArgs>(updateView);
            view.FillModel += new EventHandler<EventArgs>(updateModel);
        }

        private void getFromBase(object sender, EventArgs e)
        {
            model.OpenFileName = view.OpenFileName;
            model.Load();
        }

        private void setToBase(object sender, EventArgs e)
        {
            List<Contact> toModel = new List<Contact>();
            for(int i = 0; i < view.valueName.Length; i++)
            {
                Contact contact = new();
                contact.Name = view.valueName[i];
                contact.Surname = view.Surname[i];
                contact.Phone = view.Phone[i];
                contact.Adress = view.Adress[i];
                toModel.Add(contact);
            }
            model.SaveFileName = view.SaveFileName;
            model.Contacts = toModel;
            model.Save();
        }
        private void updateView(object sender, EventArgs e)
        {
            if (model.Contacts != null)
            {
                Name = new string[model.Contacts.Count];
                Surname = new string[model.Contacts.Count];
                Phone = new string[model.Contacts.Count];
                Adress = new string[model.Contacts.Count];
                for (int i = 0; i < model.Contacts.Count; i++)
                {
                    Name[i] = model.Contacts[i].Name;
                    Surname[i] = model.Contacts[i].Surname;
                    Phone[i] = model.Contacts[i].Surname;
                    Adress[i] = model.Contacts[i].Adress;
                }
                view.valueName = this.Name;
                view.Surname = this.Surname;
                view.Phone = this.Phone;
                view.Adress = this.Adress;
            }
        }
        private void updateModel(object sender, EventArgs e)
        {
            if (view.valueName != null)
            {
                List<Contact> toModel = new List<Contact>();
                for (int i = 0; i < view.valueName.Length; i++)
                {
                    Contact contact = new();
                    contact.Name = view.valueName[i];
                    contact.Surname = view.Surname[i];
                    contact.Phone = view.Phone[i];
                    contact.Adress = view.Adress[i];
                    toModel.Add(contact);
                }
                model.Contacts = toModel;
            }
        }
    }
}
