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
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birhday { get; set; }
        /// <summary>
        /// <inheritdoc cref="DataGridView_Shelkynov.Models.Gender"/>
        /// </summary>
        [Range(0, 3)]
        public Gender Gender { get; set; }
        /// <summary>
        /// <inheritdoc cref="DataGridView_Shelkynov.Models.Enducation"/>
        /// </summary>
        public Enducation Education { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по Математике
        /// </summary>
        [Range(0, 100)]
        public int Value1 { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по русскому
        /// </summary>
        [Range(0, 100)]
        public int Value2 { get; set; }
        /// <summary>
        /// Баллы ЕГЭ по информатике
        /// </summary>
        [Range(0, 100)]
        public int Value3 { get; set; }
        /// <summary>
        /// Общая сумма баллов
        /// </summary>
        public int Result { get; set; }
    }
}
