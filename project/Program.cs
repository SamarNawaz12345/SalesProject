using Microsoft.EntityFrameworkCore;
using project.Components;
using project.Data;
using project.IProductService;
using project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure HttpClient with base address for API
builder.Services.AddHttpClient<ProductService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7008"); // Replace with your actual API URL
});
builder.Services.AddHttpClient<CataegoryService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7032/");
});
builder.Services.AddHttpClient<Salesmanservice>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7008/");
});
builder.Services.AddHttpClient<SettingService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7008/");
});
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CataegoryService>();
builder.Services.AddScoped<Salesmanservice>();
builder.Services.AddScoped<ISettingsService, SettingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
