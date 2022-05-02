namespace Web_MovieReviews.Dtos
{
    public class ReviewGetDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
    }
}
