// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;    // ← adicione isto
using Microsoft.EntityFrameworkCore;
using PetShopCSharp.Data;

var builder = WebApplication.CreateBuilder(args);

// EF Core
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(opts =>
{
  opts.ListenLocalhost(5000);          
  opts.ListenLocalhost(5001, listen =>  
    listen.UseHttps());                
});

builder.Services.AddHttpsRedirection(opts =>
{
  opts.HttpsPort = 5001;
});


var app = builder.Build();
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
