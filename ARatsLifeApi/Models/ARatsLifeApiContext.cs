using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ARatsLifeApi.Models;

public class ARatsLifeApiContext : IdentityDbContext<ApplicationUser>
{
  public DbSet<Rat> Rats { get; set; }
  public DbSet<Choice> Choices { get; set; }
  public DbSet<Item> Items { get; set; }
  public DbSet<Plotpoint> Plotpoints { get; set; }
  public DbSet<Inventory> Inventories { get; set; }
  public DbSet<Journey> Journies { get; set; }
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

    builder.Entity<Choice>()
      .HasData(
        new Choice { ChoiceId = 1, Description = "Aa", HeatLevel = 30, PlotpointId = 1 },
        new Choice { ChoiceId = 2, Description = "Ab", HeatLevel = 0, PlotpointId = 1 },
        new Choice { ChoiceId = 3, Description = "Ba", HeatLevel = 10, PlotpointId = 2 },
        new Choice { ChoiceId = 4, Description = "Bb", HeatLevel = 25, PlotpointId = 2 },
        new Choice { ChoiceId = 5, Description = "Ca", HeatLevel = 0, PlotpointId = 3 },
        new Choice { ChoiceId = 6, Description = "Cb", HeatLevel = 35, PlotpointId = 3 }
      );

    builder.Entity<Item>()
            .HasData(
              new Item { ItemId = 1, Name = "Gucci Belt", Value = 25},
              new Item { ItemId = 2, Name = "Balenciaga Sunglasses", Value = 35},
              new Item { ItemId = 3, Name = "Louis Vuitton Necktie", Value = 15},
              new Item { ItemId = 4, Name = "Hermez Birken Bag", Value = 50},
              new Item { ItemId = 5, Name = "Rolex Wristwatch", Value = 40},
              new Item { ItemId = 6, Name = "White Stilton Gold Cheese", Value = 50},
              new Item { ItemId = 7, Name = "$200, Straight Up", Value = 15},
              new Item { ItemId = 8, Name = "Silver Tiffany Tennis Bracelet", Value = 20},
              new Item { ItemId = 9, Name = "Gucci Slides (Whatever those are)", Value = 10},
              new Item { ItemId = 10, Name = "Versace Platform Heels", Value = 30 }
            );

    builder.Entity<Rat>()
            .HasData(
              new Rat { RatId = 1, Name = "Remy le Rouge", Heat = 40 });

    base.OnModelCreating(builder);
  }

}