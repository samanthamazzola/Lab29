using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab29WebAPI.Models;

namespace Lab29WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //build obj
            moviedbEntities ORM = new moviedbEntities();
            ViewBag.movie = ORM.movies1.ToList();
            ViewBag.Title = "GCFlix Home Page";

            return View();
        }
    }
}
