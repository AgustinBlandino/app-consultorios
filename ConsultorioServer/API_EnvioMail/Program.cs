using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using API_EnvioMail;
using API_EnvioMail.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Contexto>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
builder.Services.AddSingleton<IMailFactory, MailFactory>();
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
