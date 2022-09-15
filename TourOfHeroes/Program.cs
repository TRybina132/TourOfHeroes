﻿using DataAccess.Context;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Configurations;

var cookiePolicyOptions = new CookiePolicyOptions
{
    //  ᓚᘏᗢ Cookies only from this api
    MinimumSameSitePolicy = SameSiteMode.Unspecified
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureServices();

builder.Services.AddCors(builder.Configuration.GetSection("CORSConfig"));

builder.Services.AddDbContext<TourContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<TourContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//  ᓚᘏᗢ Add setting how we will treat cookies
app.UseCookiePolicy();

app.UseRouting();

app.UseCors(builder.Configuration.GetSection("CORSConfig")["Name"]);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
