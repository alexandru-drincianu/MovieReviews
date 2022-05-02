namespace Web_MovieReviews.Dtos
{
    public class ReviewPutPostDto
    {
        public Guid UserId { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }
}
