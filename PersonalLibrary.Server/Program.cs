using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonalLibrary.DAL;
using PersonalLibrary.DAL.DAL;
using PersonalLibrary.DAL.DB;
using PersonalLibrary.DAL.Interfaces;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

builder.Services.AddRouting();

builder.Services.AddSingleton<IAppSettings, AppSettings>();
builder.Services.AddScoped<IBookDAL, BookDAL>();

builder.Services.AddDbContext<PersonalLibraryContext>((provider, options) =>
{
    var appSettings = provider.GetRequiredService<IAppSettings>();
    options.UseSqlServer(appSettings.ConnectionString);
    options.EnableSensitiveDataLogging();
});

var app = builder.Build();

using (IServiceScope serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    PersonalLibraryContext context = serviceScope.ServiceProvider.GetRequiredService<PersonalLibraryContext>();
    context.Database.Migrate();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapControllerRoute("api", "api/{controller}/{action}/{id?}");
//});

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.MapFallbackToFile("/index.html");

app.Run();
