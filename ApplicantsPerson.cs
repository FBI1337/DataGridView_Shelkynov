using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridView_Shelkynov.Models;

namespace DataGridView_Shelkynov
{
    public partial class ApplicantsPerson : Form
    {
        private Person person;
        public ApplicantsPerson(Person person = null)
        {
            InitializeComponent();
            this.person = person == null
                ? DataGenerator.CreatePerson(x =>
                {
                    x.Id = Guid.NewGuid();
                    x.Name = "Иванов";
                    x.Gender = Gender.Male;
                    x.Birhday = DateTime.Now.AddYears(-12);
                })
                : new Person
                {
                    Id = person.Id,
                    Name = person.Name,
                    Gender = Gender.Male,
                    Birhday = person.Birhday,
                };
            numericUpDown1.ValueChanged += textBox5_TextChanged;
            numericUpDown2.ValueChanged += textBox5_TextChanged;
            numericUpDown3.ValueChanged += textBox5_TextChanged;
        }

        public Person Person => person;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            decimal value1 = numericUpDown1.Value;
            decimal value2 = numericUpDown2.Value;
            decimal value3 = numericUpDown3.Value;

            Function function = new Function();

            decimal result = function.Calculate(value1, value2, value3);

            textBox5.Text = result.ToString();

        }
    }
}
