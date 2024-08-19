using ApiTarefas.Dtos;
using ApiTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [Route("veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        public VeiculoController()
        {
            var veiculo1 = new Veiculo()
            {
                Marca = "x",
                Modelo = "y",
                AnoFab = 2000,
                AnoModelo = 2000,
                Placa = "AAA-1234"
            };

            var veiculo2 = new Veiculo()
            {
                Marca = "x",
                Modelo = "y",
                AnoFab = 2000,
                AnoModelo = 2000,
                Placa = "AAA-4321"
            };

            var veiculo3 = new Veiculo()
            {
                Marca = "x",
                Modelo = "y",
                AnoFab = 2000,
                AnoModelo = 2000,
                Placa = "AAA-5678"
            };

            var veiculo4 = new Veiculo()
            {
                Marca = "x",
                Modelo = "y",
                AnoFab = 2000,
                AnoModelo = 2000,
                Placa = "AAA-8765"
            };

            listaVeiculos.Add(veiculo1);
            listaVeiculos.Add(veiculo2);
            listaVeiculos.Add(veiculo3);
            listaVeiculos.Add(veiculo4);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaVeiculos);
        }

        [HttpGet("{placa}")]
        public IActionResult GetById(string placa)
        {
            var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault(); 

            if (veiculo == null) /*verifica se existe*/
            {
                return NotFound();
            }

            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] VeiculoDTO item)
        {
            var veiculo = new Veiculo();

            veiculo.Marca = veiculo.Marca;
            veiculo.Modelo = veiculo.Modelo;
            veiculo.AnoFab = veiculo.AnoFab;
            veiculo.AnoModelo = veiculo.AnoFab;
            veiculo.Placa = veiculo.Placa;

            listaVeiculos.Add(veiculo);

            listaVeiculos.Add(veiculo);
            return StatusCode(StatusCodes.Status201Created, veiculo);
        }

        [HttpPut]
        public IActionResult Put(string placa, [FromBody] VeiculoDTO item)
        {
            var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault();/*fazendo busca da tarefa*/

            if (veiculo == null) /*verifica se existe*/
            {
                return NotFound();
            }

            veiculo.Marca = veiculo.Modelo;
            veiculo.Modelo = veiculo.Modelo;
            veiculo.AnoFab = veiculo.AnoFab;
            veiculo.AnoModelo = veiculo.AnoFab;
            veiculo.Placa = veiculo.Placa;

            return Ok(veiculo);
        }

        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            var veiculo = listaVeiculos.Where(item => item.Placa == placa).FirstOrDefault();/*fazendo busca da tarefa*/

            if (veiculo == null) /*verifica se existe*/
            {
                return NotFound();
            }

            listaVeiculos.Remove(veiculo);

            /*return NoContent(); /*status code 204 e você não retorna nenhuma informação*/
            return Ok(veiculo); /*mostra a tarefa que você excluiu*/
        }
    }
}
