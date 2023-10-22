using Microsoft.EntityFrameworkCore;
using MVC.Context;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

#region IoC Container
// Autofac, Ninject,
builder.Services.AddDbContext<Db>(options => options.UseSqlServer(connectionString));
#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();//https protokolü
app.UseStaticFiles(); //wwwroot -> html,css, js, imaj, video, müzik, vb. dosyalar

app.UseRouting();

app.UseAuthorization(); //yetki konrtolü

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
