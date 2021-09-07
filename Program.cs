var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => new { Name = "Prices Service", Description = "Send request to /price/{item_id} endpoint to receive item's price" });
app.MapGet("/price/{id}", (int id) => new Price(id, id * 3.5, "USD", DateTime.UtcNow + TimeSpan.FromDays(5)));

app.Run();

record Price(int Id, double Value, string Currency, DateTime ValidUntil);