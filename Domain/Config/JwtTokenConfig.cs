namespace Domain.Config
{
    public class JwtTokenConfig
    {
        public string Issuer { get; set; } = "thisismeyouknow";
        public string Audience { get; set; } = "thisismeyouknow";
        public int ExpiryInMinutes { get; set; } = 60 * 24 * 3;
        public string Key { get; set; } = "thiskeyisverylargetobreak";
    }
}