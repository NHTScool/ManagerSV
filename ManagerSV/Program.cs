using ManagerSV.Models;
using ManagerSV.Sevives;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<StudentStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(StudentStoreDatabaseSetting)));

builder.Services.AddSingleton<IstudentStoreDatabaseSetting>(sp => sp.GetRequiredService<IOptions<StudentStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSetting:ConnectionString")));
builder.Services.AddScoped<IstudentSevices, StudentSevices>();


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
