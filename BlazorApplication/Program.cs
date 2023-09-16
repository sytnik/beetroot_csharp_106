using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using MudBlazor.Services;
using ShopLibrary.Dbo;
using ShopLibrary.Util;

var builder = WebApplication.CreateBuilder(args);
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddShopServices();
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
application.Services.CreateAsyncScope().ServiceProvider
    .GetService<ShopContext>().Publish();
application.Run();