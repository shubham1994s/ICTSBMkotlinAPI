﻿using Microsoft.FeatureManagement.FeatureFilters;
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

            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}