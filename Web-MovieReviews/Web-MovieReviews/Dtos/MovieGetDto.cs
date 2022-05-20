namespace Web_MovieReviews.Dtos
{
    public class MovieGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MoviePicture { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<ReviewGetDto> Reviews { get; set; }
    }
}
