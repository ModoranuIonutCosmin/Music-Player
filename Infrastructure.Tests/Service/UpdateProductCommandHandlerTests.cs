using Application.Interfaces;
using Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tets.Service
{
    public class UpdateProductCommandHandlerTests
    {
        //private readonly UpdateProductCommandHandler handler;
        //private readonly IProductRepository repository;

        public UpdateProductCommandHandlerTests()
        {
            //repository = A.Fake<IProductRepository>();
            //handler = new UpdateProductCommandHandler(repository);
        }

        [Fact]
        public async void Given_UpdateProductCommand_When_HandleIsCalled_Then_ShouldReturnUpdateProduct()
        {
            //// arrange
            //Product product = new Product
            //{
            //    Id = new Guid("961f92c1-9531-49d6-99b5-b72146aaf56d")
            //};

            //A.CallTo(() => repository.GetByIdAsync(new Guid("961f92c1-9531-49d6-99b5-b72146aaf56d"))).Returns(product);

            //// act
            //await handler.Handle(new UpdateProductCommand
            //{
            //    Id = new Guid("961f92c1-9531-49d6-99b5-b72146aaf56d")
            //}, default);

            //// assert
            //A.CallTo(() => repository.UpdateAsync(A<Product>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Given_UpdateProductCommand_When_HandleIsCalledAndProductIsNull_Then_ShouldThrowException()
        {
            //// arrange
            //Product product = null;

            //A.CallTo(() => repository.GetByIdAsync(new Guid("961f92c1-9531-49d6-99b5-b72146aaf56d"))).Returns(product);

            //// act
            //Func<Task> action = async () => await handler.Handle(new UpdateProductCommand
            //{
            //    Id = new Guid("961f92c1-9531-49d6-99b5-b72146aaf56d")
            //}, default);

            //// assert
            //_ = action.Should().ThrowAsync<Exception>();
        }
    }
}
