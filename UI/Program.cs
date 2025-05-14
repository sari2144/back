using BL.Api;
using BL;
using DAL.Models;
using UI.Controllers;
using UI;
using System.Text.Json.Serialization;
using ConnectingApps.SmartInject;
using BL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBL,BLManager>();
/////////////////////////////
//builder.Services.AddLazySingleton<IBLAvialableQueue,BLAvialableQueueService>();
////////////////////////////////
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
////////////באהבה משרי וגמן
builder.Services.AddControllersWithViews()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
///////////

builder.Services.AddCors(c => c.AddPolicy("AllowAll",
    option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//להעתיק אחרי הגדרת ה app


var app = builder.Build();
app.UseCors("AllowAll");
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
