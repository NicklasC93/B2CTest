using System;
using System.Collections.Generic;
using System.Text;

namespace B2CTest
{
    public static class Constants
    {
        public static readonly string TenantName = "padeldrengene";
        public static readonly string TenantId = "padeldrengene.onmicrosoft.com";
        public static readonly string ClientId = "cdc54b78-8859-489c-a570-54d675218578";
        public static readonly string SignInPolicy = "B2C_1_signupsignin1";
        public static readonly string IosKeychainSecurityGroups = "com.<yourcompany>.<groupname>"; // e.g com.contoso.aadb2cauthentication
        public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
        public static readonly string AuthorityBase = $"https://{TenantName}.b2clogin.com/tfp/{TenantId}/";
        public static readonly string AuthoritySignIn = $"{AuthorityBase}{SignInPolicy}";
    }
}
