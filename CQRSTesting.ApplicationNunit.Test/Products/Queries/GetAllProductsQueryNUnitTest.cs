using AutoFixture;
using AutoMapper;
using CQRSTesting.Application.Helper;
using CQRSTesting.Domain.Entities;
using CQRSTesting.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace CQRSTesting.Application.Products.Queries
{
    [TestFixture]
    public class GetAllProductsQueryNUnitTest
    {
        // declarar una variable que represente GetProductsQueryHandler
        private GetAllProductsQuery.GetAllProductsQueryHandler handlerAllProducts;

        [SetUp]
        public void SetUp()
        {
            // FAKE DATA - AutoFixture
            // Fixture nos permite crear data de prueba con el paquete AutoFixture
            var fixture = new Fixture();
            var productRecords = fixture.CreateMany<Product>(10).ToList(); // creamos 10 productos - un conjunto de records

            productRecords.Add(fixture.Build<Product>() // creamos un producto con id = Guid.Empty
                .With(tr => tr.ProductId, Guid.Empty)
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
            handlerAllProducts = new GetAllProductsQuery.GetAllProductsQueryHandler(ApplicationDbContextFake, mapper);

        }

        [Test]
        public async Task GetAllProductsQueryRequest_DebeDevolverUnaListaDeProductos()
        {
            // 1.- Emular al contexto que representa la base de datos - LISTO
            // 2.- Emular al mapper - LISTO
            // 3.- Instancia un objeto de la clase GetProductsQueryHandler y pasarle como parámetros los objetos context y mapper emulados
            // GetProductsQueryHandler(context, mapper) => handle - LISTO
            GetAllProductsQuery.GetAllProductsQueryRequest request = new();

            var resultados = await handlerAllProducts.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);
        }
    }
}
