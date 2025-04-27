using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Command.Seances.Register
{
    public sealed record RegisterSeanceCommand(long MovieId, DateTime SeanceDate) : IRequest<Result>;
}
