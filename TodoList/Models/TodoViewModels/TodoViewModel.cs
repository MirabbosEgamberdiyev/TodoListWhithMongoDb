
namespace TodoList.Models.TodoViewModels;

public class TodoViewModel
{
    public TodoItem Todo { get; set; }
    public List<TodoItem> TodoList { get; set; } = new List<TodoItem>();
}
