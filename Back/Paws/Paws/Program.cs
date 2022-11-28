using Application.Interfaces;
using Application.Main;
using Application.Main.Helper;
using Domain.Entity;
using Domain.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PawSettings>(builder.Configuration.GetSection("PawSettings"));

//Dependency injection

builder.Services.AddSingleton<IPawSettings>(d =>d.GetRequiredService<IOptions<PawSettings>>().Value);

builder.Services.AddScoped<IVetApplication, VetApplication>();
builder.Services.AddScoped<IRepository<Vet>, Repository<Vet>>();

builder.Services.AddScoped<IPetApplication, PetApplication>();
builder.Services.AddScoped<IRepository<Pet>, Repository<Pet>>();
// Add services to the container.



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
