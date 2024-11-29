using System;
using DataGridViewShelkynov.Contracts;
using DataGridView_Shelkynov.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DtaGridViewShelkynovStoreMemory
{
    ///<inheritdoc cref="IPersonStorage"/>
    public class MemoryPersonStorage : IPersonStorage
    {
        private List<Person> people;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MemoryPersonStorage()
        {
            people = new List<Person>();
        }

        /// <summary>
        /// Асихронное добавление абитуриента
        /// </summary>
        public Task<Person> AddAsync(Person person)
        {
            people.Add(person);
            return Task.FromResult(person);
        }

        /// <summary>
        /// Асихронное удаление абитуриента
        /// </summary>
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

        /// <summary>
        /// Асихронное редактирование абитуриента
        /// </summary>
        public Task EditAsync(Person person)
        {
            var target = people.FirstOrDefault(x => x.Id == person.Id);
            if (target != null)
            {
                target.Name = person.Name;
                target.Gender = person.Gender;
                target.Birhday = person.Birhday;
                target.Education = person.Education;
                target.Value1 = person.Value1;
                target.Value2 = person.Value2;
                target.Value3 = person.Value3;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Получение абитуриентов из хранилища
        /// </summary>
        public Task<IReadOnlyCollection<Person>> GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Person>>(people);

    }
}
