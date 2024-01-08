
namespace TodoList.Models.TodoViewModels
{
    public class TodoDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public static implicit operator TodoDto(TodoItem todo)
        {
            return new TodoDto
            {
                Id = todo.Id.ToString(),
                Name = todo.Name,
            };
        }

        public static implicit operator TodoItem(TodoDto dto)
        {
            return new TodoItem
            {
                Name = dto.Name,
            };
        }
    }
}
