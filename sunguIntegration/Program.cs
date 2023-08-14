using Microsoft.EntityFrameworkCore;
using sunguIntegration.Dal;
using sunguIntegration.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var trendyolConnection = builder.Configuration.GetConnectionString("TrendyolConnectionString");
builder.Services.AddDbContext<TrendyolContext>(opt => opt.UseSqlServer(trendyolConnection));


builder.Services.AddScoped<TrendyolRestService>();
builder.Services.AddScoped<TrendyolCategoryService>();
builder.Services.AddScoped<TrendyolBrandService>();
builder.Services.AddScoped<TrendyolProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

