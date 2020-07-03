using Microsoft.IdentityModel.Tokens;

namespace FocusMark.Tasks.Api
{
    public class TokenIssuer
    {
        public string Url { get; set; }
        public string DiscoveryDocument { get; set; }
        public JsonWebKey[] Keys { get; set; }
    }
}
