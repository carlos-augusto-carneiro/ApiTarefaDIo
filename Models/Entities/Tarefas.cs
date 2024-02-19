using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiTarefasDio.Models.Enums;

namespace ApiTarefasDio.Models.Entities;

public class Tarefas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Titulo { get; set; } = default!;

    [Required]
    [StringLength(500)]
    public string Descricao { get; set; } = default!;

    
    public DateTime Data { get; set; }
    public StatusEnums Perfil { get; set; }
}