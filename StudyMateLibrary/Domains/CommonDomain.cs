using StudyMateLibrary.Enities;
using StudyMateLibrary.Extentions;
using StudyMateLibrary.FrameWork.CustomExceptions;
using StudyMateLibrary.Interfaces;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudyMateLibrary.Domains
{
    public class CommonDomain<T> : IDisposable where T : Entity, new()
    {
        private IRepository<T> _commonRepository;

        public CommonDomain()
        {
            _commonRepository = new Repository<T>();
        }

        public CommonDomain(IRepository<T> repository)
        {
            _commonRepository = repository;
        }

        public virtual bool Add(T entity)
        {
            _commonRepository.Add(entity);

            return true;
        }

        public void Dispose()
        {
            _commonRepository = null;
        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return _commonRepository.Get(filter);
        }

        public virtual IEnumerable<T> List(Func<T, bool> filter = null)
        {
            if (filter == null)
            {
                return _commonRepository.List();
            }
            else
            {
                return _commonRepository.List(filter);
            }
        }

        public virtual bool Update(Expression<Func<T, bool>> filter, T test)
        {
            return _commonRepository.UpdateOne(filter, test);
        }

        /// <summary>
        /// If has dipendancies  then handle by overrriding method in child controller.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dependancies"></param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
           entity.ValidateDependancies<T>();
            
            return _commonRepository.Delete(t => t.Id == entity.Id);
        }
    }
}