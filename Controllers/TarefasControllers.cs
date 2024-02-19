using ApiTarefasDio.Models.Entities;
using ApiTarefasDio.Persistences.DB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefasDio.Controllers;

[ApiController]
[Route("Tarefas")]
public class TarefasControllers : ControllerBase
{
    private readonly AgendaDb _context;
    public TarefasControllers(AgendaDb context)
    {
        _context = context;
    }
    [HttpPost("AdicionarTarefa")]
    public IActionResult AdicionarTarefa(Tarefas tarefa)
    {
        if(tarefa.Data < DateTime.MinValue) return NotFound("Data invalida");
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        return Ok(tarefa);
    }

    [HttpGet("Visualizar/{id}")]
    public IActionResult VisualizarPorId(int id)
    {
        var Verificar = _context.Tarefas.Find(id);

        if(Verificar == null) return NotFound("Tarefa não existe");

        return Ok(Verificar);

    }

    [HttpPut("Atualizar/{id}")]
    public IActionResult AtualizarPorId(int id, Tarefas tarefas)
    {
        var Verificar = _context.Tarefas.Find(id);

        if(Verificar == null) return NotFound("Tarefa não existe");

        Verificar.Titulo = tarefas.Titulo;
        Verificar.Descricao = tarefas.Descricao;
        Verificar.Perfil = tarefas.Perfil;

        _context.Tarefas.Update(Verificar);
        _context.SaveChanges();

        return Ok(Verificar);
    }

    [HttpDelete("Deletar/{id}")]
    public IActionResult DeletarPorId(int id)
    {
        var Verificar = _context.Tarefas.Find(id);

        if(Verificar == null) return NotFound("Tarefa não existe");

        _context.Tarefas.Remove(Verificar);
        _context.SaveChanges();
        
        return NoContent();
    }
}