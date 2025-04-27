using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Domain.Query.Dtos
{
    public sealed record SeanceDetailsDTO(long MovieId, long SeanceId, string MovieName, DateTime SeanceDateTime);
}
