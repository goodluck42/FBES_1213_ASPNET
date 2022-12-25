using AuthWebApplication.Requirements;
using AuthWebApplication.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IAuthorizationHandler, AgeHandler>();
builder.Services.AddTransient<IUserClaimGenerator, UserClaimGenerator>();
builder.Services.AddControllersWithViews();

builder.Configuration.AddIniFile("s.ini");

Console.WriteLine(builder.Configuration.GetSection("Users").GetSection("Data").Value);

//builder.Services.AddAuthentication();

//AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
//{
//    options.LoginPath = "/Home/SignUp";
//    options.LogoutPath = "/Home/SignOut";
//    options.AccessDeniedPath = "/Home/NoAccess";
//    options.ExpireTimeSpan = TimeSpan.FromDays(365);
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("MaxAge18", policy =>
//    {
//        policy.Requirements.Add(new AgeRequirement() { MaxAge = 18 });
//    });

//    options.AddPolicy("AdminOnly", policy =>
//    {
//        policy.RequireClaim(ClaimTypes.Role, "admin");
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
