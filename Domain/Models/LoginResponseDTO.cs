namespace Domain.Models
{
    public class LoginResponseDTO
    {
        public string JwtToken { get; set; }

        public DateTimeOffset Expires { get; set; }
    }
}
