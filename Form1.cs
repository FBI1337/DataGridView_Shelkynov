using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataGridView_Shelkynov.Models;

namespace DataGridView_Shelkynov
{
    public partial class Form1 : Form
    {

        private List<Person> people;
        private BindingSource bindingSource;
        public Form1()
        {
            bindingSource = new BindingSource();
            people = new List<Person>();
            bindingSource.DataSource = people;
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
            SetStatus();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var applicantsPerson = new ApplicantsPerson();
            if (applicantsPerson.ShowDialog(this) == DialogResult.OK)
            {
                people.Add(applicantsPerson.Person);
                bindingSource.ResetBindings(false);
                SetStatus();
            }
        }

        public void SetStatus()
        {
            toolStripStatusLabel1.Text = "Всего: ";
            toolStripStatusLabel2.Text = "Гендер";
            toolStripStatusLabel3.Text = "Люиди набравшие больше 150:";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
