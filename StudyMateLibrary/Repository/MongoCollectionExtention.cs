using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudyMateLibrary.Repository
{
    public static class MongoCollectionExtention
    {
        public static bool UpdateOne<T>(this IRepository<T> repository, Expression<Func<T, bool>> filter, T entity) where T : class, new()
        {
            var originalEntity = repository.Get(filter);
            UpdateDefinition<T> updateField = GetUpdateFieldBuider(originalEntity,entity);
           
            var updateResult = repository._Db.Collection.UpdateMany<T>(filter,updateField);
            
            return updateResult.IsModifiedCountAvailable;
        }

        private static UpdateDefinition<T> GetUpdateFieldBuider<T>(T originalEntity, T entity) where T : class, new()
        {
            var set = Builders<T>.Update;
            var list = new List<UpdateDefinition<T>>();
            var members = typeof(T).GetProperties();

            foreach (var item in members)
            {
              
                var originalItemvalue = item.GetValue(originalEntity);
                var entitylItemvalue = item.GetValue(entity);    
                if (originalItemvalue!=entitylItemvalue && entitylItemvalue!=null )
                {
                    list.Add(set.Set(item.Name, entitylItemvalue));
                }
            }
            return set.Combine(list);
        }

        public static bool Delete<T>(this IRepository<T> repository, Expression<Func<T, bool>> filter) where T : class, new()
        {
            
            var updateResult = repository._Db.Collection.DeleteMany<T>(filter);

            if (updateResult.DeletedCount > 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}