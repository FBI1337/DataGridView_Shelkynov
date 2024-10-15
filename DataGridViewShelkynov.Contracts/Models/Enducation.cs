using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView_Shelkynov.Models
{
    public enum Enducation
    {
        [Description("Очный")]
        FullTime = 1,

        [Description("Очный-заочный")]
        FiftyFifty = 2,

        [Description("Заочный")]
        BEER = 3,
    }
}
