using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IService<T> where T : class
    {
        List<T> All();
        Task<IList<T>> AllAsync();

        void Delete(int id);
        Task DeleteAsync(int id);

        T Get(int id);
        Task<T> GetAsync(int id);

        T Post(T obj);
        Task<T> PostAsync(T obj);

        T Put(T obj);
        Task<T> PutAsync(T obj);
    }
}