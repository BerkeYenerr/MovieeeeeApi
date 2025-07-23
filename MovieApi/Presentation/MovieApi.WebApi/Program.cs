using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPattern.Handlers.UserRegisterHandlers;
using MovieApi.Application.Features.MediatorDesignPattern.Handlers.Tag_Handlers;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Persistence.Context;
using MovieApi.Persistence.Identity;

var builder = WebApplication.CreateBuilder(args);

// AddDbContext with connection string
builder.Services.AddDbContext<MovieContext>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();


builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();


builder.Services.AddScoped<CreateUserRegisterCommandHandler>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MovieContext>();

// Register all MediatR handlers from Application layer
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
