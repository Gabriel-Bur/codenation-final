namespace Api
{
    public class AppSecret
    {
        public string Key { get; set; }
        public int Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
