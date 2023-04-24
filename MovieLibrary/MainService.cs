using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MovieLibrary
{

    public interface IMainService
    {
        void Invoke();
    }

    public class MainService : IMainService
    {
        private MovieContext _dbContext;
        private readonly IDbContextFactory<MovieContext> _dbContextFactory;
        private readonly IFile _fileService;

        //default constructor
        public MainService(ILogger<MainService> logger, IFile fileService)
        {
            _fileService = fileService;
        }

        public void Invoke()
        {
            bool done = false;
            string choice;
            do
            {
                Console.WriteLine("\n-------------------");
                Console.WriteLine("**WELCOME TO THE MOVIE LIBRARY**");
                Console.WriteLine("-------------------");
                //ask user a question
                Console.WriteLine("Select a choice:\n1)Display Movies\n2)Add Movie\n3)Update Movie\n4)Delete Movie\n5)Exit");
                // input response
                choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        _fileService.Read();
                        break;

                    case "2":
                        _fileService.Create();
                        break;

                    case "3":
                        _fileService.Update();
                        break;

                    case "4":
                        _fileService.Delete();
                        break;

                    case "5":
                        done = true;
                        Console.WriteLine("Thank you for using the Movie Library!");
                        break;
                    default:
                        Console.WriteLine("Invalid key. Try Again!");
                        break;
                }

            } while (!done);
        }
    }



}

