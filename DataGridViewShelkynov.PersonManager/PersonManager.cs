using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.PersonManager.Models;
using DataGridViewShelkynov.Contracts;
using DataGridViewShelkynov.Contracts.Models;
using Microsoft.Extensions.Logging;

namespace DataGridViewShelkynov.PersonManager
{
    ///<inherotdoc cref="IPersonManager"/>
    public class PersonManager : IPersonManager
    {
        private readonly IPersonStorage personStorage;
        private readonly ILogger logger;
        private const string InfoLoggerTxt = "Действие {@person} с id {ID}, выполнено за {Milliseconds} мс";
        private const string ErrorLoggerTxt = "Действие {@person} с id {ID}, не было выполнено";
        /// <summary>
        /// Конструктор
        /// </summary>
        public PersonManager(IPersonStorage personStorage, ILogger logger)
        {
            this.logger = logger;
            this.personStorage = personStorage;
        }

        ///<inherotdoc cref="IPersonManager.AddAsync(Person)"/>
        async Task<Person> IPersonManager.AddAsync(Person person)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Person result;
            try
            {
                result = await personStorage.AddAsync(person);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(
                    ErrorLoggerTxt,
                    nameof(IPersonManager.AddAsync),
                    person.Id
                    );
                return null;
            }

            stopwatch.Stop();
            logger.LogInformation(
                InfoLoggerTxt,
                nameof(IPersonManager.AddAsync),
                person.Id,
                stopwatch.ElapsedMilliseconds
                );
            return result;
        }

        ///<inherotdoc cref="IPersonManager.DeleteAsync(Guid)"/>
        async Task<bool> IPersonManager.DeleteAsync(Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result;
            try
            {
                result = await personStorage.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(
                    ErrorLoggerTxt,
                    nameof(IPersonManager.DeleteAsync),
                    id
                    );
                return false;
            }

            stopwatch.Stop();
            logger.LogInformation(
                InfoLoggerTxt,
                nameof(IPersonManager.DeleteAsync),
                id,
                stopwatch.ElapsedMilliseconds
                );
            return result;
        }

        ///<inheritdoc cref="IPersonManager.EditAsync(Person)"/>
        async Task IPersonManager.EditAsync(Person person)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                await personStorage.EditAsync(person);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(
                    ErrorLoggerTxt,
                    nameof(IPersonManager.EditAsync),
                    person.Id
                    );
            }

            stopwatch.Stop();
            logger.LogInformation(
                InfoLoggerTxt,
                nameof(IPersonManager.EditAsync),
                person.Id,
                stopwatch.ElapsedMilliseconds
                );
        }

        ///<inheritdoc cref="IPersonManager.GetAllAsync()"/>
        async Task<IReadOnlyCollection<Person>> IPersonManager.GetAllAsync()
        {
            try
            {
                return await personStorage.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ошибка при получении абитуриентов");
            }
            return null;
        }

        ///<inheritdoc cref="IPersonManager.GetStatsAsync()"/>
        async Task<IPersonStats> IPersonManager.GetStatsAsync()
        {
            try
            {
                var result = await personStorage.GetAllAsync();
                return new PersonStatsModel
                {
                    Count = result.Count,
                    MaleCount = result.Where(x => x.Gender == Gender.Male).Count(),
                    FemaleCount = result.Where(x => x.Gender == Gender.Female).Count(),
                    FullTimeCount = result.Where(x => x.Education == Enducation.FullTime).Count(),
                    FiftyFifty = result.Where(x => x.Education == Enducation.FiftyFifty).Count(),
                    BEER = result.Where(x => x.Education == Enducation.BEER).Count(),
                    Result = result.Where(x => x.Value1 + x.Value2 + x.Value3 >= 150).Count(),
                };
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ошибка при получении статистики");
            }
            return null;
        }
    }
}
