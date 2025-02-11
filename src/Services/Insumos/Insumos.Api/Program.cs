using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Insumos.Application.Behaviors;
using FluentValidation;
using Insumos.Domain.Abstractions;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Insumos.Api.Middleware;
using Insumos.Infraestructure.Repositories;
using Insumos.Infraestructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var presentationAssembly = typeof(Insumos.Presentation.AssemblyReference).Assembly;

builder.Services.AddControllers().AddApplicationPart(presentationAssembly);

var applicationAssembly = typeof(Insumos.Application.AssemblyReference).Assembly;

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

builder.Services.AddScoped<IConceptoRepository, ConceptoRepository>();
builder.Services.AddScoped<IInsumoRepository, InsumoRepository>();

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



//public IConfiguration Configuration { get; }

//public void ConfigureServices(IServiceCollection services)
//{
//    var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

//    services.AddControllers()
//        .AddApplicationPart(presentationAssembly);

//    var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

//    services.AddMediatR(applicationAssembly);

//    services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//    services.AddValidatorsFromAssembly(applicationAssembly);

//    services.AddSwaggerGen(c =>
//    {
//        var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}.xml";

//        var presentationDocumentationFilePath =
//            Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

//        c.IncludeXmlComments(presentationDocumentationFilePath);

//        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
//    });

//    services.AddDbContext<ApplicationDbContext>(builder =>
//        builder.UseNpgsql(Configuration.GetConnectionString("Application")));

//    services.AddScoped<IWebinarRepository, WebinarRepository>();

//    services.AddScoped<IUnitOfWork>(
//        factory => factory.GetRequiredService<ApplicationDbContext>());

//    services.AddScoped<IDbConnection>(
//        factory => factory.GetRequiredService<ApplicationDbContext>().Database.GetDbConnection());

//    services.AddTransient<ExceptionHandlingMiddleware>();
//}

//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    if (env.IsDevelopment())
//    {
//        app.UseDeveloperExceptionPage();

//        app.UseSwagger();

//        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
//    }

//    app.UseMiddleware<ExceptionHandlingMiddleware>();

//    app.UseHttpsRedirection();

//    app.UseRouting();

//    app.UseAuthorization();

//    app.UseEndpoints(endpoints => endpoints.MapControllers());
//}