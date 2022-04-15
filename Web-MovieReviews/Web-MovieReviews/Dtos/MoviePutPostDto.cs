namespace Web_MovieReviews.Dtos
{
    public class MoviePutPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<int> GenresIds { get; set; }
    }
}
