
namespace Entities.Exceptions;

public sealed class TeamNotFoundException :NotFoundException
{
    public TeamNotFoundException(Guid teamId)
        : base($"The team with id: {teamId} doesn't exist in the database.")

    {

    }
}
