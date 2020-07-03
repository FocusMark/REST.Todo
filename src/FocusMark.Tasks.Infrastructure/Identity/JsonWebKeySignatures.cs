using Microsoft.IdentityModel.Tokens;

namespace FocusMark.Tasks.Infrastructure.Identity
{
    public class JsonWebKeySignatures
    {
        public JsonWebKey[] Keys { get; set; }
    }
}
