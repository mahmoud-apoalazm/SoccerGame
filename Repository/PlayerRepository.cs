using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Repository.Extensions;

namespace Repository;

public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
{
    public PlayerRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {

    }


    public async Task<PagedList<Player>> GetPlayersAsync(Guid teamId, PlayerParameters playerParameters ,bool trackChanges)
    {
       var players= await FindByCondition(
           p => p.TeamId.Equals(teamId) ,trackChanges)
            .FilterPlayers(playerParameters.MinAge, playerParameters.MaxAge)
            .Search(playerParameters.SearchTerm!)
            .Sort(playerParameters.OrderBy!)
            .ToListAsync();


      //  var count = await FindByCondition(p =>
      //  p.TeamId.Equals(teamId), trackChanges).CountAsync();

        return  PagedList<Player>.ToPagedList(players,
        playerParameters.PageNumber, playerParameters.PageSize);
    }

    public async Task<Player?> GetPlayerAsync(Guid teamId, Guid playerId, bool trackChanges)
    {
        return await FindByCondition(p => p.TeamId.Equals(teamId) && p.Id.Equals(playerId), trackChanges)
                     .SingleOrDefaultAsync();

    }

    public void CreatePlayerForTeam(Guid teamId, Player player)
    {
        player.TeamId = teamId;
        Create(player);
    }

    public void DeletePlayer(Player player) => Delete(player);
}
