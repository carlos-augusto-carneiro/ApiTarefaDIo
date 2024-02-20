using ApiTarefasDio.Models.Entities;
using ApiTarefasDio.Persistences.DB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static ApiTarefasDio.Models.Enums.Enumeracao;

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

    [HttpGet("ObeterTodos")]
    public IActionResult ObeterTodos()
    {
        List<Tarefas> tarefa = _context.Tarefas.ToList();

        if(tarefa == null) return NotFound("Não existe Tarefa Cadastrada");

        return Ok(tarefa);
    }

    [HttpGet("ObeterPorTitulo/{titulo}")]
    public IActionResult ObeterPorTitulo(string titulo)
    {
        var VerificarTitulo = _context.Tarefas.Where( x => x.Titulo.Equals(titulo));

        if(VerificarTitulo == null) return NotFound("Não existe Tarefa com esse titulo cadastrada");

        return Ok(VerificarTitulo);
    }

    [HttpGet("ObeterPorData/{Data}")]
    public IActionResult ObeterPorData(DateTime Data)
    {
        var VerificarData = _context.Tarefas.Where( D => D.Data.Date == Data.Date);

        if(VerificarData == null) return NotFound("Não existe tarefa com essa data");

        return Ok(VerificarData);
    }

    [HttpGet("ObeterPorStatus/{status}")]
    public IActionResult ObeterPorStatus(StatusEnums status)
    {
        var VerificarStatus = _context.Tarefas.Where( s => s.Perfil == status);
        
        if(VerificarStatus == null) return NotFound("Não existe tarefa cadastrada");

        return Ok(VerificarStatus);
    }
}