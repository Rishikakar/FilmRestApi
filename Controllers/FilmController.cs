using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using assday5.Repositories;
using assday5.Request;

namespace assday5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository repository;

        public FilmController(IFilmRepository repository)

        {
            this.repository = repository;
        }

        [HttpGet("Languages")]

        public IActionResult Languages()
        {
            return Ok(repository.AllLanguages());
        }

        [HttpGet("MoviesByLanguage/{langId}")]
        public IActionResult MovieByLanguage(int langId)
        {
            return Ok(repository.MovieByLanguage(langId));
        }

        [HttpGet("ReviewByMovieId/{MovId}")]
        public IActionResult ReviewByMovieId(int MovId)
        {
            return Ok(repository.GetReviewsByMovieId(MovId));
        }

       

        [HttpPost("AddReview")]
        public IActionResult AddGrade(AddReview data)
        {
            return Ok(repository.AddRev(data));
        }
    }
}