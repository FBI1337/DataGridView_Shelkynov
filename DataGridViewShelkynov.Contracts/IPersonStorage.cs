using DataGridView_Shelkynov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewShelkynov.Contracts
{
    /// <summary>
    /// Интерфейс хранилища данных абитуриентов
    /// </summary>
    public interface IPersonStorage
    {
        /// <summary>
        /// Асинхронное получение всех данных
        /// </summary>
        Task<IReadOnlyCollection<Person>> GetAllAsync();
        /// <summary>
        /// Асинхроннное добавление даных
        /// </summary>
        Task<Person> AddAsync(Person person);
        /// <summary>
        /// Асинхронное редактирование данных
        /// </summary>
        Task EditAsync(Person person);
        /// <summary>
        /// Асинхронное удаление данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}
