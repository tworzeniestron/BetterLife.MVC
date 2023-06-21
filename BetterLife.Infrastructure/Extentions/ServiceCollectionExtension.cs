using BetterLife.Application.Mappings;
using BetterLife.Domain.Interfaces;
using BetterLife.Infrastructure.Persistence;
using BetterLife.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Infrastructure.Extentions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConferenceDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ConferenceDbConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ConferenceDbContext>();

            services.AddScoped<ConferenceSeeder>();

            services.AddScoped<IConferenceRepository, ConferenceRepository>();

            services.AddAutoMapper(typeof(ConferenceMappingProfile));
        }
    }
}
