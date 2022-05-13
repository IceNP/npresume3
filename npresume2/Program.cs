using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using npresume2.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<npresume2Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("npresume2Context") ?? throw new InvalidOperationException("Connection string 'npresume2Context' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
