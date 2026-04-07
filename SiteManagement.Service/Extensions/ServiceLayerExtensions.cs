using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiteManagement.Data.Context;
using SiteManagement.Data.Repositories.Abstractions;
using SiteManagement.Data.Repositories.Concretes;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Service.Services.Abstractions;
using SiteManagement.Service.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SiteManagement.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IBlockService, BlockService>();

            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
