using Domain.Entities;
using Persistence.Context;
using System;
using System.Linq;

namespace Infrastructure.Tets
{
    public class DatabaseInitializer
    {
        public static void Initialize(MediaPlayerContext context)
        {
            //if (context.Products.Any())
            //{
            //    return;
            //}
            //Seed(context);
        }

        private static void Seed(MediaPlayerContext context)
        {
            //var products = new[]
            //{
            //    new Product
            //    {
            //        Id = Guid.Parse("3eae2248-1055-4029-84fe-0f4ad6c4fed0"),
            //        Name = "Computer",
            //        Barcode = "BarcodeComputer",
            //        Price = 600
            //    },
            //    new Product
            //    {
            //        Id = Guid.Parse("d911605e-7842-4229-a37c-20b432c9d678"),
            //        Name = "Laptop",
            //        Barcode = "BarcodeLaptop",
            //        Price = 900
            //    }
            //};

            //context.Products.AddRange(products);
            //context.SaveChanges();
        }
    }
}
