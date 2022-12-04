﻿using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
           new List<TestUser>
           {
                new TestUser
                {
                     SubjectId = "1144",
                     Username = "macoratti",
                     Password = "numsey",
                     Claims =
                     {
                        new Claim(JwtClaimTypes.Name, "Macoratti Net"),
                        new Claim(JwtClaimTypes.GivenName, "Macoratti"),
                        new Claim(JwtClaimTypes.FamilyName, "Net"),
                        new Claim(JwtClaimTypes.WebSite, "http://macoratti.net"),
                     }
              }
       };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
                 
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
               new ApiResource("myApi")
               {
                   Scopes = new List<string>{ "myApi.read","myApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
               }
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "talles",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ronaldo".Sha256()) },
                    AllowedScopes = { "myApi.read"}
                },
            };
    }
}

