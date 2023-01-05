using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using SoccerGame.Presentation.ActionFilters;
using System.Text.Json;

namespace SoccerGame.Presentation.Controllers
{
    [Route("api/teams/{teamId}/players")]
    [ApiController]
    public class PlayersController :ControllerBase
    {
        private readonly IServiceManager _service;
        public PlayersController(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetPlayersForTeam(Guid teamId, [FromQuery] PlayerParameters playerParameters)
        {
            var pagedResult = await  _service.PlayerService.GetPlayersAsync(teamId,playerParameters, false);
            Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.players);
        }

        [HttpGet("{playerId:guid}",Name = "GetPlayerForTeam")]
        public async Task<IActionResult> GetPlayersForTeam(Guid teamId,Guid playerId)
        {
            var player = await _service.PlayerService.GetPlayerAsync(teamId, playerId,false);
            return Ok(player);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreatePlayer(Guid teamId,[FromBody] PlayerForCreationDto player)
        {
            var createdPlayer = await _service.PlayerService.CreatePlayerForTeamAsync(teamId,player,false);
            return CreatedAtRoute("GetPlayerForTeam", new { teamId = teamId, playerId = createdPlayer.Id },
            createdPlayer);
        }


        [HttpDelete("{playerId:guid}")]
        public async Task<IActionResult> DeletePlayerForTeam(Guid teamId, Guid playerId)
        {
             await _service.PlayerService.DeletePlayerForTeamAsync(teamId, playerId, trackChanges:false);
            return NoContent();
        }

        [HttpPut("{playerId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePlayerForTeam(Guid teamId, Guid playerId,
         [FromBody] playerForUpdateDto player)
        {

          await  _service.PlayerService.UpdatePlayerForTeamAsync(teamId, playerId, player,
            teamTrackChanges: false, playerTrackChanges: true);
            return NoContent();
        }


        [HttpPatch("{playerId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PartiallyUpdatePlayerForTeam(Guid teamId, Guid playerId,
            [FromBody] JsonPatchDocument<playerForUpdateDto> patchDoc)
        {
            var result =await _service.PlayerService.GetPlayerForPatchAsync(teamId, playerId,
             false,
             true);
            patchDoc.ApplyTo(result.playerToPatch);
            TryValidateModel(result.playerToPatch);

            await _service.PlayerService.SaveChangesForPatchAsync(result.playerToPatch,
            result.playerEntity);
            return NoContent();
        }
    }
}
