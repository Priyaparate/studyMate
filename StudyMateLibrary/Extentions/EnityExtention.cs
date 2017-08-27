using StudyMateLibrary.Domains;
using StudyMateLibrary.Enities;
using StudyMateLibrary.FrameWork;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StudyMateLibrary.Extentions
{
    public static class EnityExtention
    {
        public static Dictionary<string, string> validateDependancies<T>(this Entity entity)
        {
            var dependancies = new Dictionary<string, string>();
           var dependancy= EntityManager.GetDependancy(typeof(T));
            foreach (var item in dependancy)
            {
                var repository = GetRepositoryInstance(item.Key) as IRepository<T>;
                var member = item.Value;
                var count = repository.Count(x=>CheckConditionForCount(x,member, entity.Id));
            }



            return dependancies;
        }

        private static bool CheckConditionForCount<T>(T enity,MemberInfo m,string id)
        {
                  
            return true;
        }

        public static Expression<Func<T, bool>> GetPropertySelector<T>( Type t,string propertyName, string value)
        {
            var arg = Expression.Parameter(t, "x");
            var property = Expression.Property(arg, propertyName);
            //return the property as object
            var conv = Expression.Convert(property, typeof(bool));
            var exp = Expression.Lambda<Func<T, bool>>(conv, new ParameterExpression[] { arg });
            return exp;
        }

        private static object GetRepositoryInstance(Type EnityType)
        {
            /*  Type EnityType = dependacy.EnityType*/
            ;
            var RepoType = typeof(Repository<>);
            Type[] typeArgs = { EnityType };
            var makeme = RepoType.MakeGenericType(typeArgs);
            object obj = Activator.CreateInstance(makeme);
            var repo = Convert.ChangeType(obj, makeme);
            return repo;
        }

    }
}