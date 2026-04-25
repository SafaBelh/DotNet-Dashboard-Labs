using Microsoft.EntityFrameworkCore;
using DashboardData.Data;
using DashboardData.Components;
using DashboardData.Services;
using DashboardData.Models;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 🟣 Adding SensorService
builder.Services.AddScoped<ISensorService, SensorService>();

// 🟠 Singleton – one instance for the entire application
builder.Services.AddSingleton<UserCounterService>();

// 🟠 Scoped – one instance per user circuit 
// builder.Services.AddScoped<UserCounterService>();

// 🟠 Transient – new instance every time
// builder.Services.AddTransient<UserCounterService>();


// 🟣 Adding connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// 🟣 Adding Radzen 
builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



// 🟣🟣🟣 Seeding db 🟣🟣🟣 //

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!context.Sensors.Any())
    {
        // Locations
        var lab = new Location { Name = "Labo", Building = "Bât. A" };
        var usine = new Location { Name = "Usine", Building = "Bât. B" };
        context.Locations.AddRange(lab, usine);

        // Tags
        var tagCritique = new Tag { Label = "Critique" };
        var tagMaintenance = new Tag { Label = "Maintenance" };
        context.Tags.AddRange(tagCritique, tagMaintenance);

        context.SaveChanges(); 

        // Sensors with relationships
        var sondeAlpha = new SensorData
        {
            Name = "Sonde_Alpha",
            Value = 25.4,
            LocationId = lab.Id,
            Tags = new List<Tag> { tagCritique }
        };
        var sondeBeta = new SensorData
        {
            Name = "Sonde_Beta",
            Value = 40.2,
            LocationId = usine.Id,
            Tags = new List<Tag> { tagCritique, tagMaintenance }
        };
        context.Sensors.AddRange(sondeAlpha, sondeBeta);
        context.SaveChanges();
    }
}


app.Run();
