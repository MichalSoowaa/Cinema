using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SzkolenieTechniczne2.Cinema.Common.Entities;

namespace SzkolenieTechniczne2.Cinema.Domain.Entities
{
    [Table("Movies", Schema = "Cinema")]
    public class Movie : BaseEntity
    {
        protected Movie()
        {}

        public Movie(string name, int year, int seanceTime)
        {
            Name = name;
            Year = year;
            SeanceTime = seanceTime;
        }

        [MaxLength(256)]
        [Required]
        public string Name { get; protected set; }

        [Range(1888, 2100)]
        public int Year { get; protected set; }

        [Range(1, 600)]
        public int SeanceTime {  get; protected set; }

        public long MovieCategoryId { get; protected set; }
        public MovieCategory MovieCategory { get; protected set; }

        public virtual ICollection<Seance> Seances { get; protected set; }

        public Seance GetSeanceByDateAndRoomId(DateTime date)
            => Seances.SingleOrDefault(x => DateTime.Compare(x.Date, date) == 1);

        public void SetName(string name) => Name = name;
        public void SetYear(int year) => Year = year;
        public void SetSeanceTime(int seanceTime) => SeanceTime = seanceTime;
    }
}
