using MongoDB.Driver;
using TodoList.Models;

public class ApplicationDbContext
{
    private readonly IMongoDatabase _database;

    public ApplicationDbContext(IMongoDatabase database)
    {
        _database = database;
    }

    public IMongoCollection<TodoItem> TodoItems => _database.GetCollection<TodoItem>("Todolar");
}
