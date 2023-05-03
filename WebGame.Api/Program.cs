using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using WebGame;
using WebGame.Api;
using WebGame.Application;
using WebGame.Domain.Entities.User;
using WebGame.Duel;
using WebGame.Security;
using WebGame.TimeAction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", config => config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(o => true));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.InstallApplication();
builder.Services.InstallDb();
builder.Services.InstallTimeAction();
builder.Services.InstallSecurity(builder.Configuration);
builder.Services.InstallDuel();

builder.Services.AddIdentityCore<UserEntity>()
    .AddRoles<IdentityRole>()
    .AddSignInManager<SignInManager<UserEntity>>()
    .AddEntityFrameworkStores<DbGameContext>();
//builder.Services.AddAuthentication()
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Account/Unauthorized/";
//        options.AccessDeniedPath = "/Account/Forbidden/";
//    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Open");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.UseSession();

app.MapControllers();

app.Run();