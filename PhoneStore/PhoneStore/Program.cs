using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;
using PhoneStore.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PhoneStoreContext>(options => options.UseSqlite(connection));

var pathCurrencies = Path.Combine(builder.Environment.WebRootPath, "CurrenciesList", "Currencies.json");
List<CurrencyRates> currencyRates = new List<CurrencyRates>();
if (File.Exists(pathCurrencies))
{
    string jsonContent = File.ReadAllText(pathCurrencies);
    currencyRates = JsonSerializer.Deserialize<List<CurrencyRates>>(jsonContent) ?? new List<CurrencyRates>();
}

builder.Services.AddSingleton(currencyRates);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phone}/{action=Index}/{id?}");

app.Run();