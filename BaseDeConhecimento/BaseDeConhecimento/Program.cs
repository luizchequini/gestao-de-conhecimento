using BaseDeConhecimento.Application.AutoMapper;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Application.Servicos;
using BaseDeConhecimento.Domain.InterfacesDominio;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Domain.Servicos;
using BaseDeConhecimento.Infraestrutura.Contexto;
using BaseDeConhecimento.Infraestrutura.Respositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configurations = builder.Configuration;
var conn = configurations.GetConnectionString("conn");
builder.Services.AddDbContext<BaseDeConhecimentoContext>(options => options.UseLazyLoadingProxies().UseSqlServer(conn));
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddScoped<IConhecimentoService,ConhecimentoServico>();
builder.Services.AddScoped<IServicoDeDominioConhecimento,ServicoDeDominioConhecimento>();
builder.Services.AddScoped< IRepositorioConhecimento  , RepositorioConhemento>();
builder.Services.AddScoped< IRepositorioCategoria , RepositorioCategoria>();

var app = builder.Build();

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
