using Microsoft.EntityFrameworkCore;

namespace ARatsLifeApi.Models;

public class ARatsLifeApiContext : DbContext
{
  public DbSet<Choice> Choices { get; set; }
  public DbSet<Item> Items { get; set; }
  public DbSet<Plotpoint> Plotpoints { get; set; }
  public DbSet<Inventory> Inventories { get; set; }
  public ARatsLifeApiContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Plotpoint>()
      .HasData(
        new Plotpoint { PlotpointId = 1, Title = "A", Description = "plotpoint A", StoryPosition = 1 },
        new Plotpoint { PlotpointId = 2, Title = "B", Description = "plotpoint B", StoryPosition = 2 },
        new Plotpoint { PlotpointId = 3, Title = "C", Description = "plotpoint C", StoryPosition = 3 },
        new Plotpoint { PlotpointId = 4, Title = "D", Description = "plotpoint D", StoryPosition = 4 },
        new Plotpoint { PlotpointId = 5, Title = "E", Description = "plotpoint E", StoryPosition = 5 }
      );

      builder.Entity<Choice> ()
        .HasData(
          new Choice { ChoiceId = 1, Description = "Aa", PlotpointId = 1 },
          new Choice { ChoiceId = 2, Description = "Ab", PlotpointId = 1 },
          new Choice { ChoiceId = 3, Description = "Ba", PlotpointId = 2 },
          new Choice { ChoiceId = 4, Description = "Bb", PlotpointId = 2 },
          new Choice { ChoiceId = 5, Description = "Ca", PlotpointId = 3 },
          new Choice { ChoiceId = 6, Description = "Cb", PlotpointId = 3 }
        );
  }

}