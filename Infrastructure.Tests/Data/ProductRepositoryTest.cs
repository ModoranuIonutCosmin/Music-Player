using Domain.Entities;
using FluentAssertions;
using Persistence.v1;
using System;
using Xunit;

namespace Infrastructure.Tets.Data
{
    public class ProductRepositoryTest : DatabaseBaseTest
    {
        //private readonly Repository<Product> repository;
        //private readonly Product newProduct;

        public ProductRepositoryTest()
        {
            //repository = new Repository<Product>(context);
            //newProduct = new Product()
            //{
            //    Id = Guid.Parse("2cbda575-865e-4ecc-ab48-24e82f2e39f8"),
            //    Name = "Keyboard",
            //    Barcode = "BarcodeKeyboard",
            //    Price = 20
            //};
        }

        // GIVEN WHEN THEN
        [Fact]
        public async void Given_NewProduct_WhenProductIsNotNull_Then_AddAsyncShouldReturnANewProduct()
        {
            // AAA
            // Arrange && act
            //var result = await repository.AddAsync(newProduct);

            //// Assert
            //result.Should().BeOfType<Product>();
        }

        [Fact]
        public void Given_NewProduct_WhenProductIsNull_Then_AddSyncShouldReturnThrowArgumentNullException()
        {
            //repository.Invoking(r=>r.AddAsync(null)).Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
