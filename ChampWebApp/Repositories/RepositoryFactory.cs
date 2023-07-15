using ChampWebApp.Abstractions.Repositories;

namespace ChampWebApp.Repositories;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly Dictionary<Type, object> _repos = new Dictionary<Type, object>();
    
    public IGenericRepository<T> Instance<T>(object dbContext) where T : class
    {
        var entityType = typeof(T);

        if (!_repos.ContainsKey(entityType))
        {
            object repositoryInstance = new GenericRepository<T>((ChampoinoshipsContext)dbContext);
            _repos[entityType] = repositoryInstance;
        }

        return (GenericRepository<T>)_repos[entityType];
    }
}