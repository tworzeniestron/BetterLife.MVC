using Microsoft.EntityFrameworkCore;
using BetterLife.Infrastructure.Extentions;
using BetterLife.Infrastructure.Persistence;
using BetterLife.Infrastructure;
using static System.Formats.Asn1.AsnWriter;
using BetterLife.Application.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());//Sprawdzenie dzia³ania AutoMappera-test

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ConferenceSeeder>();

await seeder.Seed();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
