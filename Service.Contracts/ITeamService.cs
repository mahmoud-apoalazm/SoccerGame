using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface ITeamService
{
    Task<IEnumerable<TeamDto>> GetAllTeamsAsync(bool trackChanges);
    Task<TeamDto?> GetTeamAsync(Guid teamId,bool trackChanges);
    Task<TeamDto> CreateTeamAsync(TeamForCreationDto team);
    Task<IEnumerable<TeamDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<TeamDto> teams, string ids)> CreateTeamCollection (IEnumerable<TeamForCreationDto> teamCollection);
    Task DeleteTeamAsync(Guid teamId,  bool trackChanges);
    public Task UpdateTeamAsync(Guid teamId, TeamForUpdateDto teamForUpdateDto, bool trackChanges);
}
