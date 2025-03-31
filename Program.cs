
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add EF and SQLite
builder.Services.AddDbContext<TodoDbContext>(opttions => opttions.UseSqlite("Data Source= todos.db"));


var app = builder.Build();

// Apply migration on startup

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
    db.Database.Migrate();
}



app.MapGet("/todo", async (TodoDbContext db) =>
{
    var todos = db.Todos.ToListAsync();
    return Results.Ok(todos);
});

app.MapPost("/todo", async (Todo task, TodoDbContext db) =>
{
    db.Todos.Add(task);
    await db.SaveChangesAsync();
    return Results.Created($"/{task.id}", task);
});

app.MapGet("/todo/{id}", async Task<Results<Ok<Todo>, NotFound>> (int id, TodoDbContext db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return TypedResults.NotFound();

    return TypedResults.Ok(todo);
});

app.MapDelete("/todo/{id}", async Task<Results<NoContent, NotFound>> (int id, TodoDbContext db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return TypedResults.NotFound();

    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return TypedResults.NoContent();
});

app.Run();
