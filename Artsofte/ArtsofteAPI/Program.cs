using ArtsofteAPI.Validators;
using BLL.Interfaces;
using BLL.Service;
using DAL.EF;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//DbContext
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddEmployeeValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateEmployeeValidator>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(build =>
    {
        build.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(
    opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();