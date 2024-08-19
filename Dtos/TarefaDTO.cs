using System.ComponentModel.DataAnnotations;
namespace ApiTarefas.Dtos
{
    public class TarefaDTO
    {
        [Required]
        [MinLength(5)]
        public string Descricao { get; set; }
        public bool Feito { get; set; } = false;
    }
}
