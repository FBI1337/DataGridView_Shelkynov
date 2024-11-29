using System;
using System.ComponentModel.DataAnnotations;


namespace DataGridView_Shelkynov.Models
{
    /// <summary>
    /// Класс для заполнения данных об абитуриентах
    /// </summary>
    public class Person
    {
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>

        public DateTime Birhday { get; set; }
        /// <summary>
        /// <inheritdoc cref="DataGridView_Shelkynov.Models.Gender"/>
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// <inheritdoc cref="DataGridView_Shelkynov.Models.Enducation"/>
        /// </summary>
        public Enducation Education { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по Математике
        /// </summary>
        public int Value1 { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по русскому
        /// </summary>
        public int Value2 { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        public int Value3 { get; set; }
    }
}
