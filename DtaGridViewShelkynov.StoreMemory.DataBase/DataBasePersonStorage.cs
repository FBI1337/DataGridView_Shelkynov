using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataGridViewShelkynov.Contracts;
using System.Data.Entity;
using DataGridViewShelkynov.Contracts.Models;
using System.Linq;
using System.Xml.Linq;
using DataGridView_Shelkynov.Models;

namespace DtaGridViewShelkynov.StoreMemory.DataBase
{
    /// <summary>
    /// Этот класс реализует интерфейс IPersonStorage с использованием базы данных.
    /// </summary>
    public class DataBasePersonStorage : IPersonStorage
    {

        /// <summary>
        /// Добавляет нового заявителя в базу данных.
        /// </summary>
        public async Task<Person> AddAsync(Person person)
        {
            using (var context = new DataGridContext())
            {
                var persons = new Person
                {
                    Id = person.Id,
                    Name = person.Name,
                    Birhday = person.Birhday,
                    Education = person.Education,
                    Value1 = person.Value1,
                    Value2 = person.Value2,
                    Value3 = person.Value3,
                };
                context.Persons.Add(person);
                await context.SaveChangesAsync();
            }

            return person;
        }

        /// <summary>
        /// Удаляет заявителя из базы данных по идентификатору.
        /// </summary>
        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var context = new DataGridContext())
            {
                var item = await context.Persons.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    context.Persons.Remove(item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Обновляет существующего заявителя в базе данных.
        /// </summary>
        public async Task EditAsync(Person person)
        {
            using (var context = new DataGridContext())
            {
                var target = await context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);
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
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Получает всех заявителей из базы данных.
        /// </summary>
        public async Task<IReadOnlyCollection<Person>> GetAllAsync()
        {
            using (var context = new DataGridContext())
            {
                var items = await context.Persons
                    .OrderByDescending(x => x.Name)
                    .ToListAsync()
                    ;
                return items;
            }
        }
    }
}
