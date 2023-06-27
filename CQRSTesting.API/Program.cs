//using CQRSTesting.Application.Products.Commands;
using CQRSTesting.Application.Products;
using CQRSTesting.Application.Products.Commands;
using CQRSTesting.Application.Products.Queries;
using CQRSTesting.Persistence.Context;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddProductModule();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// EN ESTA FORMA DE DECLARACION NO ES NECESARIO DECLARAR CADA COMMAND Y QUERY, UNA VEZ CON ESTE LA APP TOMARA EN CUENTA TODAS LAS CLASES QUE HEREDEN DE IRequestHandler
builder.Services.AddMediatR(typeof(GetAllProductsQuery.GetAllProductsQueryHandler).Assembly);
////builder.Services.AddMediatR(typeof(Program));   
////builder.Services.AddMediatR(typeof(GetAllProductsQuery.GetAllProductsQueryHandler).GetTypeInfo().Assembly);
////builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
////builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// fluent validation configuration
builder.Services.AddControllers()
    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CreateProductCommand>());

// auto mapper configuration
builder.Services.AddAutoMapper(typeof(GetAllProductsQuery.GetAllProductsQueryHandler));

builder.Services.AddCors(o => o.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "CQRSTesting.API", Version = "v1" });
});


var app = builder.Build();

app.UseCors("corsApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
