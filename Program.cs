using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewShelkynov.PersonManager;
using DtaGridViewShelkynovStoreMemory;
using Microsoft.Extensions.Logging;

namespace DataGridView_Shelkynov
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var factory = LoggerFactory.Create(builder => builder.AddDebug());
            var logger = factory.CreateLogger(nameof(DataGrid));
            var storage = new MemoryPersonStorage();
            var manager = new PersonManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
