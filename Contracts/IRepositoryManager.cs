using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        ITeamRepository Team { get; }
        IPlayerRepository Plyer { get; }
        Task SaveAsync();
    }
}
