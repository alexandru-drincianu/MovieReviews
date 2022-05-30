using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Favourites.Queries.GetFavourites
{
    public class GetFavouritesQueryHandler : IRequestHandler<GetFavouritesQuery, List<Movie>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMovieRepository _movieRepository;

        public GetFavouritesQueryHandler(UserManager<User> userManager, IMovieRepository movieRepository)
        {
            _userManager = userManager;
            _movieRepository = movieRepository;
        }
        public async Task<List<Movie>> Handle(GetFavouritesQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users
                .Include(u => u.Favourites)
                .ThenInclude(f => f.FavouriteMovies)
                .FirstOrDefault(u => u.Id == request.UserId);
            return await Task.FromResult(user.Favourites.FavouriteMovies);
        }
    }
}
