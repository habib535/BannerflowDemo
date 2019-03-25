using System.Collections.Generic;
using System.Threading.Tasks;

namespace BannerFlowDemo.Domain.RepositoryContracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<bool> Any();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
