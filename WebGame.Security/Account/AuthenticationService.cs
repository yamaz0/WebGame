﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebGame.Application.Interfaces.Persistence;
using WebGame.Application.Response;
using WebGame.Application.Security.Contracts;
using WebGame.Application.Security.Models;
using WebGame.Domain.Entities.User;
using WebGame.Persistence.EF.Account;
using WebGame.Security.Models;

namespace WebGame.Security.Account
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IOptions<JSONWebTokensSettings> _jwtSettings;

        public AuthenticationService(SignInManager<UserEntity> signInManager, IOptions<JSONWebTokensSettings> jwtSettings, IUserRepository userRepository)
        {
            _signInManager = signInManager;
            _jwtSettings = jwtSettings;
            _userRepository = userRepository;
        }

        public async Task<RefreshTokenResponse> RefreshToken(UserEntity user)
        {
            var accessToken = await GenerateBearerToken(user);
            var refreshToken = await GenerateRefreshToken(user);
            return new RefreshTokenResponse(accessToken, refreshToken);
        }

        public async Task<AuthenticationResponse> SingIn(UserEntity user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

            if (!result.Succeeded)
                return null;

            return new AuthenticationResponse()
            {
                AccessToken = await GenerateBearerToken(user),
                RefreshToken = await GenerateRefreshToken(user),
                UserId = user.Id,
                UserName = user.UserName
            };
        }

        public async Task SingOut()
        {
            //try
            //{

            //    await _signInManager.SignOutAsync();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        private async Task<string> GenerateBearerToken(UserEntity user)
        {
            var expiry = DateTimeOffset.Now.AddMinutes(_jwtSettings.Value.DurationInMinutes);
            return await GenerateToken(user, expiry);
        }

        private async Task<string> GenerateToken(UserEntity user, DateTimeOffset expiry)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var userClaims = await _userRepository.GetClaimsAsync(user);
            var userRoles = await _userRepository.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Value.Issuer,
                audience: _jwtSettings.Value.Audience,
                claims: userClaims,
                notBefore: DateTime.Now,
                expires: expiry.DateTime,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private async Task<string> GenerateRefreshToken(UserEntity user)
        {
            var expiry = DateTimeOffset.Now.AddHours(24);
            return await GenerateToken(user, expiry);
        }
    }

}
