using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Infrastructure.Persistence;
using eCommerceInfnet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("EcommerceDb");

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection))
    .EnableSensitiveDataLogging());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
