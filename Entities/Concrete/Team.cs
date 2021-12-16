using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Team : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string TeamName { get; set; }
        public int PlayerCount { get; set; }
        public DateTime YearOfFoundation { get; set; }
        public int Budget { get; set; }
    }
}
