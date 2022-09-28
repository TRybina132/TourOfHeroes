using DataAccess.Context;
using DataAccess.Context.Interceptors;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Configurations;
using TourOfHeroes.Middleware;

var cookiePolicyOptions = new CookiePolicyOptions
{
    //  ᓚᘏᗢ Cookies only from this api
    MinimumSameSitePolicy = SameSiteMode.Unspecified
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureServices();

builder.Services.AddCors(builder.Configuration.GetSection("CORSConfig"));

builder.Services.AddDbContext<TourContext>((provider, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopConnection"));
    options.AddInterceptors(provider.GetRequiredService<ConnectionLogInterceptor>());
});

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<TourContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<CounterMiddleware>();

app.UseHttpsRedirection();
//  ᓚᘏᗢ Add setting how we will treat cookies
app.UseCookiePolicy();

app.UseRouting();

app.UseCors(builder.Configuration.GetSection("CORSConfig")["Name"]);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
