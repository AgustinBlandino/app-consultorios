using Microsoft.EntityFrameworkCore;
using API_ObrasSociales;
using API_ObrasSociales.Factory;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Contexto>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddScoped<IObrasSocialesFactory, ObrasSocialesFactory>();
builder.Services.AddScoped<ITurnosFactory, TurnosFactory>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalhost54448", builder =>
    {
        builder.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowLocalhost54448");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();


});



app.MapFallbackToFile("index.html"); ;

app.Run();
