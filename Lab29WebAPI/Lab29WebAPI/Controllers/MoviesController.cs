using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29WebAPI.Models;

namespace Lab29WebAPI.Controllers
{
    public class MoviesController : ApiController
    {

        //get list of * movies
        [HttpGet]
        public List<movie> GetAllMovies()
        {
            //.../api/movies/GetAllMovies
            //ORM create obj
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movieList = ORM.movies1.ToList();

            return movieList;
        }

        //get list of movies per category
        //URL.../api/Movies/MoviesByCategory?category={category}
        [HttpGet]
        public List<movie> MoviesByCategory(string category)
        {
            //ORM
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movieList = ORM.movies1.ToList();

            return ORM.movies1.Where(x => x.category.ToLower() == category).ToList();
        }

        //action to get random movie pick
        //.... /api/movies/GetRandomMovie
        [HttpGet] 
        public movie GetRandomMovie()
        {
            //ORM
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movies1 = ORM.movies1.ToList();
            //use random number to select a joke
            Random r = new Random();
            int selected = r.Next(0, movies1.Count);

            return movies1[selected];
        }

        //action to get random movie pick by category
        [HttpGet]
        public movie GetRandomMovieByCategory(string category)
        {
            //url.... /api/movies/GetRandomMovieByCategory?category=SciFi
            //ORM
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> moviesByCateogry = ORM.movies1.Where(x => x.category.ToLower() == category.ToLower()).ToList();
            Random n = new Random();
            int selected = n.Next(0, moviesByCateogry.Count());

            return moviesByCateogry[selected];
        }

        //get random movie by quantity
        [HttpGet]
        public List<movie> GetRandomMoviesByQuantity(int quantity) 
        {
            //url.....api/movies/GetRandomMoviesByQuantity?quantity=1
            //obj
            moviedbEntities ORM = new moviedbEntities();
            List<movie> movieList = ORM.movies1.ToList();

            List<movie> randomMovies = new List<movie>();
            for (int i = 0; i < quantity; i++)
            {
                Random r = new Random();
                int selected = r.Next(0, randomMovies.Count());
                randomMovies.Add(randomMovies[selected]);
            }
            return randomMovies;
        }

        public List<string> GetShowCategories()
        {
            //...../api/movies/GetShowCategories
            moviedbEntities ORM = new moviedbEntities();

            return ORM.movies1.Where(x => x.category != null).Select(x => x.category).Distinct().ToList();
        }

        [HttpGet]
        public List<movie> SearchMovieTitles(string Search)
        {
            //...../api/movies/SearchMovieTitles?Search=27
            moviedbEntities ShowsORM = new moviedbEntities();

            List<movie> movieList = ShowsORM.movies1.ToList();
            List<movie> searchResults = new List<movie>();
            for (int i = 0; i < movieList.Count; i++)
            {
                if (movieList[i].title.Contains(Search))
                {
                    searchResults.Add(movieList[i]);
                }
            }
            return searchResults;
        }


    }
}