using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IPlayerService
{
    public Task<(IEnumerable<ExpandoObject> players, MetaData metaData)> GetPlayersAsync(Guid teamId,PlayerParameters playerParameters ,bool trackChanges);
    public Task<PlayerDto?> GetPlayerAsync(Guid teamId, Guid playerId, bool trackChanges);
    public Task<PlayerDto> CreatePlayerForTeamAsync(Guid teamId, PlayerForCreationDto
           playerForCreationDto, bool trackChanges);
    Task DeletePlayerForTeamAsync(Guid teamId, Guid playerId, bool trackChanges);

    public Task UpdatePlayerForTeamAsync(Guid teamId, Guid playerId, playerForUpdateDto
       playerForUpdateDtobool ,bool teamTrackChanges, bool playerTrackChanges);
    Task<(playerForUpdateDto playerToPatch, Player playerEntity)> GetPlayerForPatchAsync(
    Guid teamId, Guid playerId, bool teamTrackChanges, bool playerTrackChanges);
    Task SaveChangesForPatchAsync(playerForUpdateDto playerToPatch, Player playerEntity);
}
