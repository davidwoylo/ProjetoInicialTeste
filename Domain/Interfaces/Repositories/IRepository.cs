using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> All();
        Task<IList<T>> AllAsync();

        void Delete(int id);
        Task DeleteAsync(int id);

        T Get(int id);
        Task<T> GetAsync(int id);

        void Insert(T obj);
        Task InsertAsync(T obj);

        void SaveChanges();
        Task SaveChangesAsync();
        
        void Update(T obj);
        Task UpdateAsync(T obj);

        void BeginTransaction();
        void BeginTransactionAsync();

        void Commit();
        void Rollback();
    }
}