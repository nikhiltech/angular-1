using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/<controller>
        public object Get()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        // GET api/<controller>
        public IEnumerable<Movie> Get(int id)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Movie> MyMethod(int id)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        [HttpPost]
        public object PostMethod(PostMethodParams @params)
        {
            var t = @params;

            return new
            {
                Success = true,
                Value = "Some value"
            };
        }

        [HttpGet]
        public IEnumerable<Movie> GetMethod()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie(1, "Moolen"),
                new Movie(2, "Broken heart")
            };

            return movies;
        }

        [HttpGet]
        public object GetMethod(int id)
        {
            var t = id;
            
            return new
            {
                Success = true,
                Value = "Some value"
            };
        }
    }

    public class PostMethodParams
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
