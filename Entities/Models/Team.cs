using Entities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Team
{
    [Column("TeamId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Team name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string Name { get; set; }=string.Empty;

    [Required(ErrorMessage = "Country name is a required field.")]
    public string Country { get; set; } = string.Empty;

    public Color Color { get; set; }
    public ICollection<Player> Players { get; set; } = new List<Player>();
}
