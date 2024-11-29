using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewShelkynov.PersonManager;
using DtaGridViewShelkynov.StoreMemory.DataBase;
using DtaGridViewShelkynovStoreMemory;
using Serilog;
using Serilog.Extensions.Logging;

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


            var serilogLogger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Seq("http://localhost:5341", apiKey: "")
            .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger).CreateLogger("datagrid");

            var storage = new DataBasePersonStorage();
            var manager = new PersonManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
