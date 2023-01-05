using Entities.Constants;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PlayerForManipulationDto
    {

        [Required(ErrorMessage = "Player name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; } 

        [Required(ErrorMessage = "Age is a required field.")]
        [Range(6, int.MaxValue, ErrorMessage = "Number is required and it can't be lower than 6")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Player Number is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number is required and it can't be lower than 1")]
        public int Number { get; init; }

        public Foot Foot { get; set; }
        public Position Position { get; set; }

    }
}
