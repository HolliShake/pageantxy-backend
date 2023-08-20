using DOMAIN.model;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public DbSet<Register> Registers { get; set; }
    public DbSet<Score> Scores { get; set; }
    public DbSet<Log> Logs { get; set; } 
}