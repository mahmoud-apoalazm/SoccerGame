using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class PlayerNotFoundException : NotFoundException
    {
        public PlayerNotFoundException(Guid playerId)
       : base($"The player with id: {playerId} doesn't exist in the database.")

        {

        }
    }
}
