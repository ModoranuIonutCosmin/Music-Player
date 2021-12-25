using Domain.Entities;
using FakeItEasy;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tets.Service
{
    public class CreateProductCommandHandlerTests
    {
        //private readonly Application.Features.Commands.CreateProductCommandHandler handler;
        //private readonly Application.Interfaces.IProductRepository repository;

        public CreateProductCommandHandlerTests()
        {
            //this.repository= A.Fake<Application.Interfaces.IProductRepository>();
            //this.handler = new Application.Features.Commands.CreateProductCommandHandler(this.repository);
        }

        [Fact]
        public async Task Given_CreateProductCommandHandler_When_HandleISCalled_Then_AddAsyncProductIsCalled()
        {
            //// Arrange & Act
            //await handler.Handle(new Application.Features.Commands.CreateProductCommand(), default);
            //// Assert
            //A.CallTo(() => repository.AddAsync(A<Product>._)).MustHaveHappenedOnceExactly();
        }
    }
}
