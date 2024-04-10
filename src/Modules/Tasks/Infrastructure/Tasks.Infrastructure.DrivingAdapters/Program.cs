using Microsoft.EntityFrameworkCore;
using Tasks.Application.Ports.Driven;
using Tasks.Application.Ports.Driving.Tasks;
using Tasks.Application.UseCases.Tasks;
using Tasks.Infrastructure.DrivenAdapters.Database;
using MassTransit;
using Tasks.Infrastructure.DrivenAdapters.MassTransit.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskContext>(options => {
    options.UseInMemoryDatabase("Tasks");
});

builder.Services.AddScoped<ICreateTask, CreateTask>();
builder.Services.AddScoped<IGetTask, GetTask>();
builder.Services.AddScoped<IUpdateTask, UpdateTask>();
builder.Services.AddScoped<IDeleteTask, DeleteTask>();
builder.Services.AddScoped<ITaskRepository, TaskPersistenceAdapter>();

builder.Services.AddMassTransit(x => 
{
    x.AddConsumer<SubmitTaskObserver>();
    x.UsingInMemory((context, cfg) => 
    {
        cfg.ConfigureEndpoints(context);
    });
});

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
