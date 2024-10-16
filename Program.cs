using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewShelkynov.PersonManager;
using DtaGridViewShelkynovStoreMemory;

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
            var storage = new MemoryPersonStorage();
            var manager = new PersonManager(storage);

            Application.Run(new Form1(manager));
        }
    }
}
