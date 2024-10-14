using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataGridView_Shelkynov.Models;
using System.Text;

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
                    Education = Enducation.FullTime,
                    Value1 = person.Value1,
                    Value2 = person.Value2,
                    Value3 = person.Value3,
                    Result = person.Result,
                };

            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                comboBox1.Items.Add(item);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            foreach (var item in Enum.GetValues(typeof(Enducation)))
            {
                comboBox2.Items.Add(item);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            numericUpDown1.ValueChanged += textBox5_TextChanged;
            numericUpDown2.ValueChanged += textBox5_TextChanged;
            numericUpDown3.ValueChanged += textBox5_TextChanged;


            textBox1.AddBinding(x => x.Text, this.person, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, this.person, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, this.person, x => x.Birhday, errorProvider1);
            comboBox2.AddBinding(x => x.SelectedItem, this.person, x => x.Education, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, this.person, x => x.Value1, errorProvider1);
            numericUpDown2.AddBinding(x => x.Value, this.person, x => x.Value2, errorProvider1);
            numericUpDown3.AddBinding(x => x.Value, this.person, x => x.Value3, errorProvider1);

        }

        public Person Person => person;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Gender)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValue(value),
                    e.Font,
                    new SolidBrush(e.ForeColor),
                    e.Bounds.X + 20,
                    e.Bounds.Y);
            }
        }

        private string GetDisplayValue(Gender value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            decimal value1 = numericUpDown1.Value;
            decimal value2 = numericUpDown2.Value;
            decimal value3 = numericUpDown3.Value;

            Function function = new Function();

            decimal result = function.Calculate(value1, value2, value3);

            label10.Text = result.ToString();

        }
    }
}
