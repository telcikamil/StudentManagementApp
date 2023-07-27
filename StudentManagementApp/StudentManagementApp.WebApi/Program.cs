using Microsoft.EntityFrameworkCore;
using StudentManagementApp.DAL.Context;
using StudentManagementApp.DAL.Repositories.Abstract;
using StudentManagementApp.DAL.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentManagementDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementDbContextConnection")));
builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("StudentManagementDbContextConnection") ?? throw new InvalidOperationException("Connection string 'StudentManagementDbContextConnection' not found ");
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
