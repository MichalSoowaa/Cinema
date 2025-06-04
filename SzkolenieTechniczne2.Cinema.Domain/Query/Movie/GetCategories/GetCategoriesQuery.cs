using MediatR;
using SzkolenieTechniczne2.Cinema.Domain.Query.DTOs;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Movie.GetCategories
{
    public class GetCategoriesQuery : IRequest<List<CategoryDTO>>
    {

    }
}
