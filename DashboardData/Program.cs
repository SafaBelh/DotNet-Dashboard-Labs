using DashboardData.Components;
using DashboardData.Services;

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

app.Run();
