using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;
using checkers.Infrastructure.Repositories;
using checkers.Infrastructure.Repositories.Interfaces;
using checkers.Infrastructure.Utils;
using checkers.Models;
using checkers.Services;
using checkers.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace checkers.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAllDependencies(this IServiceCollection service)
        {
            return service
                .AddInfrastructureDependencies()
                .AddApplicationDependencies();
        }

        /*
         * Method to add DI for Infrastructure folder
         */
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IRepository<Square>, SquareRepository>()
                .AddScoped<SquareRepository>()
                .AddScoped<IRepository<Checker>, CheckerRepository>()
                .AddScoped<CheckerRepository>()
                .AddScoped<IRepository<Board>, BoardRepository >()
                .AddScoped<BoardRepository>();
        }

        public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
        {
            return service
                .AddScoped<IService<SquareDto>, SquareService> ()
                .AddScoped<IService<CheckerDto>, CheckerService>()
                .AddScoped<IService<BoardDto>, BoardService>()
                //.AddScoped<IService<SquareDto>, ServiceBase<SquareDto, Square>>()
                //.AddScoped<IService<SquareDto>, TestService>()
                //.AddScoped<ServiceBase<SquareDto, Square>, TestService>()
                .AddScoped<TestService>()
                .AddSingleton<ITimeService, TimeService>();
        }
    }
}
