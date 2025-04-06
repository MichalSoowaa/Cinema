using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne2.Cinema.Common.Entities
{
    public interface ISoftDeletable
    {
        bool isDeleted { get; set; }
    }
}
