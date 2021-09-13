using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Phonebook_MVP
{
    public partial class PhonebookView_Form2 : Form
    {
        int itemIndex = -1;
        PhonebookView_Form1 form1;
        public PhonebookView_Form2(PhonebookView_Form1 _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }
        public PhonebookView_Form2(PhonebookView_Form1 _form1, string _name, string _surname, string _phone, string _adress, int _itemIndex)
        {
            InitializeComponent();
            form1 = _form1;
            textBoxName.Text = _name;
            textBoxSurname.Text = _surname;
            textBoxPhone.Text = _phone;
            textBoxAdress.Text = _adress;
            itemIndex = _itemIndex;
            buttonOK.Enabled = false;
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemIndex == -1)
                    addObject();
                else
                    editObject();
                Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error!");
                Application.Exit();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (isCheckData())
                buttonOK.Enabled = true;
        }     
        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (isCheckData())
                buttonOK.Enabled = true;
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (isCheckData())
                buttonOK.Enabled = true;
        }
        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {
            if (isCheckData())
                buttonOK.Enabled = true;
        }

        private bool isCheckData()
        {
            if (textBoxName.Text.Length > 0 && textBoxName.Text.Length <= 20 &&
                textBoxSurname.Text.Length > 0 && textBoxSurname.Text.Length <= 20 &&
                textBoxPhone.Text.Length > 0 && textBoxPhone.Text.Length <= 13 &&
                textBoxAdress.Text.Length > 0 && textBoxAdress.Text.Length <= 35)
                return true;
            else
                return false;
        }
        private void addObject()
        {
            int length = 0;
            if (form1.valueName != null)
                length = form1.valueName.Length;
            string[] tempName = new string[length + 1];
            for (int i = 0; i < length; i++)
            {
                tempName[i] = form1.valueName[i];
            }
            tempName[tempName.Length - 1] = textBoxName.Text;
            form1.valueName = tempName;
            string[] tempSurname = new string[length + 1];
            for (int i = 0; i < length; i++)
            {
                tempSurname[i] = form1.Surname[i];
            }
            tempSurname[tempSurname.Length - 1] = textBoxSurname.Text;
            form1.Surname = tempSurname;
            string[] tempPhone = new string[length + 1];
            for (int i = 0; i < length; i++)
            {
                tempPhone[i] = form1.Phone[i];
            }
            tempPhone[tempPhone.Length - 1] = textBoxPhone.Text;
            form1.Phone = tempPhone;
            string[] tempAdress = new string[length + 1];
            for (int i = 0; i < length; i++)
            {
                tempAdress[i] = form1.Adress[i];
            }
            tempAdress[tempAdress.Length - 1] = textBoxAdress.Text;
            form1.Adress = tempAdress;
        }
        private void editObject()
        {
            form1.valueName[itemIndex] = textBoxName.Text;
            form1.Surname[itemIndex] = textBoxSurname.Text;
            form1.Phone[itemIndex] = textBoxPhone.Text;
            form1.Adress[itemIndex] = textBoxAdress.Text;
        }
    }
}
