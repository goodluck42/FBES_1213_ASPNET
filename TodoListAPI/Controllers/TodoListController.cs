using Microsoft.AspNetCore.Mvc;

namespace TodoListAPI.Controllers;


[ApiController]
[Route("api/v1/todo")]
public class TodoListController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public TodoListController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("all")]
    public List<TodoListTask> All()
    {
        return _appDbContext.Tasks.ToList();
    }

    [HttpPost]
    public TodoListTask Add(TodoListTask task)
    {
        _appDbContext.Tasks.Add(task);
        _appDbContext.SaveChanges();

        return task;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        try
        {
            _appDbContext.Tasks.Remove(new TodoListTask
            {
                Id = id
            });

            _appDbContext.SaveChanges();
        }
        catch {}
    }
}