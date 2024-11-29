using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts;

namespace DataGridView_Shelkynov
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class Form1 : Form
    {

        private readonly IPersonManager personManager;
        private readonly BindingSource bindingSource;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Form1(IPersonManager personManager)
        {
            this.personManager = personManager;

            bindingSource = new BindingSource();

            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        private async void toolStripAdd_Click(object sender, System.EventArgs e)
        {
            var applicantsPerson = new ApplicantsPerson();
            if (applicantsPerson.ShowDialog(this) == DialogResult.OK)
            {
                await personManager.AddAsync(ValidateConverter.ToValidateApplicant(applicantsPerson.ValidatePerson));
                bindingSource.DataSource = await personManager.GetAllAsync();
                bindingSource.ResetBindings(false);
                await SetStatus();
            }
        }
        private void toolStripClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var applicantsPerson = new ApplicantsPerson(ValidateConverter.ToApplicant(data));
                if (applicantsPerson.ShowDialog(this) == DialogResult.OK)
                {
                    await personManager.EditAsync(ValidateConverter.ToValidateApplicant(applicantsPerson.ValidatePerson));
                    bindingSource.DataSource = await personManager.GetAllAsync();
                    bindingSource.ResetBindings(false);
                    await SetStatus();
                }
            }
        }

        private async void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Person)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await personManager.DeleteAsync(data.Id);
                    bindingSource.DataSource = await personManager.GetAllAsync();
                    bindingSource.ResetBindings(false);
                    await SetStatus();
                }
            }
        }


        /// <summary>
        /// Обновление статуса абитуриентов
        /// </summary>
        public async Task SetStatus()
        {
            var result = await personManager.GetStatsAsync();
            toolStripStatusLabel1.Text = $"Всего: {result.Count}";
            toolStripStatusLabel2.Text = $"{result.FemaleCount} Ж/{result.MaleCount} М";
            toolStripStatusLabel3.Text = $"Люиди набравшие больше 150: {result.Result}";
            toolStripStatusLabel4.Text = $"Очный {result.FullTimeCount} / Очно-Заочный {result.FiftyFifty} / Заочный {result.BEER}";
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

        private async void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await personManager.GetAllAsync();
            await SetStatus();
        }
    }
}
