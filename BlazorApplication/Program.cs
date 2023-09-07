using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using BlazorApplication.Data;
using LmsClassLibrary.Util;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.RegisterContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddMudServices();
var application = builder.Build();
if (!application.Environment.IsDevelopment())
{
    application.UseExceptionHandler("/Error");
    application.UseHsts();
}

application.UseHttpsRedirection();
application.UseStaticFiles();
application.UseRouting();
application.MapBlazorHub();
application.MapFallbackToPage("/_Host");
application.Run();