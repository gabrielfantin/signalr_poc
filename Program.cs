using wss.SignalHubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapHub<DefaultHub>("/default");
app.UseStaticFiles();

app.Run();
