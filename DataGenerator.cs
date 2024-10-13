﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_Shelkynov.Models;

namespace DataGridView_Shelkynov
{
    internal class DataGenerator
    {
        public static Person CreatePerson(Action<Person> settings = null)
        {
            var result = new Person
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