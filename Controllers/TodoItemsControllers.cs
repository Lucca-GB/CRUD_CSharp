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

        //cadatra uma nova tarefa
        [HttpPost]
        public IActionResult Post(TodoItem todoItem)
        {
            //salva a tarefa na lista de tarefas
            todoitems.Add(todoItem);

            //retorna sucesso com a tarefa que foi cadastrada
            return Ok(todoItem);
        }

        //lista todas as tarefas
        [HttpGet]
        public IActionResult Get()
        {

            //verifica se existe tarefas na lista
            //caso nao exista retorna erro 204/erro de NoContent
            if (todoitems.Count == 0)
                return NoContent();

            //caso exista retorna sucesso com a lista de tarefas
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

        [HttpDelete("{id}")] //id do objeto q eu quero deletar
        public IActionResult Delete(Guid id){
            //busca o indice da lista referente a tarefa
            int todoIndex = todoitems.FindIndex(t => t.Id == id);

            //verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                    return BadRequest(new {mensage = "Id não encontrado."});

            //remove a tarefa da lista de tarefas
            todoitems.Remove(todoitems[todoIndex]);

            //retorna sucesso com a lista de tarefas
            return Ok(todoitems);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id){
            //busca o indice da lista referente a tarefa
            int todoIndex = todoitems.FindIndex(t => t.Id == id);

            //verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                    return BadRequest(new {mensage = "Id não encontrado."});

            //retorna sucesso com a tarefa buscada
            return Ok(todoitems[todoIndex]);
        }
    }
}