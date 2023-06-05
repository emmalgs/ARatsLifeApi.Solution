using Microsoft.EntityFrameworkCore;

namespace ARatsLifeApi.Models;

public class ARatsLifeApiContext : DbContext
{
  public DbSet<Choice> Choices { get; set; }
  public DbSet<Item> Items { get; set; }
  public DbSet<Plotpoint> Plotpoints { get; set; }
  public ARatsLifeApiContext(DbContextOptions options) : base(options) { }
}