using StudyMateLibrary.Enities;
using StudyMateLibrary.FrameWork;
using StudyMateLibrary.FrameWork.CustomExceptions;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace StudyMateLibrary.Extentions
{
    public static class EntityExtention
    {
        public static void ValidateDependancies<T>(this Entity entity)
        {
            var dependancies = new List<string> ();
            var Informations = new List<string>();
            var dependancy = EntityManager.GetDependancy(typeof(T));
            foreach (var item in dependancy)
            {
                var repository = GetRepositoryInstance(item.Key);
                var member = item.Value;
                
                var filter = GetExpression(item.Key, member.Name, entity.Id).Compile();
                var filterArry = new object[] { filter };

                var EntityDeclaration = EntityManager.GetEntityddeclation(item.Key);
                int result = 0;
                if (EntityDeclaration.CascadeDelete)
                {

                    var resultobj = repository.GetType().GetMethod("Delete").Invoke(repository, filterArry);
                    int.TryParse(Convert.ToString(resultobj), out result);
                    Informations.Add($"{item.Key.Name}  {result} is deleted");
                }
                else
                {
                    var resultobj = repository.GetType().GetMethod("Count").Invoke(repository, filterArry);
                  
                    int.TryParse(Convert.ToString(resultobj), out result);
                    if (result > 0)
                    {
                        dependancies.Add(item.Key.Name + $" {result} records associated. Cannot delete");
                    }


                }

              
            }
            if (dependancy.Any())
            {
                throw new ProhibitCascadeDeleteException() { ValidationResults = dependancies };

            }
              
        }

        private static LambdaExpression GetExpression(Type t, string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(t, "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
           // MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            MethodInfo method = typeof(string).GetMethod("Equals", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);
            var RepoType = typeof(Func<,>);
            Type[] typeArgs = { t, typeof(bool) };
            var makeme = RepoType.MakeGenericType(typeArgs);
            var exp = Expression.Lambda(makeme, containsMethodExp, parameterExp);
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