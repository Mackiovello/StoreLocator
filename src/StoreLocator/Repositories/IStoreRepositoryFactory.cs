namespace StoreLocator.Repositories
{
    // This is to get around the limitation with
    // ASP.NET Core's DI framework where it can't
    // handle a decorator pattern like we're doing
    // with our repositories. Thus, we have to 
    // construct the classes ourselves.
    public interface IStoreRepositoryFactory
    {
        IStoreRepository Create();
    }
}
