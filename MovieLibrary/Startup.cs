using Microsoft.Extensions.DependencyInjection;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MovieLibrary
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });

            // Add new lines of code here to register any interfaces and concrete services you create
            services.AddTransient<IMainService, MainService>();
            services.AddSingleton<IFile, FileService>();
            services.AddDbContextFactory<MovieContext>();
            return services.BuildServiceProvider();
        }
    }
}
        
