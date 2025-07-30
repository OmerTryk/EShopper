using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.Shipping.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> TGetByIdAsync(int id);
        Task<List<T>> TGetAllAsync();
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
        Task TDeleteAsync(int id);
    }
}
