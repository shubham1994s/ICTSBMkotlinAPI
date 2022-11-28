using Microsoft.FeatureManagement.FeatureFilters;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using SwachhBharatAPI.Models;
using System;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace SwachhBharatAPI
{
    internal class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private const string AudiencePropertyKey = "userName";

        private readonly string _issuer = string.Empty;


        private readonly Func<AuthenticationTicket> _contextGetter;
        private string _sIssuer;
        public const string AUDIENCE_PROPKEY = "audience";

        private const string SIGNATURE_ALGORITHM = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
        private const string DIGEST_ALGORITHM = "http://www.w3.org/2001/04/xmlenc#sha256";

        public string Issuer
        {
            get { return _sIssuer; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _sIssuer = value;
            }
        }

        public CustomJwtFormat(Func<AuthenticationTicket> contextGetter)
        {
            if (contextGetter == null) throw new ArgumentNullException("contextGetter");

            _contextGetter = contextGetter;
            Issuer = "https://localhost:44334/";
        }
        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            string audienceId = data.Properties.Dictionary.ContainsKey(AudiencePropertyKey) ? data.Properties.Dictionary[AudiencePropertyKey] : null;

            if(audienceId!=null)
            {
                audienceId = "099153c2625149bc8ecb3e85e03f0022";
            }

            if (string.IsNullOrWhiteSpace(audienceId)) throw new InvalidOperationException("AuthenticationTicket.Properties does not include audience");

            AudienceVM audience = AudiencesStore.FindAudience(audienceId);

            string symmetricKeyAsBase64 = audience.Base64Secret;

            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;

            SigningCredentials credentials = new SigningCredentials(
         new InMemorySymmetricSecurityKey(keyByteArray),
         SIGNATURE_ALGORITHM,
         DIGEST_ALGORITHM);

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime,  credentials);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
           throw new NotImplementedException(protectedText);
            //   Protect(protectedText);
            // return "";

            //return ;
        }
    }
}