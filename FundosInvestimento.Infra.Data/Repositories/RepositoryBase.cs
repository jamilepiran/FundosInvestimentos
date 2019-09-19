using System;
using System.Collections.Generic;
using System.Linq;
using FundosInvestimento.Domain.Interfaces.Repositories;
using FundosInvestimento.Domain.Interfaces.Services;
using FundosInvestimento.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FundosInvestimento.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly FundosInvestimentoContext _db;
        public RepositoryBase(FundosInvestimentoContext fundosInvestimentoContext)
        {
            _db = fundosInvestimentoContext;
        }

        //protected FundosInvestimentoContext Db = new FundosInvestimentoContext();

        public void Add(TEntity obj)
        {
            _db.Set<TEntity>().Add(obj);
            _db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _db.Set<TEntity>().Remove(obj);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}