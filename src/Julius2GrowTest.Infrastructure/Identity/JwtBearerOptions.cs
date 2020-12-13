namespace Julius2GrowTest.Infrastructure.Identity
{
    public class JwtBearerOptions
    {
        public const string JwtBearer = "JwtBearer";

        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresIn { get; set; }
    }
}
