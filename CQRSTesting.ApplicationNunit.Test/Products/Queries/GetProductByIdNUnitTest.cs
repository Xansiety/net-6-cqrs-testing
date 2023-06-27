using AutoFixture;
using AutoMapper;
using CQRSTesting.Application.Helper;
using CQRSTesting.Domain.Entities;
using CQRSTesting.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using static CQRSTesting.Application.Products.Queries.GetProductByIdQuery;

namespace CQRSTesting.Application.Products.Queries
{
    [TestFixture]
    public class GetProductByIdNUnitTest
    {

        private GetProductByIdQuery.GetProductByIdQueryHandler handlerProductById;
        private Guid productIdGuid = Guid.NewGuid();

        [SetUp]
        public void SetUp()
        {
            // FAKE DATA - AutoFixture
            // Fixture nos permite crear data de prueba con el paquete AutoFixture
            var fixture = new Fixture();
            var productRecords = fixture.CreateMany<Product>(10).ToList(); // creamos 10 productos - un conjunto de records

            productRecords.Add(fixture.Build<Product>() // creamos un producto con id = Guid.Empty
                .With(tr => tr.ProductId, productIdGuid)
                .Create());

            // FAKE CONTEXT - Microsoft.EntityFrameworkCore.InMemory 
            // definir base de datos en memoria con el paquete Microsoft.EntityFrameworkCore.InMemory
            // Obtenemos las opciones de la clase de prod
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"CQRS_{Guid.NewGuid()}") // SE COLOCA DE FORMA DINAMICA PARA QUE SE GENERE UNA BASE DE DATOS POR CADA TEST
                .Options;
            // instanciar el contexto de la base de datos
            var ApplicationDbContextFake = new ApplicationDbContext(options); // en este momento la base de datos está vacía

            // WORK WITH FAKE DATA 
            // agregar los productos al contexto de la base de datos
            ApplicationDbContextFake.Products.AddRange(productRecords);
            // guardar los cambios en la base de datos
            ApplicationDbContextFake.SaveChanges();
             

            // FAKE MAPPER - AutoMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });
            var mapper = mapConfig.CreateMapper();


            // FAKE HANDLER
            handlerProductById = new GetProductByIdQuery.GetProductByIdQueryHandler(ApplicationDbContextFake, mapper);
        }

        [Test]
        public async Task GetProductByIdQueryRequest_DebeDevolverUnProducto()
        { 
            // Arrange
            var request = new GetProductByIdQueryRequest
            {
                ProductId = productIdGuid
            }; 

            // Act
            var response = await handlerProductById.Handle(request, CancellationToken.None);

            // Assert
            //Assert.IsInstanceOf<ProductDTO>(response);
            Assert.AreEqual(productIdGuid, response.ProductId);
        }

    }
}
