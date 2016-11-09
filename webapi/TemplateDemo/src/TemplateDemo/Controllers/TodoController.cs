using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplateDemo.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TemplateDemo.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public ITodoItemRepository TodoItems { get; set; }

        public TodoController(ITodoItemRepository todoItems)
        {
            TodoItems = todoItems;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        // GET api/values/5
        [HttpGet("{key}", Name = "GetTodo")]
        public IActionResult GetById(string key)
        {
            var item =  TodoItems.Find(key);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpGet("GetByComplete/&isComplete={isComplete}")]
        public IActionResult GetByIsComplete(bool isComplete)
        {
            var items = TodoItems.FilterByComplete(isComplete);
            return Json(items);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            TodoItems.Add(item);
            return CreatedAtRoute("GetTodo", new { key = item.Key }, item);
        }

        // PUT api/values/5
        [HttpPut("{key}")]
        public IActionResult Put(string key, [FromBody]TodoItem item)
        {
            if (item == null || item.Key != key)
            {
                return BadRequest();
            }
            TodoItems.Update(item);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            var item = TodoItems.Remove(key);
            if (item == null)
            {
                return NotFound();
            }            
            return NoContent();
        }
    }
}
