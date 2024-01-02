using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.Abstract;
using Service.Services.Concrete;
using Data.Context;
using Data.Repositories.Abstract;
using Data.Repositories.Concrete;
using Data.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Service.Extensions;

public static class ServiceLayerExtension
{
    public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddScoped<IArticleService, ArticleService>();

        services.AddAutoMapper(assembly);
        return services;
    }
}
