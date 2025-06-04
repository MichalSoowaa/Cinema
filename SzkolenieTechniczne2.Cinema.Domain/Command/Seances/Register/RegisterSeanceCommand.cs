using MediatR;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances.Register
{
    public sealed record RegisterSeanceCommand(long MovieId, DateTime SeanceDate) : IRequest<Result>;
}
