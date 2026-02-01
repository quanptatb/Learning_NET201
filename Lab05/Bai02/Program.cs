using Bai02.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Đăng ký 3 DbContext
builder.Services.AddDbContext<Bai02aContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bai02a")));

builder.Services.AddDbContext<Bai02bContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bai02b")));

builder.Services.AddDbContext<Bai02cContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Bai02c")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
