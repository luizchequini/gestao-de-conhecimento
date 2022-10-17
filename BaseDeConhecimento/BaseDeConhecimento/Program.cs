using BaseDeConhecimento.Application.AutoMapper;
using BaseDeConhecimento.Application.Interfaces;
using BaseDeConhecimento.Application.Servicos;
using BaseDeConhecimento.Domain.InterfacesDominio;
using BaseDeConhecimento.Domain.InterfacesRepositorio;
using BaseDeConhecimento.Domain.Servicos;
using BaseDeConhecimento.Infraestrutura.Contexto;
using BaseDeConhecimento.Infraestrutura.Respositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    {
        options.EnableEndpointRouting = false;
        options.Filters.Add(new ProducesAttribute("application/json"));
    }
).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configurations = builder.Configuration;
var conn = configurations.GetConnectionString("conn");
builder.Services.AddDbContext<BaseDeConhecimentoContext>(options => options.UseSqlServer(conn));
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IServicoDeDominioCategoria, ServicoDeDominioCategoria>();

builder.Services.AddScoped<IConhecimentoService, ConhecimentoServico>();
builder.Services.AddScoped<IServicoDeDominioConhecimento, ServicoDeDominioConhecimento>();
builder.Services.AddScoped<IRepositorioConhecimento, RepositorioConhemento>();

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
