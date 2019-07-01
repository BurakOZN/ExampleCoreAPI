using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private ManContext _db;
        private readonly DbSet<T> entitySet;
        public Repository(ManContext db)
        {
            _db = db;
            entitySet = _db.Set<T>();
        }

        public CrudState Add(T entity)
        {
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.CreateAt = DateTime.Now;
                entity.UpdateAt = DateTime.Now;
                entitySet.Add(entity);
                return Save() == ConnectionState.Success ? CrudState.Success : CrudState.ConnectionError;
            }
            catch
            {
                return CrudState.EntityError;
            }
        }

        public CrudState Add(IEnumerable<T> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.Id = Guid.NewGuid().ToString();
                }
                entitySet.AddRange(entities);
                return Save() == ConnectionState.Success ? CrudState.Success : CrudState.ConnectionError;
            }
            catch
            {
                return CrudState.ConnectionError;
            }
        }

        public CrudState Delete(string id)
        {
            try
            {
                var entity = entitySet.Find(id);
                entitySet.Remove(entity);
                return Save() == ConnectionState.Success ? CrudState.Success : CrudState.ConnectionError;
            }
            catch (Exception)
            {
                return CrudState.EntityError;
            }
        }

        public CrudState Delete(IEnumerable<T> entities)
        {
            try
            {
                entitySet.RemoveRange(entities);
                return Save() == ConnectionState.Success ? CrudState.Success : CrudState.ConnectionError;
            }
            catch (Exception)
            {
                return CrudState.EntityError;
            }
        }

        public List<T> Get()
        {
            return _db.Set<T>().ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> where)
        {
            return _db.Set<T>().Where(where).ToList();
        }

        public CrudState Update(T entity)
        {
            T old = _db.Set<T>().Find(entity.Id);
            if (old != null)
            {
                try
                {
                    entity.UpdateAt = DateTime.Now;
                    _db.Entry(old).CurrentValues.SetValues(entity);
                    return Save() == ConnectionState.Success ? CrudState.Success : CrudState.ConnectionError;
                }
                catch (Exception)
                {

                    return CrudState.EntityError;
                }
            }
            else
                return CrudState.NotFound;
        }



        private ConnectionState Save()
        {
            try
            {
                _db.SaveChanges();
                return ConnectionState.Success;
            }
            catch (Exception ex)
            {
                return ConnectionState.ConnectionError;
            }
        }
    }
}
