using RabbitMQ.Client;
using wss.Services;
using wss.SignalHubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

builder.Services.AddHostedService<RabbitMQListener>();
builder.Services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory()
{
    HostName = builder.Configuration["RabbitMq:Host"],
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapHub<DefaultHub>("/default");
app.UseStaticFiles();

app.Run();
