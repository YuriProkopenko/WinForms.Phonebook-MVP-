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
    public partial class PhonebookView_Form1 : Form, IPhonebookView
    {
        public string[] valueName { get; set; }
        public string[] Surname { get; set; }
        public string[] Phone { get; set; }
        public string[] Adress { get; set; }
        public string OpenFileName { get; set; }
        public string SaveFileName { get; set; }
        ContextMenuStrip strip;
        public event EventHandler<EventArgs> PhonebookViewOpen;
        public event EventHandler<EventArgs> PhonebookViewSave;
        public event EventHandler<EventArgs> FillListView;
        public event EventHandler<EventArgs> FillModel;
        public PhonebookView_Form1()
        {
            InitializeComponent();
            strip = new ContextMenuStrip();
            strip.Items.Add("Menu item 1");
            strip.Items.Add("Menu item 2");
            strip.Items.Add("Menu item 3");
            contextMenuStrip1 = strip;
            editToolStripMenuItem.Enabled = false;
            removeToolStripMenuItem.Enabled = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All unsaved data will be lost!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                listView_Form1.Items.Clear();
            else
                return;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All unsaved data will be lost!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                Application.Exit();
            else
                return;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PhonebookView_Form2 form2 = new(this);
                form2.ShowDialog();
                FillModel?.Invoke(this, EventArgs.Empty);
                fillListView();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                Application.Exit();
            }
        }

        private void fillListView()
        {
            listView_Form1.Items.Clear();
            FillListView?.Invoke(this, EventArgs.Empty);
            for (int i = 0; i < valueName.Length; i++)
            {               
                listView_Form1.Items.Add(new ListViewItem(new string[] { valueName[i], Surname[i], Phone[i], Adress[i]}, i));                
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(ListViewItem item in listView_Form1.SelectedItems)
                {
                    listView_Form1.Items.Remove(item);
                }
                FillModel?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                Application.Exit();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = listView_Form1.SelectedItems[0].SubItems[0].Text;
                string Surname = listView_Form1.SelectedItems[0].SubItems[1].Text;
                string Phone = listView_Form1.SelectedItems[0].SubItems[2].Text;
                string Adress = listView_Form1.SelectedItems[0].SubItems[3].Text;
                int itemIndex = listView_Form1.SelectedIndices[0];
                PhonebookView_Form2 form2 = new(this, Name, Surname, Phone, Adress, itemIndex);
                form2.ShowDialog();
                FillModel?.Invoke(this, EventArgs.Empty);
                fillListView();
                editToolStripMenuItem.Enabled = false;
                removeToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
                Application.Exit();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView_Form1.Items.Count > 0)
                {
                    DialogResult result = MessageBox.Show("All unsaved data will be lost!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.OK && openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        OpenFileName = openFileDialog1.FileName;
                        PhonebookViewOpen?.Invoke(this, EventArgs.Empty);
                        fillListView();
                    }
                    else
                        return;
                }
                else
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        OpenFileName = openFileDialog1.FileName;
                        PhonebookViewOpen?.Invoke(this, EventArgs.Empty);
                        fillListView();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveFileName = saveFileDialog1.FileName;
                    for (int i = 0; i < listView_Form1.Items.Count; i++)
                    {
                        PhonebookViewSave?.Invoke(this, EventArgs.Empty);
                    }
                    MessageBox.Show("List saved!", "");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (listView_Form1.SelectedItems.Count == 1)
            {
                editToolStripMenuItem.Enabled = true;
            }
            if (listView_Form1.SelectedItems.Count > 0)
            {
                removeToolStripMenuItem.Enabled = true;
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
