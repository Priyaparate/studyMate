using StudyMateLibrary.Enities;
using StudyMateLibrary.Extentions;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyMateLibrary.Domains
{
    public class CommonDomain<T> : IDisposable where T : Entity, new()
    {
        protected IRepository<T> _repository;

        public CommonDomain()
        {
            _repository = new Repository<T>();
        }

        public CommonDomain(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual bool Add(T entity)
        {
            _repository.Add(entity);

            return true;
        }

        public virtual bool Delete(T entity)
        {
            entity.ValidateDependancies<T>();

            return _repository.Delete(t => t.Id == entity.Id);
        }

        public void Dispose()
        {
            _repository = null;
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public virtual IEnumerable<T> List(Func<T, bool> filter = null)
        {
            if (filter == null)
            {
                return _repository.List();
            }
            else
            {
                return _repository.List(filter);
            }
        }

        public virtual bool Update(Expression<Func<T, bool>> filter, T test)
        {
            return _repository.UpdateOne(filter, test);
        }

    }
}