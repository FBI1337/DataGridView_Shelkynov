using System;
using System.ComponentModel;

namespace DataGridView_Shelkynov.Models
{
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender
    {

        /// <summary>
        /// Мужской пол
        /// </summary>
        [Description("Мужской")]
        Male = 1,

        /// <summary>
        /// Женский пол
        /// </summary>
        [Description("Женский")]
        Famele = 2,
    }
}
