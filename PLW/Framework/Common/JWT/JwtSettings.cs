namespace Framework.Common.JWT
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; }
        public double ExpireDay { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}