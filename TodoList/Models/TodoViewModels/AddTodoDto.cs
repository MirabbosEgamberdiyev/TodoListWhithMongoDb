namespace TodoList.Models.TodoViewModels
{
    public class AddTodoDto
    {
        public string Name { get; set; } = string.Empty;

        public static implicit operator TodoItem(AddTodoDto addTodo)
            => new TodoItem
            {
                Name = addTodo.Name
            };
    }
}
