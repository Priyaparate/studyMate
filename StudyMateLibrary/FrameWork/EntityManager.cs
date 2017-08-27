using StudyMateLibrary.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StudyMateLibrary.FrameWork
{
    public static class EntityManager
    {
        public static Dictionary<Type, List<MemberDeclaration>> MemberDeclarationList { get; set; }
        public static Dictionary<Type, Entitydeclarations> EntityDeclarationList { get; set; }

        static EntityManager()
        {
            MemberDeclarationList = new Dictionary<Type, List<MemberDeclaration>>();
            EntityDeclarationList = new Dictionary<Type, Entitydeclarations>();
        }

        public static void LoadAssembly(Assembly assembly)
        {
            var classes = assembly.GetExportedTypes().Where(x => x.Namespace == "StudyMateLibrary.Enities");
            var dipendancy = new Dictionary<Type, List<Type>>();
            HandleEntityLevelAttributes(classes);
            foreach (var item in classes)
            {
                AddDecaration(item);
            }
            HandleDepedancy();
        }

        private static void AddDecaration(Type item)
        {
            var members = item.GetProperties();
            var memberDesclations = new List<MemberDeclaration>();

            foreach (var member in members)
            {
                var memberDeclaration = new MemberDeclaration();
                memberDeclaration.EnityType = item;
                memberDeclaration.MemberInfo = member;
                memberDeclaration.MemberName = member.Name;
                HandleFieldLevelAttributes(member, memberDeclaration);

                memberDesclations.Add(memberDeclaration);
            }
            MemberDeclarationList.Add(item, memberDesclations);
        }

        private static void HandleEntityLevelAttributes(IEnumerable<Type> entities)
        {
            foreach (var entity in entities)
            {
                var attributes = entity.GetCustomAttributes();
                
                var entityDeclaration = new Entitydeclarations();
               
                foreach (var attribue in attributes)
                {
                    if (entity.Name == nameof(CascadeDeleteAttribute))
                    {
                        var atr = (CascadeDeleteAttribute)attribue;
                        entityDeclaration.CascadeDelete = atr.Allowed;
                    }
                    else
                    {
                        entityDeclaration.CascadeDelete = false;
                    }
                    if (entity.Name == nameof(ProjectOnlyAttribute))
                    {
                        var atr = attribue as ProjectOnlyAttribute;
                        entityDeclaration.ProjectOnly = atr.ProjectOnly;
                    }
                    else
                    {
                        entityDeclaration.ProjectOnly = false;
                    }
                }
                EntityDeclarationList.Add(entity, entityDeclaration);
            }
        }

        private static void HandleFieldLevelAttributes(PropertyInfo member, MemberDeclaration memberDeclaration)
        {
            var customAtributes = member.GetCustomAttributes();

            foreach (var attribute in customAtributes)
            {
                memberDeclaration.HandleAttributes(attribute);
            }
        }

        public static void HandleDepedancy()
        {
            foreach (var item in MemberDeclarationList)
            {
                foreach (var declare in item.Value)
                {
                    AddDependancy(declare);
                }
            }
        }

        private static void AddDependancy(MemberDeclaration declare)
        {
            var HasForeinkeyWithDeclaration = declare.IsForignKey && MemberDeclarationList.ContainsKey(declare.foreignKeyEntity);
            if (HasForeinkeyWithDeclaration)
            {
                var dep = MemberDeclarationList[declare.foreignKeyEntity].First(x => x.IsPrimaryKey == true);
                dep.Dependancies.Add(declare.EnityType, declare.MemberInfo);
            }
        }

        public static Dictionary<Type, MemberInfo> GetDependancy(Type type)
        {
            return MemberDeclarationList[type].Where(x => x.IsPrimaryKey == true).FirstOrDefault().Dependancies;
        }
        public static Entitydeclarations GetEntityddeclation(Type type)
        {

            return EntityDeclarationList[type];
        }
    }
}