using ApiTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        List<Tarefa> listaTarefas = new List<Tarefa>();

        public TarefaController()
        {
            var tarefa1 = new Tarefa()
            {
                Id = 1,
                Descricao = "Estudo de API parte 1"
            };

            var tarefa2 = new Tarefa()
            {
                Id = 2,
                Descricao = "Estudo de API parte 2"
            };

            var tarefa3 = new Tarefa()
            {
                Id = 3,
                Descricao = "Estudo de API parte 3"
            };

            listaTarefas.Add(tarefa1);
            listaTarefas.Add(tarefa2);
            listaTarefas.Add(tarefa3);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaTarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

            if(tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }
    }
}