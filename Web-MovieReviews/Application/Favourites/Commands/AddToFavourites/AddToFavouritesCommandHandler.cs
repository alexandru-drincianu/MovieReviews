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

namespace Application.Favourites.Commands.AddToFavourites
{
    public class AddToFavouritesCommandHandler : IRequestHandler<AddToFavouritesCommand, List<Movie>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly UserManager<User> _userManager;
        public AddToFavouritesCommandHandler(IMovieRepository movieRepository, UserManager<User> userManager)
        {
            _movieRepository = movieRepository;
            _userManager = userManager;
        }
        public async Task<List<Movie>> Handle(AddToFavouritesCommand request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users
                .Include(u => u.Favourites)
                .ThenInclude(f => f.FavouriteMovies)
                .FirstOrDefault(u => u.Id == request.UserId);
            var movie = await _movieRepository.GetById(request.MovieId);
            if (user != null && movie != null)
            {
                user.Favourites.FavouriteMovies.Add(movie);
                await _userManager.UpdateAsync(user);
            }
            return user.Favourites.FavouriteMovies;
        }
    }
}
