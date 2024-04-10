using Microsoft.EntityFrameworkCore;
using Users.Application.DrivenAdapters.Database;
using Users.Application.Ports.Driven;
using Users.Application.Ports.Driving.Users;
using Users.Application.UseCases.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options => {
    options.UseInMemoryDatabase("Users");
});

builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IGetUser, GetUser>();
builder.Services.AddScoped<IUpdateUser, UpdateUser>();
builder.Services.AddScoped<IDeleteUser, DeleteUser>();
builder.Services.AddScoped<IUserRepository, UserPersistenceAdapters>();



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
