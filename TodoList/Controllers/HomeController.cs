using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using TodoList;
using TodoList.Models;
using TodoList.Models.TodoViewModels;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMongoCollection<TodoItem> _todoCollection;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _todoCollection = dbContext.TodoItems;
    }

    public IActionResult Index()
    {
        var todoListViewModel = new TodoViewModel
        {
            TodoList = _todoCollection.Find(_ => true).ToList()
        };
        return View(todoListViewModel);
    }

    [HttpGet]
    public JsonResult PopulateForm(ObjectId id)
    {
        var todo = GetById(id);
        return Json(new { id = todo.Id, name = todo.Name });
    }

    [HttpPost]
    public IActionResult Insert(AddTodoDto todo)
    {
        if (ModelState.IsValid)
        {
            if (todo.Name.Length > 50)
            {
                return BadRequest("Error: Todo name should be 25 characters or less.");
            }

            var todoItem = new TodoItem { Name = todo.Name };
            _todoCollection.InsertOne(todoItem);
        }

        return RedirectToAction("Index");
    }


    [HttpPost]
    public JsonResult Delete(ObjectId id)
    {
        _todoCollection.DeleteOne(t => t.Id == id);
        return Json(new { success = true });
    }
    [HttpGet]
    public IActionResult Update(string id)
    {
        var todo = _todoCollection.Find(i => i.Id == ObjectId.Parse(id)).FirstOrDefault();
        Delete(ObjectId.Parse(id));

        if (todo != null)
        {
            TodoViewModel todoModel = new TodoViewModel
            {
                Todo = todo
            };

            return View("Index", todoModel);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Update(TodoItem todo)
    {
        if (ModelState.IsValid)
        {
            _todoCollection.ReplaceOne(t => t.Id == todo.Id, todo);
        }

        return RedirectToAction("Index");
    }

    private TodoItem GetById(ObjectId id)
    {
        var todo = _todoCollection.Find(t => t.Id == id).FirstOrDefault();
        return todo ?? new TodoItem();
    }
}