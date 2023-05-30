namespace ChampWebApp.Abstractions.Repositories;

public interface IRepositoryFactory
{
    public IGenericRepository<T> Instance<T>(object dbContext) where T:class;
}