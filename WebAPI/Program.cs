using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.OpenApi.Models;
using Infra.Data.Repositories;
using AutoMapper;
using MediatR;
using Core.Application.CasosUso.Produtos.Queries;
using Microsoft.AspNetCore.Identity;
using Infra.Data.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoClient>(s =>
{
    var settings = s.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Adicionando suporte ao CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando o ProdutoRepository
builder.Services.AddScoped<ProdutoRepository>();

// Registrando MediatR
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

// Registrando AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuração do Entity Framework para Identity
builder.Services.AddDbContext<IdentityDbContext>(options =>
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders());


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Altere conforme a porta do Vue
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Middleware de CORS
app.UseCors("AllowAll");

// Habilita autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowVueApp");
app.MapControllers();

// Endpoint para testar a conexão com o MongoDB
app.MapGet("/test-mongodb", (IMongoClient client) =>
{
    var database = client.GetDatabase("EcommerceDB");
    var collections = database.ListCollectionNames().ToList();
    return Results.Ok(collections);
});

// Endpoint básico para verificar o funcionamento da API
app.MapGet("/", () => "API funcionando com MongoDB!");

app.Run();
