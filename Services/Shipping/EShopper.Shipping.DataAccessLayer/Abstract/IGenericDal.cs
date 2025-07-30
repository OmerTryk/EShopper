namespace EShopper.Shipping.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
