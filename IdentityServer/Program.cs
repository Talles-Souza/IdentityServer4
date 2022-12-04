using IdentityServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityServer()
  .AddInMemoryClients(IdentityConfiguration.Clients)
  .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
  .AddInMemoryApiResources(IdentityConfiguration.ApiResources)
  .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
  .AddTestUsers(IdentityConfiguration.TestUsers)
  .AddDeveloperSigningCredential();
var app = builder.Build();



app.MapGet("/", () => "Hello World!");
app.UseIdentityServer();
app.Run();
