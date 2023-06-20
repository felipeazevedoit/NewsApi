using ewsAPI.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Domain.Interfaces;
using NewsAPI.Repository.Implementation;
using NewsAPI.Repository;
using NewsAPI.Aplication.Interfaces;
using NewsAPI.Aplication.Services;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using NewsAPI.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);



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


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
builder.Services.AddScoped<INewsArticleApp, NewsArticleApp>();
builder.Services.AddScoped<ICategoryApp, CategoryApp>();
builder.Services.AddScoped<ISourceApp, SourceApp>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
