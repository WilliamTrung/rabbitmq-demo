using RabbitMq.Shared;
using RabbitMq.Demo.Service;
using RabbitMq.Demo.Business;
using RabbitMq.Demo.Worker.Consumers;
using RabbitMq.Demo.Worker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterConfigOptions(builder.Configuration);
builder.Services.RegisterProviders();
builder.Services.RegisterServices();
builder.Services.RegisterBusinesses();
builder.Services.RegisterConsumers();
builder.Services.AddHostedService<ConsumerHostedService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();