namespace Web_MovieReviews.Dtos
{
    public class GenreGetDto
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public ICollection<MovieGetDto> Movies { get; set; }
    }
}
