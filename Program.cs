var builder = WebApplication.CreateBuilder(args);

// Dependency Injection - add the required services to MapControllerRoute work
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Enable static files - CSS, JS, Images, etc
app.UseStaticFiles();

// Routing capabilities - Need to redirect the request to the correct controller
app.UseRouting();

app.MapControllerRoute( // Map the HTTP request to the controller
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // The pattern of the URL - CONTROLLER/METHOD/PARAMETER

app.Run();