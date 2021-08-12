using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using senai.todolist.webapi.Models;

namespace senai.todolist.webapi.Controllers
{
    [Route("api/todoitems")]
    [ApiController]

    public class TodoItemsController : ControllerBase
    {
        private static List<TodoItem> todoitems = new List<TodoItem>();

        [HttpPost]
        public IActionResult Post(TodoItem todoItem)
        {

            todoitems.Add(todoItem);

            return Ok(todoItem);
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (todoitems.Count == 0)
                return NoContent();

            return Ok(todoitems);
        }
    }
}