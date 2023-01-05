using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITeamService> _teamService;
        private readonly Lazy<IPlayerService> _playerService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger ,IMapper mapper, IDataShaper<PlayerDto> dataShaper, UserManager<User> userManager,
           IConfiguration configuration)
        {
            _teamService = new Lazy<ITeamService>(() => new TeamService(repositoryManager, logger,mapper));
            _playerService = new Lazy<IPlayerService>(() => new PlayerService(repositoryManager, logger,mapper, dataShaper));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager,configuration));


        }
        public ITeamService TeamService => _teamService.Value;

        public IPlayerService PlayerService => _playerService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
