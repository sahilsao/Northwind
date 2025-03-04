using Microsoft.EntityFrameworkCore;
using Northwind.Server.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindCS"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

