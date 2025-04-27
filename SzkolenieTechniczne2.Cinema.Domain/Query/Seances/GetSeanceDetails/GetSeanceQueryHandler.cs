using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Domain.Query.Dtos;
using SzkolenieTechniczne2.Cinema.Domain.Repositories;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Seances.GetSeanceDetails
{
    public class GetSeanceQueryHandler : IRequestHandler<GetSeanceQuery, SeanceDetailsDTO>
    {
        IMoviesRepository repository;

        public GetSeanceQueryHandler(IMoviesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SeanceDetailsDTO> Handle(GetSeanceQuery query, CancellationToken cancellationToken)
        {
            var movie = await repository.GetSeanceDetailsAsync(query.MovieId);

            if (movie == null)
                throw new NullReferenceException("Given movie doesn't exist.");

            var seance = movie.Seances.SingleOrDefault(x => x.Id == query.SeanceId);

            if (seance == null)
                throw new NullReferenceException("Given seance doesn't exist");

            return new SeanceDetailsDTO(movie.Id, seance.Id, movie.Name, seance.Date);
        }
    }
}
