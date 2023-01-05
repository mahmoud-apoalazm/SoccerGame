using Entities.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models;

public class Player
{
    [Column("PlayerId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Player name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Age is a required field.")]
    [Range(6, int.MaxValue)]
    public int Age { get; set; }

    [Required(ErrorMessage = "Player Number is a required field.")]
    [Range(1,int.MaxValue)]
    public int Number { get; set; }

    public Foot Foot { get; set; }
    public Position Position { get; set; }
    [ForeignKey(nameof(Team))]
    public Guid TeamId { get; set; }
    public Team? Team { get; set; }
}
