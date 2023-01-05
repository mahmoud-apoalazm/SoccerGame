using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface IServiceManager
{
    ITeamService TeamService { get; }
    IPlayerService PlayerService { get; }
    IAuthenticationService AuthenticationService { get; }

}
