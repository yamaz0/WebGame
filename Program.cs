using Microsoft.EntityFrameworkCore;
using WebGame;
using WebGame.Services.Arena;
using WebGame.Services.Arena.Interface;
using WebGame.Services.Job;
using WebGame.Services.Job.Interface;
using WebGame.Services.Mission;
using WebGame.Services.Mission.Interface;
using WebGame.Services.Player;
using WebGame.Services.Player.Interface;
using WebGame.Services.Shop;
using WebGame.Services.Shop.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IShopService, ShopService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<IArenaService, ArenaService>();

builder.Services.AddDbContext<DbGameContext>(options =>
options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
