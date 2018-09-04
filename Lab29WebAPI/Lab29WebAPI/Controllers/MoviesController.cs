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
        //.... /api/movies/GetRandomMovie
        [HttpGet]
        public movie GetRandomMovieByCategory()
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

        //get movie info by title SEARCH 
        //URL..../
        [HttpGet]
        public List<movie> SearchMovieByTitle(string title)
        {
            //obj
            moviedbEntities ORM = new moviedbEntities();

            List<movie> movieList = ORM.movies1.ToList();

            return ORM.movies1.Where(x => x.title.ToLower().Contains
            (title.ToLower())).ToList();
        }


    }
}