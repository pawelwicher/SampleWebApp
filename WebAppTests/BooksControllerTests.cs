using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Collections.Generic;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.Models;
using Xunit;

namespace WebAppTests
{
    public class BooksControllerTests
    {
        [Fact]
        public async void IndexTest()
        {
            var options = new DbContextOptionsBuilder<BooksContext>()
                .UseInMemoryDatabase(databaseName: "StudentsDb")
                .Options;

            using (var context = new BooksContext(options))
            {
   
                context.Books.Add(new Book { Id = 1, Title = "JS", Year = 2019 });
                context.Books.Add(new Book { Id = 2, Title = "Python", Year = 2018 });
                context.Books.Add(new Book { Id = 3, Title = "Haskell", Year = 2010 });
                context.SaveChanges();

                var controller = new BooksController(context);

                var result = await controller.Index();

                var actual = ((result as ViewResult).Model as List<Book>).Count;

                actual.Should().Be(3);
            }
        }
    }
}
