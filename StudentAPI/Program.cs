using Microsoft.EntityFrameworkCore;
using StudentAPI.Interfaces;
using StudentAPI.Services;
using StudentDAL.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddTransient<IStudents, StudentsService>();

string ConnectionStr = "Server=BCPRDFQW1WM4-L;Database=student;Integrated Security=True; TrustServerCertificate=True";

//builder.Services.AddDbContext<studentContext>(options => options.UseSqlServer(ConnectionStr), ServiceLifetime.Transient);

builder.Services.AddDbContext<studentContext>(x => x.UseSqlServer(ConnectionStr));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
