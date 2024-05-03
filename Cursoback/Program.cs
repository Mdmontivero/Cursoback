using Cursoback.DTOs;
using Cursoback.Model;
using Cursoback.Services;
using Cursoback.Validator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Cursoback.Repository;
using Cursoback.Automappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddSingleton<IPeopleService,People2Service>();




builder.Services.AddKeyedScoped<ICommonService<BeerDto, BeerInsertDto, BeerUpdateDto>, BeerService>("beerService");

//Repository

builder.Services.AddScoped<IRepository<Beer>, BeerRepository>();

  // Entity FrameWork

builder.Services.AddDbContext<TiendaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Tiendaconnection"));
});



  // Validadores (Validator)

builder.Services.AddScoped<IValidator<BeerInsertDto>, BeerInsertValidator>();

builder.Services.AddScoped<IValidator<BeerUpdateDto>, BeerUpdateValidator>();

//Mappers

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
