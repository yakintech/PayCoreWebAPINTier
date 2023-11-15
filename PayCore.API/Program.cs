using FluentValidation;
using FluentValidation.AspNetCore;
using PayCore.BLL.Services;
using PayCore.DAL.ORM.Context;
using PayCore.DTO.Models;
using PayCore.Mapping;
using PayCore.Validation.Models.Category;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PayCoreContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddScoped<IValidator<CreateCategoryRequestDto>, CreateCategoryRequestValidator>();

builder.Services.AddAutoMapper(typeof(CreateProductRequestProfile));


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
