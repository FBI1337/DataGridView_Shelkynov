using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DataGridViewShelkynov.Contracts;
using DataGridViewShelkynov.Contracts.Models;
using DataGridView_Shelkynov.Models;

namespace DtaGridViewShelkynov.StoreMemory.DataBase
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DataGridContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста базы данных
        /// </summary>
        public DataGridContext() : base("DataGridPerson")
        {
        }

        /// <summary>
        /// Таблица <see cref="Person"/> в базе данных
        /// </summary>
        public DbSet<Person> Persons { get; set; }
    }
}
