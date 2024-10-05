using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
