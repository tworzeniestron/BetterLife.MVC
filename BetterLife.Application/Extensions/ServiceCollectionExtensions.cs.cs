using AutoMapper;
using BetterLife.Application.ApplicationUser;
using BetterLife.Application.Conference;
using BetterLife.Application.Conference.Commands.CreateConference;
using BetterLife.Application.Mappings;

using BetterLife.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();//1-autoryzacja
            services.AddMediatR(typeof(CreateConferenceCommand));

            services.AddAutoMapper(typeof(CreateConferenceCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new ConferenceMappingProfile(userContext));
            }).CreateMapper()
            );
    
            services.AddValidatorsFromAssemblyContaining<CreateConferenceCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
