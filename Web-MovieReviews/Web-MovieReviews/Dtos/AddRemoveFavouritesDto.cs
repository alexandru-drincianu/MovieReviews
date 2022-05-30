namespace Web_MovieReviews.Dtos
{
    public class AddRemoveFavouritesDto
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
    }
}
