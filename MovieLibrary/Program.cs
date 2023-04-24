using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Dao;
using MovieLibraryEntities.Models;

namespace MovieLibrary;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var startup = new Startup();
            var serviceProvider = startup.ConfigureServices();
            var service = serviceProvider.GetService<IMainService>();
            service?.Invoke();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

        }
    }
}

