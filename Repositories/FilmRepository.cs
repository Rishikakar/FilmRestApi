using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assday5.DTO;
using assday5.Models;
using assday5.Request;

namespace assday5.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmDbContext db;

        public FilmRepository(FilmDbContext _db)
        {
            this.db = _db;
        }

        public List<Languages> AllLanguages()
        {
            return db.Languages.ToList();
        }

        public List<ReviewsDTO> GetReviewsByMovieId(int MovieeId)
        {
            var reviews = db.Review.Include("Movie").Where(a => a.Movie.MovieId == MovieeId).ToList();
            List<ReviewsDTO> reviewData = new List<ReviewsDTO>();

            foreach (var review in reviews)
            {
                reviewData.Add(new ReviewsDTO
                {
                    Id = review.Id,
                    ReviewContent = review.Review,
                    ReviewForMovie = review.Movie.Name
                });
            }
            return reviewData;
        }

        public List<MoviesDTO> MovieByLanguage(int langId)
        {

            var movies = db.Movies.Include("Language").Where(a => a.Language.Id == langId).ToList();
            List<MoviesDTO> movieData = new List<MoviesDTO>();

            foreach (var movie in movies)
            {
                movieData.Add(new MoviesDTO
                {
                    MovieName = movie.Name,
                    MovieLanguage = movie.Language.Language
                });
            }

            return movieData;


        }

        public bool AddRev(AddReview request)
        {
            if (request.SeeReview != null && request.MovieId > 0)
            {
                //var movie = db.Movies.Where(a => a.MovieId == request.MovieId).FirstOrDefault();
                
                Reviews review = new Reviews();
                review.Review = request.SeeReview;
                review.MovieId = request.MovieId;
                db.Review.Add(review);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}