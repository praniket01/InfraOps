using Microsoft.EntityFrameworkCore;
using PlatformService.Communicator.Http;
using PlatformService.Data;
using PlatformService.Repository;
using PlatformService.Repository.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//configure the DB context
builder.Services.AddDbContext<PlatformDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("PlatformDB"))
);

builder.Services.AddScoped<IPlatform, PlatformRepo>();
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
