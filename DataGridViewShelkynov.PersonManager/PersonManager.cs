using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGridViewShelkynov.Contracts.Models;
using DataGridViewShelkynov.PersonManager.Models;

namespace DataGridViewShelkynov.PersonManager
{
    public class PersonManager : IPersonManager

    {
        private IPersonStorage personStorage;

        public PersonManager(IPersonStorage personStorage)
        {
            this.personStorage = personStorage;
        }

        public async Task<Person> AddAsync(Person person)
        {
            var result = await personStorage.AddAsync(person);
            return result;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await personStorage.DeleteAsync(id);
            return result;
        }

        public Task EditAsync(Person person)
            => personStorage.EditAsync(person);

        public Task<IReadOnlyCollection<Person>> GetAllAsync()
            => personStorage.GetAllAsync();

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
