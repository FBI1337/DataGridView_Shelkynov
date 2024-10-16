using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView_Shelkynov.Models
{
    /// <summary>
    /// Формы обучения
    /// </summary>
    public enum Enducation
    {

        /// <summary>
        /// Очная форма обучения
        /// </summary>
        [Description("Очный")]
        FullTime = 1,

        /// <summary>
        /// Очная-заочная форма обучения
        /// </summary>
        [Description("Очный-заочный")]
        FiftyFifty = 2,

        /// <summary>
        /// Заочная форма обучения
        /// </summary>
        [Description("Заочный")]
        BEER = 3,
    }
}
