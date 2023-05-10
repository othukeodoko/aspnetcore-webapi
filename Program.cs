
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using SimpleProject.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleProject.Data.Services;


var builder = WebApplication.CreateBuilder(args);

//DbContext configuration
builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));
// Add services to the container.
builder.Services.AddScoped<BooksService, BooksService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//var scope = app.Services.CreateScope();
//await DataHelper.ManageDataAsync(scope.ServiceProvider);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//Seed database
AppDbInitializer.Seed(app);
app.Run();
