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
        //URL.../api/lab29/GetAllMovies
        [HttpGet]
        public List<movie> GetAllMovies()
        {
            //ORM create obj
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movieList = ORM.movies.ToList();

            return movieList;
        }

        //get list of movies per category
        //URL.../api/lab29/GetMoviesPerCategory
        [HttpGet]
        public List<movie> MoviesByCategory(string category)
        {
            //ORM
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movieList = ORM.movies.ToList();

            return ORM.movies.Where(x => x.category.ToLower() == category).ToList();
        }


    }
}