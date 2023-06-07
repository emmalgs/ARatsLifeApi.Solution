using System.ComponentModel.DataAnnotations;

namespace ARatsLifeApi.Models;

public class Rat
{
  public int RatId { get; set; }
  public string Name { get; set; }
  [Range(0, Int16.MaxValue, ErrorMessage = "The field {0} must be a non-negative integer")]
  public int Heat { get; set; }
  public List<Inventory> ItemInventory { get; set; }
  public List<Journey> Journey { get; set; }
}