using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Helpers
{
    public static class JWT
    {
        public static SigningCredentials getCredentials(IConfiguration _config)
        {
            String SecretKey = _config.GetValue<string>("SecurityKey");
            byte[] KeyInBytes = Encoding.ASCII.GetBytes(SecretKey);
            SymmetricSecurityKey key = new SymmetricSecurityKey(KeyInBytes);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            return signingCredentials;
        }
        public static SymmetricSecurityKey getKey(IConfiguration _config)
        {
            String SecretKey = _config.GetValue<string>("SecurityKey");
            byte[] KeyInBytes = Encoding.ASCII.GetBytes(SecretKey);
            SymmetricSecurityKey key = new SymmetricSecurityKey(KeyInBytes);
            return key;
        }
        public static int GetExpiryDuration(IConfiguration _config)
        {
            return _config.GetValue<int>("expiryDuration");
        }

    }
}
