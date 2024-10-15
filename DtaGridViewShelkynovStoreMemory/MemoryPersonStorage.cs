using System;
using DataGridViewShelkynov.Contracts;
using DataGridView_Shelkynov.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtaGridViewShelkynovStoreMemory
{
    public class MemoryPersonStorage : IPersonStorage
    {
        private List<Person> people;

        public MemoryPersonStorage()
        {
            people = new List<Person>();
        }

        public Task<Person> AddAsync(Person person)
        {
            people.Add(person);
            return Task.FromResult(person);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                people.Remove(person);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task EditAsync(Person person)
        {
            var target = people.FirstOrDefault(x => x.Id == person.Id);
            if (person != null)
            {
                target.Name = person.Name;
                target.Gender = person.Gender;
                target.Birhday = person.Birhday;
                target.Education = person.Education;
                target.Value1 = person.Value1;
                target.Value2 = person.Value2;
                target.Value3 = person.Value3;
                target.Result = person.Result;
            }

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Person>> GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Person>>(people);

    }
}
