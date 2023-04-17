using Microsoft.EntityFrameworkCore;
using Nhom1_LapTrinhWeb_CNTT2_K61.Models;
using Nhom1_LapTrinhWeb_CNTT2_K61.Repository;
using NuGet.Protocol.Core.Types;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(); 

builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("TourManagementContext");
builder.Services.AddDbContext<TourManagementContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IDiaDiem, DiaDiem>();

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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
