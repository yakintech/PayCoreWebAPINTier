using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PayCore.API.Models.Filters;
using PayCore.BLL.Services;
using PayCore.DAL.ORM.Context;
using PayCore.DAL.ORM.Entity.User;
using PayCore.DTO.Models;
using PayCore.Mapping;
using PayCore.Validation.Models.Category;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddIdentity<WebUser, IdentityRole>()
.AddEntityFrameworkStores<PayCoreContext>();

builder.Services.AddDbContext<PayCoreContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "cagatay@mail.com",
        ValidAudience = "cagatay2@mail.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("loremipsimloremipsimloremipsimloremipsimloremipsim")),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
}));




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

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("corsapp");

app.MapControllers();

app.Run();
