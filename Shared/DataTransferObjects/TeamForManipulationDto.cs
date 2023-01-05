using Entities.Models;
using System.ComponentModel.DataAnnotations;
using Entities.Constants;

namespace Shared.DataTransferObjects
{
    public record TeamForManipulationDto
    {


        [Required(ErrorMessage = "Team name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; } 

        [Required(ErrorMessage = "Country name is a required field.")]
        public string Country { get; init; } = string.Empty;

        public Color Color { get; init; }
        public IEnumerable<PlayerForCreationDto>? Players { get; init; } 
    }
}
