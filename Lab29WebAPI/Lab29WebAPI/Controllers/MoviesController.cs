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
        //URL.../api/lab29/GetMoviesPerCategory
        [HttpGet]
        public List<movie> MoviesByCategory(string category)
        {
            //ORM
            moviedbEntities ORM = new moviedbEntities();
            //create list
            List<movie> movieList = ORM.movies1.ToList();

            return ORM.movies1.Where(x => x.category.ToLower() == category).ToList();
        }


    }
}