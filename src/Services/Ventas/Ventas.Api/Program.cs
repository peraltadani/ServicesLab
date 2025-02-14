using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Ventas.Application.Behaviors;
using FluentValidation;
using Ventas.Domain.Abstractions;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ventas.Api.Middleware;
using Ventas.Infraestructure.Repositories;
using Ventas.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var presentationAssembly = typeof(Ventas.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

var applicationAssembly = typeof(Ventas.Application.AssemblyReference).Assembly;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

//    var presentationDocumentationFilePath =
//        Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

//    c.IncludeXmlComments(presentationDocumentationFilePath);

//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
//});

builder.Services.AddDbContext<ApplicationDbContext>(b =>
      b.UseSqlServer(builder.Configuration.GetConnectionString("Application")));

builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();

builder.Services.AddScoped<IUnitOfWork>(
    factory => factory.GetRequiredService<ApplicationDbContext>());

builder.Services.AddScoped<IDbConnection>(
    factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
