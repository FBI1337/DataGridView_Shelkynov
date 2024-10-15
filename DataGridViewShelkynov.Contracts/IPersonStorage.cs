using DataGridView_Shelkynov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewShelkynov.Contracts
{
    public interface IPersonStorage
    {
        Task<IReadOnlyCollection<Person>> GetAllAsync();

        Task<Person> AddAsync(Person person);

        Task EditAsync(Person person);

        Task<bool> DeleteAsync(Guid id);
    }
}
