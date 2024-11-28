using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGridView_Shelkynov.Models;
using DataGridViewShelkynov.Contracts;
using DataGridViewShelkynov.Contracts.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DataGridViewShelkynov.PersonManager.Test
{

    /// <summary>
    /// Тесты для класса <see cref="PersonManager"/>.
    /// </summary>
    public class PersonManagerTest
    {
        private readonly IPersonManager personManager;
        private readonly Mock<IPersonStorage> personStorageMock;
        private readonly Mock<ILogger> loggerMock;


        /// <summary>
        /// Инициализирует новый класс <see cref="PersonManagerTest"/>
        /// </summary>
        public PersonManagerTest()
        {
            personStorageMock = new Mock<IPersonStorage>();
            loggerMock = new Mock<ILogger>();

            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));
            personManager = new PersonManager(personStorageMock.Object, loggerMock.Object);
        }


        /// <summary>
        /// Тесе: Метод <see cref="PersonManager.AddAsync"/>
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            //Arrange
            var model = new Person
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Famele,
                Birhday = DateTime.Now,
                Education = Enducation.BEER,
                Value1 = 30,
                Value2 = 30,
                Value3 = 30,
            };
            personStorageMock.Setup(x => x.AddAsync(It.IsAny<Person>()))
                .ReturnsAsync(model);

            // Act
            var result = await personManager.AddAsync(model);

            // Asset
            result.Should().NotBeNull()
                .And.Be(model);

            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IPersonManager.AddAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            personStorageMock.Verify(x => x.AddAsync(It.Is<Person>(y => y.Id == model.Id)),
                Times.Once);
            personStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Тест: Метод <see cref="PersonManager.EditAsync"/>
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
        {
            //Arrange
            var model = new Person
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Famele,
                Birhday = DateTime.Now,
                Education = Enducation.BEER,
                Value1 = 30,
                Value2 = 30,
                Value3 = 30,
            };
            personStorageMock.Setup(x => x.EditAsync(It.IsAny<Person>())).Returns(Task.CompletedTask);

            // Act
            await personManager.EditAsync(model);

            // Asset
            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IPersonManager.EditAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            personStorageMock.Verify(x => x.EditAsync(It.Is<Person>(y => y.Id == model.Id)),
                Times.Once);
            personStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Тест: метод <see cref="PersonManager.DeleteAsync"/>
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            //Arrange
            var model = new Person
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Famele,
                Birhday = DateTime.Now,
                Education = Enducation.BEER,
                Value1 = 30,
                Value2 = 30,
                Value3 = 30
            };
            personStorageMock.Setup(x => x.DeleteAsync(model.Id))
                .ReturnsAsync(true);

            // Act
            var result = await personManager.DeleteAsync(model.Id);

            // Asset
            result.Should().BeTrue();

            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IPersonManager.DeleteAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            personStorageMock.Verify(x => x.DeleteAsync(model.Id),
                Times.Once);
            personStorageMock.VerifyNoOtherCalls();
        }
        /// <summary>
        /// Тест: Метод <see cref="PersonManager.GetAllAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldWork()
        {
            // Arrange
            var person = new List<Person>
    {
        new Person
        {
            Id = Guid.NewGuid(),
            Name = "Person1",
            Gender = Gender.Male,
            Birhday = DateTime.Now.AddYears(-20),
            Education = Enducation.BEER,
            Value1 = 30,
            Value2 = 30,
            Value3 = 30
        },
        new Person
        {
            Id = Guid.NewGuid(),
            Name = "Person2",
            Gender = Gender.Famele,
            Birhday = DateTime.Now.AddYears(-22),
            Education = Enducation.FullTime,
            Value1 = 70,
            Value2 = 70,
            Value3 = 70
        }
    };
            personStorageMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(person);

            // Act
            var result = await personManager.GetAllAsync();

            // Assert
            result.Should().NotBeNull()
                .And.HaveCount(person.Count)
                .And.BeEquivalentTo(person);
            personStorageMock.Verify(x => x.GetAllAsync(), Times.Once);
            personStorageMock.VerifyNoOtherCalls();
        }
        /// <summary>
        /// Тест: Метод <see cref="PersonManager.GetStatsAsync"/>
        /// </summary>
        [Fact]
        public async Task GetStatsShouldWork()
        {
            // Arrange
            var person = new List<Person>
    {
        new Person
        {
            Id = Guid.NewGuid(),
            Name = "Person1",
            Gender = Gender.Famele,
            Birhday = DateTime.Now.AddYears(-20),
            Education = Enducation.BEER,
            Value1 = 30,
            Value2 = 30,
            Value3 = 30
        },
        new Person
        {
            Id = Guid.NewGuid(),
            Name = "Person2",
            Gender = Gender.Famele,
            Birhday = DateTime.Now.AddYears(-22),
            Education = Enducation.FullTime,
            Value1 = 70,
            Value2 = 70,
            Value3 = 70
        }
    };
            personStorageMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(person);

            // Act
            var result = await personManager.GetStatsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(person.Count);
            result.MaleCount.Should().Be(1);
            result.FemaleCount.Should().Be(1);
            result.FullTimeCount.Should().Be(1);
            result.BEER.Should().Be(1);
            result.FiftyFifty.Should().Be(0);
            result.Result.Should().Be(2);

            personStorageMock.Verify(x => x.GetAllAsync(), Times.Once);
            personStorageMock.VerifyNoOtherCalls();
        }
    }
}
