using FluentValidation.AspNetCore;
using Gevangenis.Application;
using Gevangenis.EFCoreMigrations;
using Gevangenis.Web;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//version
builder.Services.AddApiVersioning(x => {
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<PrisonContext>
    (options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterApplication();
builder.Services.RegisterDependencies();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMvc().AddFluentValidation(fv => fv.DisableDataAnnotationsValidation = false);
var app = builder.Build();


/**********************************************************/

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
