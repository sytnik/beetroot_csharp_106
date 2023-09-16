using LmsClassLibrary.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using MvcApplication.Logic;
using MvcApplication.Services;
using ShopLibrary.Dbo;
using ShopLibrary.Util;

namespace MvcApplication;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddShopServices();
        // builder.Services.AddScoped<IUniversityStructureService, UniversityStructureService>();
        builder.Services
            .AddAuthentication(options =>
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/Home/Login");
        var application = builder.Build();
        if (application.Environment.IsDevelopment()) application.UseDeveloperExceptionPage();
        else if (application.Environment.IsProduction()) application.UseExceptionHandler("/Home/Error");
        application.UseHsts();
        application.UseHttpsRedirection();
        application.UseStaticFiles();
        application.UseRouting();
        application.UseAuthentication();
        application.UseAuthorization();
        application.UseSwagger();
        application.UseSwaggerUI();
        application.MapDefaultControllerRoute();
        application.Services.CreateAsyncScope().ServiceProvider
            .GetService<ShopContext>().Publish();
        application.SetupApis();
        application.Run();
    }
}