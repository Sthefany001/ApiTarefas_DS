using ApiTarefas.Dtos;
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
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault(); /*fazendo busca da tarefa*/

            if (tarefa == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {
            var contador = listaTarefas.Count();

            var tarefa = new Tarefa();

            tarefa.Id = contador + 1;
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            listaTarefas.Add(tarefa);

            return StatusCode(StatusCodes.Status201Created, tarefa);
        }

        [HttpPut] 
        public IActionResult Put(int id, [FromBody] TarefaDTO item)
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca da tarefa*/

            if (tarefa == null) /*verifica se existe*/
            {
                return NotFound();
            }

            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();/*fazendo busca da tarefa*/

            if (tarefa == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaTarefas.Remove(tarefa);
            
            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(tarefa); /*mostra a tarefa que você excluiu*/
        }
    }
}