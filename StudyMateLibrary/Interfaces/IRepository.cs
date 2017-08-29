using Mongo.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyMateLibrary.Repository
{
    public interface IRepository<T>
    {
        MongoCollectionSet<T> _Db { get; set; }

        void Add(T t);

        int Count(Func<T, bool> filter = null);

        void Delete(string id);

        T Get(Expression<Func<T, bool>> filter);

        IEnumerable<T> List(Func<T, bool> filter = null);

        void Update(string id, T t);
    }
}