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
                        //IgnoreTrailingSlashWhenValidatingAudience = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jsonWebTokensSettings.Key)),
                        ValidateIssuer = true,
                        ValidIssuer = jsonWebTokensSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jsonWebTokensSettings.Audience,
                        //ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };

                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;

                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.NoResult();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject("401 Not authorized");
                            return context.Response.WriteAsync(result);
                        },
                        //OnChallenge = context =>
                        //{
                        //    try
                        //    {

                        //        context.HandleResponse();
                        //        context.Response.StatusCode = 401;
                        //        context.Response.ContentType = "application/json";
                        //    }
                        //    catch (Exception e)
                        //    {
                        //        Console.WriteLine(e);
                        //        throw;
                        //    }
                        //        var result = JsonConvert.SerializeObject("401 Not authorized");
                        //    return context.Response.WriteAsync(result);
                        //},
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
