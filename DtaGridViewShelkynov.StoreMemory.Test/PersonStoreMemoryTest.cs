using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts;
using DataGridViewShelkynov.Contracts.Models;
using DtaGridViewShelkynov.StoreMemory;
using DtaGridViewShelkynovStoreMemory;
using FluentAssertions;
using Xunit;

namespace DtaGridViewShelkynov.StoreMemory.Test
{
    public class PersonStoreMemoryTest
    {
        /// <summary>
        /// Тесты для класса <see cref="MemoryPersonStorage"/>
        /// </summary>
        public class PersonStoreMemoryTests
        {
            private readonly IPersonStorage personStorage;

            /// <summary>
            /// Инициализирует новый экземпляр класса <see cref="PersonStoreMemoryTests"/>
            /// </summary>
            public PersonStoreMemoryTests()
            {
                personStorage = new MemoryPersonStorage();
            }

            /// <summary>
            /// При пустом списке нет ошибок <see cref="IPersonStorage.GetAllAsync"/>
            /// </summary>
            [Fact]
            public async Task GetAllShouldNotThrow()
            {
                // Act
                Func<Task> act = () => personStorage.GetAllAsync();

                // Assert
                await act.Should().NotThrowAsync();
            }


            /// <summary>
            /// Получает пустой список <see cref="IPersonStorage.GetAllAsync"/>
            /// </summary>
            [Fact]
            public async Task GetAllShouldReturnEmpty()
            {
                // Act
                var result = await personStorage.GetAllAsync();

                // Assert
                result.Should()
                .NotBeNull()
                .And.BeEmpty();
            }

            /// <summary>
            /// Тест: Метод <see cref="IPersonStorage.AddAsync"/> должен вернуть добавленный объект.
            /// </summary>
            [Fact]
            public async Task AddShouldReturnValue()
            {
                // Arrange
                var model = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name{Guid.NewGuid():N}",
                    Gender = Gender.Female,
                    Birhday = DateTime.Now,
                    Education = Enducation.BEER,
                    Value1 = 30,
                    Value2 = 30,
                    Value3 = 30,
                };

                // Act
                var result = await personStorage.AddAsync(model);

                // Assert
                result.Should().NotBeNull()
                    .And.BeEquivalentTo(new
                    {
                        model.Id,
                        model.Gender,
                    });
            }

            /// <summary>
            /// Удаление из хранилища
            /// </summary>
            [Fact]
            public async Task DeleteShouldReturnTrue()
            {
                // Arrange
                var model = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name{Guid.NewGuid():N}",
                    Gender = Gender.Female,
                    Birhday = DateTime.Now,
                    Education = Enducation.BEER,
                    Value1 = 30,
                    Value2 = 30,
                    Value3 = 30,
                };

                // Act
                await personStorage.AddAsync(model);
                var result = await personStorage.DeleteAsync(model.Id);

                var nailList = await personStorage.GetAllAsync();
                var tryGetModel = nailList.FirstOrDefault(x => x.Id == model.Id);

                // Assert
                result.Should().BeTrue();
                tryGetModel.Should().BeNull();
            }

            /// <summary>
            /// Изменение данных в хранилище
            /// </summary>
            [Fact]
            public async Task EditShouldUpdateStorageData()
            {
                // Arrange
                var model = new Person
                {
                    Id = Guid.NewGuid(),
                    Name = $"Name{Guid.NewGuid():N}",
                    Gender = Gender.Male,
                    Birhday = DateTime.Now,
                    Education = Enducation.BEER,
                    Value1 = 30,
                    Value2 = 30,
                    Value3 = 30,
                };

                // Act
                await personStorage.AddAsync(model);
                await personStorage.EditAsync(model);
                var applicantList = await personStorage.GetAllAsync();
                var result = applicantList.FirstOrDefault(x => x.Id == model.Id);

                // Assert
                result?.Should().NotBeNull();
                result?.Id.Should().Be(model.Id);
                result?.Gender.Should().Be(Gender.Male);
            }
        }
    }
}
