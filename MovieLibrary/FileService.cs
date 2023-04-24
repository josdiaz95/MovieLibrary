using System;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using MovieLibraryOO.Migrations;

namespace MovieLibrary
{

    public interface IFile
    {
        void Create();
        public string Read();
        void Update();
        void Delete();
    }

    public class FileService : IFile
    {
        //Create movie
        public void Create()
        {
            using (var context = new MovieContext())
            {
                var movie = new Movie();
              
                Console.Write("Add movie title: ");
                var createTitle = FirstLetterCap(Console.ReadLine());
                movie.Title = createTitle;
                Console.Write("Add release date:MM-DD-YYYY\n");
                var movieReleaseDate = System.Console.ReadLine();
                movie.ReleaseDate = DateTime.Parse(movieReleaseDate);
               
                context.Add(movie);
                context.SaveChanges();
                Console.WriteLine($"Movie created: Title {movie.Title})"
                );
            }
        }

      

        //Read movies
        public string Read()
        {
            string result = null;

            using (var context = new MovieContext())
            {
                Console.WriteLine("Enter a keyword/title to search for a movie");
                string movieSearch = Console.ReadLine().ToUpper();

                Console.WriteLine($"\nSearching with ({movieSearch.ToUpper()})");

                var movieList = context.Movies.ToList();

                var foundMovies = movieList.Where(m =>
                    m.Title.Contains(movieSearch, StringComparison.InvariantCultureIgnoreCase));

                if (foundMovies.Any())
                {
                    Console.WriteLine($"\nMovies found:\n");
                    foreach (var m in foundMovies)
                    {
                        result = ($"\n{m.Id}) {m.Title} \nGenres:");
                        Console.WriteLine(result);
                        foreach (var genre in m.MovieGenres )
                        {
                            System.Console.WriteLine($"\t{genre.Genre.Name}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nNo movies found.");
                }

                Console.WriteLine();

                return result;
            }
        }

        //Update  movie
        public void Update()
        {
          using (var context = new MovieContext())
          {
            
            if (Read() != null)
            {
                Console.WriteLine("Enter the ID of the movie to be update:");
                int choice = Int32.Parse(Console.ReadLine());

                var updateMovie = context.Movies.FirstOrDefault(m => m.Id == choice);

                if (updateMovie != null)
                {
                    Console.Write("New movie title: ");
                    var updatedTitle = FirstLetterCap(Console.ReadLine());

                    Console.Write("New release date:MM-DD-YYYY\n ");
                    var updatedReleaseDate = System.Console.ReadLine();

                    

                    updateMovie.Title = updatedTitle + " " + $"({updateMovie.ReleaseDate.Year})";
                    updateMovie.ReleaseDate = Convert.ToDateTime(updatedReleaseDate);

                    context.Movies.Update(updateMovie);
                    context.SaveChanges();
                    Console.WriteLine("Movie Updated!");
                }
            }
            else
            {
                Console.WriteLine("\nMovie can't be updated.");
            }
          }
        }

        //delete movie
        public void Delete()
        {
            using (var context = new MovieContext())
            {
                if (Read() != null)
                { 
                   Console.WriteLine("Enter the ID of the movie to be deleted:");
                   int choice = Int32.Parse(Console.ReadLine());

                   var deleteMovie = context.Movies.FirstOrDefault(m => m.Id == choice);

                   if (deleteMovie != null)
                   {
                       context.Movies.Remove(deleteMovie);
                       Console.WriteLine("Movie successfully deleted.");
                       context.SaveChanges();
                   }
                   else
                   {
                       Console.WriteLine("Movie not deleted.");
                   }
                }
            }
        }
        
        //capitalizing first letter of every word in movie title
        static string FirstLetterCap(string str1)
        {
            return string.Join(" ", str1.Split(' ').Select(str1 => char.ToUpper(str1[0]) + str1.Substring(1)));
        }

    }
}