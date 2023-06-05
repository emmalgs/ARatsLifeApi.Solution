using System.ComponentModel.DataAnnotations;

namespace ARatsLifeApi.Models;
public class Choice
{
  public int ChoiceId { get; set; }
  [Required(ErrorMessage = "The choice needs a decription!")]
  public string Description { get; set; }
  public int PlotpointId { get; set; }
}