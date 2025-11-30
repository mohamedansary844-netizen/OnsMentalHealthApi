namespace OnsMentalHealth.BLL.DTOs
{
    public class ReactionResponseDto
    {
        public int ReactionId { get; set; }
        public bool Love { get; set; }
        public bool Angry { get; set; }
        public bool Like { get; set; }
        public string UserId { get; set; }
        public int? TherapistId { get; set; }
    }
}
