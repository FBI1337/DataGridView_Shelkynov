using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_Shelkynov.Models;

namespace DataGridView_Shelkynov
{
    /// <summary>
    /// Помощник для генерации данных
    /// </summary>
    public static class DataGenerator
    {
        /// <summary>
        /// Сгенирировать <see cref="Person"/> по стандартным параметрам или по заданым
        /// </summary>
        public static ValidatePerson CreatePerson(Action<ValidatePerson> settings = null)
        {
            var result = new ValidatePerson
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Birhday = DateTime.Now.AddYears(-16),
            };

            settings?.Invoke(result);

            return result;
        }
    }
}
