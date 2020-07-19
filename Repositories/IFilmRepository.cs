using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assday5.DTO;
using assday5.Models;
using assday5.Request;

namespace assday5.Repositories
{
    public interface IFilmRepository
    {
        List<Languages> AllLanguages();

        List<MoviesDTO> MovieByLanguage(int langId);
        List<ReviewsDTO> GetReviewsByMovieId(int MovId);
        bool AddRev(AddReview request);
    }
}