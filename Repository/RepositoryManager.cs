using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ITeamRepository> _teamRepository;
    private readonly Lazy<IPlayerRepository> _playerRepository;
    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _teamRepository = new Lazy<ITeamRepository>(() => new
       TeamRepository(repositoryContext));
        _playerRepository = new Lazy<IPlayerRepository>(() => new
       PlayerRepository(repositoryContext));
    }

    public ITeamRepository Team => _teamRepository.Value;

    public IPlayerRepository Plyer => _playerRepository.Value;

    public async Task SaveAsync() =>await _repositoryContext.SaveChangesAsync();


}
