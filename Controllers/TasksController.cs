using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> GetTasks()
        {
            return await _context.Stories.ToListAsync();
        }

        // GET: api/tasks/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Story>> GetTask(int id)
        {
            var story = await _context.Stories.FindAsync(id);

            if (story == null)
            {
                return NotFound();
            }

            return story;
        }


        // GET: api/tasks/expired
        [HttpGet("expired")]
        public async Task<ActionResult<IEnumerable<Story>>> GetExpiredTasks()
        {
            DateTime currentDate = DateTime.UtcNow;

            var expiredTasks = await _context.Stories
                .Where(task => task.DueDate < currentDate)
                .ToListAsync();

            return expiredTasks;
        }
        // GET: api/tasks/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Story>>> GetActiveTasks()
        {
            DateTime currentDate = DateTime.UtcNow;

            var activeTasks = await _context.Stories
                .Where(task => task.DueDate >= currentDate)
                .ToListAsync();

            return activeTasks;
        }

        // GET: api/tasks/fromDate?date=yyyy-MM-dd
        [HttpGet("fromDate")]
        public async Task<ActionResult<IEnumerable<Story>>> GetTasksFromDate([FromQuery] DateTime date)
        {
            var tasksFromDate = await _context.Stories
                .Where(task => task.DueDate.Date == date.Date)
                .ToListAsync();

            return tasksFromDate;
        }
        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<Task>> PostTask(Story story)
        {
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { id = story.ID }, story);
        }

        // PUT: api/tasks/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Story story)
        {
            if (id != story.ID)
            {
                return BadRequest();
            }

            _context.Entry(story).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tasks/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Stories.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(task);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
