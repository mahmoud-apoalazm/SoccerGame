using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Constants;

namespace Shared.DataTransferObjects
{
    public record TeamDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }

        public string? Country { get; init; } 

        public Color Color { get; init; }
    }
}
