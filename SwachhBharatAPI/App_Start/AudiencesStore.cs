using Microsoft.Owin.Security.DataHandler.Encoder;
using SwachhBharatAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using Microsoft.FeatureManagement.FeatureFilters;


namespace SwachhBharatAPI
{
    public static class AudiencesStore
    {
        public static ConcurrentDictionary<string, AudienceVM> AudiencesList = new ConcurrentDictionary<string, AudienceVM>();

        static AudiencesStore()
        {
            AudiencesList.TryAdd("099153c2625149bc8ecb3e85e03f0022",
                                new AudienceVM
                                {
                                    ClientId = "099153c2625149bc8ecb3e85e03f0022",
                                    Base64Secret = "IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw",
                                    Name = "ResourceServer.Api 1"
                                });
        }

        public static AudienceVM AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            AudienceVM newAudience = new AudienceVM { ClientId = clientId, Base64Secret = base64Secret, Name = name };
            AudiencesList.TryAdd(clientId, newAudience);
            return newAudience;
        }

        public static AudienceVM FindAudience(string clientId)
        {
            AudienceVM audience = null;
            if (AudiencesList.TryGetValue(clientId, out audience))
            {
                return audience;
            }
            return null;
        }
    }

}
