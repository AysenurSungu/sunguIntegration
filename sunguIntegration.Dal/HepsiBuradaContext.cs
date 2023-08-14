using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using sunguIntegration.Dal.Entities;
using sunguIntegration.Dal.Models;

namespace sunguIntegration.Dal;
public class HepsiburadaContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public HepsiburadaContext(DbContextOptions options) : base(options)
    {

    }

    public HepsiburadaContext()
    {

    }
}