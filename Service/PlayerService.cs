using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class PlayerService :IPlayerService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<PlayerDto> _dataShaper;

        public PlayerService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<PlayerDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        private async Task<Team> CheckIfTeamExists(Guid teamId, bool trackChanges)
        {
            var team = await _repository.Team.GetTeamAsync(teamId, trackChanges);
            if (team is null)
                throw new TeamNotFoundException(teamId);
            return team;
        }

        private async Task<Player> GetPlayerForTeamAndCheckIfItExists
       (Guid teamId, Guid playerId, bool trackChanges)
        {
            var plyerDb = await _repository.Plyer.GetPlayerAsync(teamId, playerId,trackChanges);
            if (plyerDb is null)
                throw new PlayerNotFoundException(playerId);
            return plyerDb;
        }
        //------------------------------------------------------------------------------
        public async Task<(IEnumerable<ExpandoObject> players , MetaData metaData)> GetPlayersAsync(Guid teamId,PlayerParameters playerParameters, bool trackChanges)
        {
            if (!playerParameters.ValidAgeRange) 
                throw new MaxAgeRangeBadRequestException();

            var team = await CheckIfTeamExists(teamId,false);

           var playersWithMetaData = await _repository.Plyer.GetPlayersAsync(teamId,playerParameters ,trackChanges);    
           var playersDto=_mapper.Map<IEnumerable<PlayerDto>>(playersWithMetaData);
            var shapedData = _dataShaper.ShapeData(playersDto,
            playerParameters.Fields!);
            return (players:shapedData, metaData: playersWithMetaData.MetaData);
        }

        public async Task<PlayerDto?> GetPlayerAsync(Guid teamId, Guid playerId, bool trackChanges)
        {
            var team = await CheckIfTeamExists(teamId, false);
            var playerFromDb = await GetPlayerForTeamAndCheckIfItExists(teamId,playerId,trackChanges);
            var playerDto = _mapper.Map<PlayerDto>(playerFromDb);
            return playerDto;
        }

        public async Task<PlayerDto> CreatePlayerForTeamAsync(Guid teamId, PlayerForCreationDto playerForCreationDto, bool trackChanges)
        {
            var team = await CheckIfTeamExists(teamId,trackChanges);
            var playerEntity = _mapper.Map<Player>(playerForCreationDto);
             _repository.Plyer.CreatePlayerForTeam(teamId, playerEntity);
            await _repository.SaveAsync();
            var playerToReturn = _mapper.Map<PlayerDto>(playerEntity);
            return playerToReturn;
        }

        public async Task DeletePlayerForTeamAsync(Guid teamId, Guid playerId, bool trackChanges)
        {
            var team =await CheckIfTeamExists(teamId, false);
            var playerForTeam = await GetPlayerForTeamAndCheckIfItExists(teamId, playerId, trackChanges);
            _repository.Plyer.DeletePlayer(playerForTeam);
            await _repository.SaveAsync();

        }

        public async Task UpdatePlayerForTeamAsync(Guid teamId, Guid playerId, playerForUpdateDto playerForUpdateDto, bool teamTrackChanges, bool playerTrackChanges)
        {
            var team = await CheckIfTeamExists(teamId, teamTrackChanges);
            var playerForTeam = await GetPlayerForTeamAndCheckIfItExists(teamId, playerId, playerTrackChanges);
            _mapper.Map(playerForUpdateDto, playerForTeam);
            await _repository.SaveAsync();
        }

        public async Task<(playerForUpdateDto playerToPatch, Player playerEntity)> GetPlayerForPatchAsync(Guid teamId, Guid playerId, bool teamTrackChanges, bool playerTrackChanges)
        {
            var team = await CheckIfTeamExists(teamId, teamTrackChanges);
            var playerEntity = await GetPlayerForTeamAndCheckIfItExists(teamId, playerId, playerTrackChanges);
            var playerToPatch = _mapper.Map<playerForUpdateDto>(playerEntity);
            return (playerToPatch, playerEntity);
        }

        public async Task SaveChangesForPatchAsync(playerForUpdateDto playerToPatch, Player playerEntity)
        {
            _mapper.Map(playerToPatch, playerEntity);
           await  _repository.SaveAsync();
        }

        //------------------------------------------------------------------------------

    }
}
