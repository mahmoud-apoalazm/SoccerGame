using Entities.Constants;

namespace Shared.DataTransferObjects
{
    public record PlayerDto
    {
        public Guid Id { get; init; }
        
        public string? Name { get; init; } 

        public int Age { get; init; }

        public int Number { get; init; }

        public Foot Foot { get; init; }
        public Position Position { get; init; }

    }
}
