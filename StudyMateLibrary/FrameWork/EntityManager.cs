using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StudyMateLibrary.FrameWork
{
    public static class EntityManager
    {
        public static Dictionary<Type, List<MemberDeclaration>> MemberDeclarationList { get; set; }

        static EntityManager()
        {
            MemberDeclarationList = new Dictionary<Type, List<MemberDeclaration>>();
        }

        public static void LoadAssembly(Assembly assembly)
        {
            var classes = assembly.GetExportedTypes().Where(x => x.Namespace == "StudyMateLibrary.Enities");
            var dipendancy = new Dictionary<Type, List<Type>>();
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
                var customAtributes = member.GetCustomAttributes();
                memberDeclaration.EnityType = item;
                memberDeclaration.MemberInfo = member;
                memberDeclaration.MemberName = member.Name;
                foreach (var attribute in customAtributes)
                {
                    memberDeclaration.HandleAttributes(attribute);
                }
                memberDesclations.Add(memberDeclaration);
            }
            MemberDeclarationList.Add(item, memberDesclations);
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

        public static Dictionary<Type,MemberInfo> GetDependancy(Type type)
        {
            return MemberDeclarationList[type].Where(x=>x.IsPrimaryKey==true).FirstOrDefault().Dependancies;
        }
    }
}