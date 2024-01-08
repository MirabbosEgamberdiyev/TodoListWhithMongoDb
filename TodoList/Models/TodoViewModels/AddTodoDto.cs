using System.ComponentModel.DataAnnotations;

namespace TodoList.Models.TodoViewModels
{
    public class AddTodoDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public static implicit operator TodoItem(AddTodoDto addTodo)
            => new TodoItem
            {
                Name = addTodo.Name
            };
    }
}
