namespace MovieApi.Domain.DTOs
{
    public class ReviewDto
    {
        public int ReviewID { get; set; }
        public string ReviewComment { get; set; }
        public int UserRating { get; set; }
        public DateTime ReviewDate { get; set; }
        public bool Status { get; set; }

        // İsterseniz kullanıcı bilgilerini de dahil edebilirsiniz
        public string UserName { get; set; }
    }
}
