using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcApplication.Logic;

namespace LmsClassLibrary.Util;

public static class Dbo
{
    public static void RegisterContext(this IServiceCollection collection, string connectionString) =>
        collection.AddDbContext<EposContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));
}