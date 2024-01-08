using MongoDB.Bson;

namespace TodoList.Models;

public class TodoItem
{
    public ObjectId Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
