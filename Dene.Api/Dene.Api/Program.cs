using Dene.Api.Extensions;
using Dene.Data.Concrete.Ef;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependency();
builder.Services.AddCorsForAbrh();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddSession();
builder.Services.AddAuthentication();
builder.Services.AddJwt();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerDocumentation();
app.UseHttpsRedirection();
app.UseJwt();
app.UseAuthorization();
app.UseCorsForAbrh();
app.MapControllers();
app.Run();
