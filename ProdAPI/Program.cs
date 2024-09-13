using Microsoft.EntityFrameworkCore;
using ProdAPI.IProductService;
using project.Data;
using project.IProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register AppDbContext with DI container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Configure HttpClient with base address for API
//builder.Services.AddHttpClient<ProductService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7008"); // Replace with your actual API URL
//});
//builder.Services.AddHttpClient<CategoryService>(client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7008"); // Adjust to your API base address
//});

//builder.Services.AddScoped<ProductService>();
//builder.Services.AddScoped<CategoryService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
