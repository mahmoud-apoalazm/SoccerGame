using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAllTeamsAsync(bool trackChanges);
    Task<Team?> GetTeamAsync(Guid teamId, bool trackChanges);
    Task<IEnumerable<Team>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    public void CreateTeam(Team team);
    public void DeleteTeam(Team team);
}
