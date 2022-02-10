namespace Domain.Models
{
    public class LoginResponseDTO
    {
        public string UserName { get; set; }
        public string JwtToken { get; set; }
        public DateTimeOffset Expires { get; set; }
    }
}
