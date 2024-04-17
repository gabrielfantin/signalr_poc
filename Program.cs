using wss.SignalHubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    Console.WriteLine("indo e indo");
    return "works like a charm";
});
app.MapHub<DefaultHub>("/default");
app.UseStaticFiles();

app.Run();
