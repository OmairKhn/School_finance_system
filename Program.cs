using Microsoft.EntityFrameworkCore;
using StudentService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentDb")));

// Add controllers
builder.Services.AddControllers();

// Minimal JWT auth (can be stubbed for now)
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options => {
    options.Authority = "http://localhost:5000";
    options.TokenValidationParameters.ValidateAudience = false;
    options.RequireHttpsMetadata = false;
});
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment() || true) // set true for easy dev access
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
