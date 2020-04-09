using Microsoft.EntityFrameworkCore;
using SegFyYoutube.Domain.Entities;
using SegFyYoutube.Domain.Interfaces;
using SegFyYoutube.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SegFyYoutube.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SegFyContext Db;

        protected readonly DbSet<T> DbSet;

        public BaseRepository(SegFyContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public virtual void AddOrUpdate(T obj)
        {
            Db.InsertOrUpdate(obj);
            Db.SaveChanges();
        }

        public virtual T GetById(string id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(T obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(string id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
