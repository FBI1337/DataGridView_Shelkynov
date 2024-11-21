using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGridViewShelkynov.Contracts.Models;
using DataGridViewShelkynov.PersonManager.Models;
using System.Reflection;

namespace DataGridViewShelkynov.PersonManager
{
    ///<inherotdoc cref="IPersonManager"/>
    public class PersonManager : IPersonManager
    {
        private IPersonStorage personStorage;
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonManager(IPersonStorage personStorage)
        {
            this.personStorage = personStorage;
        }

        ///<inherotdoc cref="IPersonManager.AddAsync(Person)"/>
        public async Task<Person> AddAsync(Person person)
        {
            var result = await personStorage.AddAsync(person);
            return result;
        }

        ///<inherotdoc cref="IPersonManager.DeleteAsync(Guid)"/>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await personStorage.DeleteAsync(id);
            return result;
        }

        ///<inheritdoc cref="IPersonManager.EditAsync(Person)"/>
        public Task EditAsync(Person person)
            => personStorage.EditAsync(person);

        ///<inheritdoc cref="IPersonManager.GetAllAsync()"/>
        public Task<IReadOnlyCollection<Person>> GetAllAsync()
            => personStorage.GetAllAsync();

        ///<inheritdoc cref="IPersonManager.GetStatsAsync()"/>
        public async Task<IPersonStats> GetStatsAsync()
        {
            var result = await personStorage.GetAllAsync();
            return new PersonStatsModel
            {
                Count = result.Count,
                MaleCount = result.Where(x => x.Gender == Gender.Male).Count(),
                FemaleCount = result.Where(x => x.Gender == Gender.Famele).Count(),
                FullTimeCount = result.Where(x => x.Education == Enducation.FullTime).Count(),
                FiftyFifty = result.Where(x => x.Education == Enducation.FiftyFifty).Count(),
                BEER = result.Where(x => x.Education == Enducation.BEER).Count(),
                Result = result.Where(x => x.Result >= 150).Count(),
            };
        }
    }
}
