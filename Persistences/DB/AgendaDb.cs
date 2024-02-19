using ApiTarefasDio.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApiTarefasDio.Persistences.DB;


public class AgendaDb : DbContext
{
    public AgendaDb(DbContextOptions<AgendaDb> options) : base(options)
    {}


    public DbSet<Tarefas> Tarefas { get; set;}
}