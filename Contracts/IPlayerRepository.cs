using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts;

public interface IPlayerRepository
{
      Task<PagedList<Player>> GetPlayersAsync(Guid teamId, PlayerParameters playerParameters , bool trackChanges);
     Task<Player?> GetPlayerAsync(Guid teamId, Guid playerId, bool trackChanges);
    void CreatePlayerForTeam(Guid teamId, Player player);
    void DeletePlayer(Player player);

}
