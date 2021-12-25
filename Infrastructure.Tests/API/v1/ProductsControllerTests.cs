using FakeItEasy;
using MediatR;
using Xunit;

namespace Infrastructure.Tets.API.v1
{
    public class ProductsControllerTests
    {
        //private readonly ProductsController controller;
        private readonly IMediator mediator;

        public ProductsControllerTests()
        {
            mediator = A.Fake<IMediator>();
            //controller = new ProductsController(mediator);
        }

        [Fact]
        public async void Given_ProductsController_When_GetIsCalled_Then_ShouldReturnA_ProductCollection()
        {
            // Arrange&& act
            //await controller.Get();
            //A.CallTo(() => mediator.Send(A<GetProductsQuery>._, default)).MustHaveHappenedOnceExactly();
        }

    }
}
