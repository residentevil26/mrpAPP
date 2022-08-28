using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using mrp.Controllers;
using mrp.Data;
using mrpAccesLibrary;
using Radzen;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<AuthenticationStateProvider, auth>();

builder.Services.AddBlazoredLocalStorage();


builder.Services.AddTransient<ILogin, Login>();
builder.Services.AddTransient<Igiris, giris>();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ISqlDataAccess,SqlDataAccess>();
builder.Services.AddTransient<IUrun_kart_data,Urun_kart_data>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddTransient<IMusteri_urun_getir_data, Musteri_urun_getir_data>();
builder.Services.AddTransient<ITedarikci_urun_getir_data, Tedarikci_urun_getir_data>();
builder.Services.AddTransient<IUrun_oz_getir_data, Urun_oz_getir_data>();
builder.Services.AddTransient<IUrun_is_akisi_data, Urun_is_akisi_data>();
builder.Services.AddTransient<IMusteri,Musteri>();
builder.Services.AddTransient<HttpClient>();

builder.Services.AddAuthorization();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
  
});
app.UseAuthentication();





app.Run();
