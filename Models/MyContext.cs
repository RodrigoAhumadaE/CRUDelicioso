#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CRUDelicioso.Models;

public class MyContext : DbContext{
    public DbSet<Plato> Platos {get;set;}

    public MyContext(DbContextOptions options) : base(options){}
}