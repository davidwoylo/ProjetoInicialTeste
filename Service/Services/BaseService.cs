using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Notificacoes;
using Domain.Notificacoes;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Service.Services
{
    public class BaseService<T> : Notificable, IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repositiory;
        protected readonly IMapper mapper;

        public BaseService(IRepository<T> baseRepo, IGerenciadorNotificacoes _gerenciadorNotificacoes, IMapper _mapper) : base(_gerenciadorNotificacoes)
        {
            repositiory = baseRepo;
            mapper = _mapper;
        }

        /// <summary>
        /// Listar completa sem restrições
        /// </summary>
        /// <returns></returns>
        public List<T> All() => (List<T>)repositiory.All();

        /// <summary>
        /// Listar completa assíncrono sem restrições 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<T>> AllAsync() => await repositiory.AllAsync();

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (id == 0)
            {
                // Todo: Mover mensagen para um arquivo
                throw new ArgumentException("ID não pode ser igual a zero!");
            }

            repositiory.Delete(id);
        }

        /// <summary>
        /// Delete assíncrono
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            if (id == 0)
            {
                // Todo: Mover mensagen para um arquivo
                throw new ArgumentException("ID não pode ser igual a zero!");
            }

            await repositiory.DeleteAsync(id);
        }

        /// <summary>
        /// Recupera por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            if (id == 0)
            {
                // Todo: Mover mensagen para um arquivo
                throw new ArgumentException("ID não pode ser igual a zero!");
            }

            return repositiory.Get(id);
        }

        /// <summary>
        /// Recupera por Id assíncrono
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(int id)
        {
            if (id == 0)
            {
                // Todo: Mover mensagen para um arquivo
                throw new ArgumentException("ID não pode ser igual a zero!");
            }

            return await repositiory.GetAsync(id);
        }

        /// <summary>
        /// Cadastro 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Post(T obj)
        {
            repositiory.Insert(obj);
            return obj;
        }

        /// <summary>
        /// Cadastro assíncrono
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> PostAsync(T obj)
        {
            await repositiory.InsertAsync(obj);
            return obj;
        }

        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T Put(T obj)
        {
            repositiory.Update(obj);
            return obj;
        }

        /// <summary>
        /// Atualizar assíncrono
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> PutAsync(T obj)
        {
            await repositiory.UpdateAsync(obj);
            return obj;
        }

    }
}