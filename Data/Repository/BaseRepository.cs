using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly TesteContext _context;
        protected readonly DbSet<T> DbSet;

        protected BaseRepository(TesteContext db)
        {
            _context = db;
            DbSet = db.Set<T>();
        }

        /// <summary>
        /// Listar completa sem restri��es
        /// </summary>
        /// <returns></returns>
        public IList<T> All()
        {
            return DbSet.ToList();
        }

        /// <summary>
        /// Listar completa ass�ncrono sem restri��es 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> AllAsync()
        {
            return await DbSet.ToListAsync();
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            DbSet.Remove(Get(id));
            SaveChanges();
        }

        /// <summary>
        /// Delete ass�ncrono
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            DbSet.Remove(Get(id));
            await SaveChangesAsync();
        }

        /// <summary>
        /// Recupera por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Recupera por Id ass�ncrono
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        /// <summary>
        /// Cadastro 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Insert(T obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        /// <summary>
        /// Cadastro ass�ncrono
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task InsertAsync(T obj)
        {
            await DbSet.AddAsync(obj);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Salva altera��es
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Salva altera��es ass�ncrono
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Atualizar ass�ncrono
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void BeginTransactionAsync()
        {
            _context.Database.BeginTransactionAsync();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
    }
}