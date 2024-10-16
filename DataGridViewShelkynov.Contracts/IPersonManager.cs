using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewShelkynov.Contracts
{
    /// <summary>
    /// Интерфейс прослойки между <see cref="MemoryPersonStorage"/> и представлением
    /// </summary>
    public interface IPersonManager
    {
        /// <summary>
        /// Асинхронное получение данных
        /// </summary>
        Task<IReadOnlyCollection<Person>> GetAllAsync();
        /// <summary>
        /// Асинхронное добавление данных
        /// </summary>
        Task<Person> AddAsync(Person person);
        /// <summary>
        /// Асинхронное изменение данных
        /// </summary>
        Task EditAsync(Person person);
        /// <summary>
        /// Асинхронное удаление данных
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
        /// <summary>
        /// Асинхронное получение сумарных данных
        /// </summary>
        Task<IPersonStats> GetStatsAsync();
    }
}
