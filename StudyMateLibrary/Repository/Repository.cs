using Mongo.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace StudyMateLibrary.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private string Database { get; set; }
        private string ConnectionString { get; set; }
        public MongoCollectionSet<T> _Db { get; set; }
        public MongoClient _Client { get; set; }

        public Repository()
        {
            Setup();
        }

        private void Setup()
        {
            Database = ConfigurationManager.AppSettings["Database"];
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

            _Client = new MongoClient(ConnectionString);
            _Db = new MongoCollectionSet<T>(_Client, Database);
        }

        public Repository(MongoCollectionSet<T> db)
        {
            _Db = db;
        }

        public void Add(T t)
        {
            _Db.Add(t);
        }

        public void Delete(string id)
        {
            _Db.Remove(id);
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return _Db.Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> List(Func<T, bool> filter = null)
        {
            if (filter == null)
            {
                return _Db.ToList();
            }
            return _Db.Where(filter);
        }

        public void Update(string id, T t)
        {
            _Db.Update(id, t);
        }

        public int Count(Func<T, bool> filter = null)
        {
            if (filter == null)
            {
                return _Db.Count();
            }
            return _Db.Count(filter);
        }
    }
}