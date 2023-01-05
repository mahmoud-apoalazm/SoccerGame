

namespace Entities.Exceptions
{
    public sealed class TeamCollectionBadRequest : BadRequestException
    {
        public TeamCollectionBadRequest()
              : base("Company collection sent from a client is null.")
        { 
        }
    }
}
