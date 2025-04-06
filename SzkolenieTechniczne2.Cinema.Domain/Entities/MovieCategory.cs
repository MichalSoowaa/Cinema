using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities
{
    [Table("MovieCategories", Schema = "Cinema")]
    public class MovieCategory : BaseEntity
    {
        protected MovieCategory()
        { }

        public MovieCategory(string name)
        {
            Name = name;
        }

        [Required]
        [MaxLength(256)]
        public string Name {  get; protected set; }

        public virtual ICollection<Movie> Movies { get; protected set; } = new List<Movie>();
    }
}
