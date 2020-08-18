using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_Task.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskContext _context;

        public TaskController(TaskContext context)
        {
            this._context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetAllTaskItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(TaskContext)) as TaskContext;
            //return new string[] { "value1", "value2" };
            return _context.GetAllTask();
        }

        //Get : api/user/{id}
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<TaskModel>> GetTaskItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(TaskContext)) as TaskContext;
            return _context.GetTask(id);
        }
        //delete : api/user/{id}
        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult<IEnumerable<TaskModel>> DeleteTaskItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(TaskContext)) as TaskContext;
            return _context.DeleteTask(id);
        }
        [HttpPost( Name = "Post")]
        public ActionResult<IEnumerable<TaskModel>> PostTaskItem()
        {
            String title = "assdads";
            String description = "asdasd";
            _context = HttpContext.RequestServices.GetService(typeof(TaskContext)) as TaskContext;
            return _context.PostTask();
        }
    }
}