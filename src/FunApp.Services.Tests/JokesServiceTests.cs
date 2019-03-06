using FunApp.Common;
using FunApp.Data;
using FunApp.Models;
using FunApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FunApp.Services.Tests
{
    public class JokesServiceTests
    {
        [Fact]
        public void GetCountShouldReturnsCorrectNumber()
        {
            var jokesRepository = new Mock<IRepository<Joke>>();
            jokesRepository.Setup(r => r.All()).Returns(new List<Joke>()
            {
                new Joke(),
                new Joke(),
                new Joke(),
            }.AsQueryable());
            var service = new JokesService(jokesRepository.Object, null);
            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public async Task GetCountShouldReturnsCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Find_Jokes_Database")
                .Options;

            var dbContext = new ApplicationDbContext(options);

            dbContext.Jokes.Add(new Joke());
            dbContext.Jokes.Add(new Joke());
            dbContext.Jokes.Add(new Joke());
            await dbContext.SaveChangesAsync();

            var repository = new DbRepository<Joke>(dbContext);
            var jokesService = new JokesService(repository, null);
            var count = jokesService.GetCount();
            Assert.Equal(3, count);
        }
    }
}
