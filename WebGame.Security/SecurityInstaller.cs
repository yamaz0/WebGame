using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Security.Contracts;
using WebGame.Persistence.EF.Account;
using WebGame.Security.Account;
using WebGame.Security.Models;

namespace WebGame.Security
{
    public static class SecurityInstaller
    {
        public static IServiceCollection InstallSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            var configurationSection = configuration.GetSection(JSONWebTokensSettings.CONFIG_NAME);
            var jsonWebTokensSettings = configurationSection.Get<JSONWebTokensSettings>();

            services.Configure<JSONWebTokensSettings>(configurationSection);

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Player", policy => policy.RequireClaim("Player"));
            //});

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        IgnoreTrailingSlashWhenValidatingAudience = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jsonWebTokensSettings.Key)),
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = true,
                        RequireAudience = true,
                        RequireSignedTokens = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidAudience = jsonWebTokensSettings.Audience,
                        ValidIssuer = jsonWebTokensSettings.Issuer,
                    };

                    o.SaveToken = true;

                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("401 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("403 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                    };
                });

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
