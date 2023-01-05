using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class TeamRepository :RepositoryBase<Team>,ITeamRepository
{
	public TeamRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{

	}



    public async Task<IEnumerable<Team>> GetAllTeamsAsync(bool trackChanges) =>
        await FindAll(trackChanges)
            .OrderBy(t => t.Name)
            .ToListAsync();

    public async Task<Team?> GetTeamAsync(Guid teamId, bool trackChanges)
    {
        return await FindByCondition(t => t.Id.Equals(teamId), trackChanges)
                    .SingleOrDefaultAsync();
    }

    public void CreateTeam(Team team) => Create(team);

    public async Task<IEnumerable<Team>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        return await FindByCondition(x => ids.Contains(x.Id), trackChanges)
             .ToListAsync();
    }

    public void DeleteTeam(Team team) => Delete(team);
}
