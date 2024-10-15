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

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            var applicantsPerson = new ApplicantsPerson();
            if (applicantsPerson.ShowDialog(this) == DialogResult.OK)
            {
                people.Add(applicantsPerson.Person);
                bindingSource.ResetBindings(false);
                SetStatus();
            }
        }
        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    people.Remove(data);
                    bindingSource.ResetBindings(false);
                    SetStatus();
                }
            }
        }
        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var applicantsPerson = new ApplicantsPerson(data);
                if (applicantsPerson.ShowDialog(this) == DialogResult.OK)
                {
                    data.Name = applicantsPerson.Person.Name;
                    data.Gender = applicantsPerson.Person.Gender;
                    data.Birhday = applicantsPerson.Person.Birhday;
                    data.Education = applicantsPerson.Person.Education;
                    data.Value1 = applicantsPerson.Person.Value1;
                    data.Value2 = applicantsPerson.Person.Value2;
                    data.Value3 = applicantsPerson.Person.Value3;
                }
            }
        }

        private void dataGridView1_CellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalScore")
            {
                var data = (Person)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                data.Result = data.Value1 + data.Value2 + data.Value3;
                e.Value = data.Result;
                SetStatus();
            }
        }

        public void SetStatus()
        {
            toolStripStatusLabel1.Text = $"Всего: {people.Count}";
            toolStripStatusLabel2.Text = $"{people.Where(x => x.Gender == Gender.Famele).Count()} Ж/{people.Where(x => x.Gender == Gender.Male).Count()}М";
            toolStripStatusLabel3.Text = $"Люиди набравшие больше 150: {people.Where(x => x.Result >= 150).Count()}";
        }

    }
}
