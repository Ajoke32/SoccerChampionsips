namespace ChampWebApp.Abstractions.Repositories;

public interface IUnitOfWorkRepository
{
    public IGenericRepository<T> GenericRepository<T>() where T : class;
    Task SaveAsync();
}