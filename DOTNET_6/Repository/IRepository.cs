namespace DOTNET_6.Repository
{
    public interface IRepository<TModel,TId>
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(TId id);
        TModel Add(TModel model);
        TModel Update(TModel model);
        void Delete(TId id);
    }
}
