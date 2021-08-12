using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using senai.todolist.webapi.Models;
using System;


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

        //Atualiza a tarefa/item
        [HttpPut("{id}")] //https//localhost:5001/api/todoitems/id
        public IActionResult Put(Guid id, TodoItem todoItem){

            //busca o indice da lista referente a tarefa
            int todoIndex = todoitems.FindIndex(t => t.Id == id);

            //verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                    return BadRequest(new {mensage = "Id não encontrado."});

            //atualiza a tarefa
            todoitems[todoIndex] = todoItem;

            //retorna sucesso com a lista de tarefas atualizada
            return Ok(todoitems);
        }
    }
}