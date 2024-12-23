﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DataGridView_Shelkynov.Models;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataGridView_Shelkynov
{
    /// <summary>
    /// Форма добавления абитуриентов
    /// </summary>
    public partial class ApplicantsPerson : Form
    {
        private ValidatePerson person;
        /// <summary>
        /// Конструктор
        /// </summary>
        public ApplicantsPerson(ValidatePerson person = null)
        {
            InitializeComponent();
            this.person = person == null
                ? new ValidatePerson
                {
                    Id = Guid.NewGuid(),
                    Name = "Иванов",
                    Gender = Gender.Male,
                    Birhday = DateTime.Now.AddYears(-12),
                    Education = Enducation.BEER,
                    Value1 = 100,
                    Value2 = 100,
                    Value3 = 100,
                }
                : new ValidatePerson
                {
                    Id = person.Id,
                    Name = person.Name,
                    Gender = person.Gender,
                    Birhday = person.Birhday,
                    Education = person.Education,
                    Value1 = person.Value1,
                    Value2 = person.Value2,
                    Value3 = person.Value3,
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


            textBox1.AddBinding(x => x.Text, this.person, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, this.person, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, this.person, x => x.Birhday, errorProvider1);
            comboBox2.AddBinding(x => x.SelectedItem, this.person, x => x.Education, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, this.person, x => x.Value1, errorProvider1);
            numericUpDown2.AddBinding(x => x.Value, this.person, x => x.Value2, errorProvider1);
            numericUpDown3.AddBinding(x => x.Value, this.person, x => x.Value3, errorProvider1);

        }
        private void Calculater()
        {
            textBox2.Text = (numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value).ToString();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Calculater();
        }


        /// <summary>
        /// Данные абитуриентов
        /// </summary>
        public ValidatePerson ValidatePerson => person;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Gender)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValueGender(value),
                    e.Font,
                    new SolidBrush(e.ForeColor),
                    e.Bounds.X + 20,
                    e.Bounds.Y);
            }
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Enducation)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValueEnducation(value),
                    e.Font,
                    new SolidBrush(e.ForeColor),
                    e.Bounds.X + 20,
                    e.Bounds.Y);
            }
        }
        private string GetDisplayValueEnducation(Enducation value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidatablePerson(person))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private string GetDisplayValueGender(Gender value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }

        private bool ValidatablePerson(ValidatePerson person)
        {
            var context = new ValidationContext(person, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(person, context, results, true);
        }
    }
}
