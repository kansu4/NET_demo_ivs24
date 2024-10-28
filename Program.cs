using Microsoft.EntityFrameworkCore;
using NET_demo_ivs24;
using Microsoft.AspNetCore.Identity;
//

var builder = WebApplication.CreateBuilder(args); // new instance of the web application Builder class  

// Add services to the container.
builder.Services.AddControllersWithViews();

// 
var connectionString = builder.Configuration.GetConnectionString("Default"); //get the connection string from appsetting

//configures Entity Framework Core to use MySQL
builder.Services.AddDbContext<NET_demo_ivs24Context>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
//

var app = builder.Build(); // compile the app 

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

//
//app.UseAuthentication();
//

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
