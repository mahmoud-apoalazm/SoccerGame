
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using SoccerGame.Presentation.ActionFilters;
using SoccerGame.Presentation.ModelBinders;

namespace SoccerGame.Presentation.Controllers
{
    [Route("api/teams")]
    [ApiController]

    public class TeamsController :ControllerBase
    {
        private readonly IServiceManager _service;
        public TeamsController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _service.TeamService.GetAllTeamsAsync(false);
            return Ok(teams);
        }


        [HttpGet("{id:guid}", Name = "TeamById")]
        public async Task<IActionResult> GetTeam(Guid id)
        {
            var team = await _service.TeamService.GetTeamAsync(id, trackChanges: false);
            return Ok(team);
        }


        [HttpGet("collection/({ids})", Name = "TeamCollection")]
        public async Task<IActionResult> GetTeamCollection([ModelBinder(BinderType =
         typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var teams =await _service.TeamService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(teams);
        }
        [HttpPost("collection")]
        public async Task<IActionResult> CreateTeamCollection([FromBody]
         IEnumerable<TeamForCreationDto> teamCollection)
        {
            var result =
            await _service.TeamService.CreateTeamCollection(teamCollection);
            return CreatedAtRoute("TeamCollection", new { result.ids },
            result.teams);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTeam([FromBody] TeamForCreationDto team)
        {
            var createdTeam =await _service.TeamService.CreateTeamAsync(team);
            return CreatedAtRoute("TeamById", new { id = createdTeam.Id },
            createdTeam);
        }

        [HttpDelete("{teamId:guid}")]
        public async Task<IActionResult> DeleteTeam(Guid teamId)
        {
            await _service.TeamService.DeleteTeamAsync(teamId, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{teamId:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTeam(Guid teamId, [FromBody] TeamForUpdateDto team)
        { 
           
            await _service.TeamService.UpdateTeamAsync(teamId, team, trackChanges: true);
            return NoContent();
        }

    }
}
