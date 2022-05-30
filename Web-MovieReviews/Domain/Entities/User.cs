using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public Favourites Favourites { get; set; } = new Favourites() { FavouriteMovies = new List<Movie>()};
    }
}
