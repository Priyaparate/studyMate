namespace CoreService.Configuration
{
    //public static class EntityManager
    //{
    //    public static Dictionary<Type, List<MemberDeclaration>> MemberDeclarationList { get; set; }

    //    static EntityManager()
    //    {
    //        MemberDeclarationList = new Dictionary<Type, List<MemberDeclaration>>();
    //    }

    //    public static void LoadAssembly()
    //    {
    //        var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.FullName == "StudyMateLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
    //        var classes = assembly.GetExportedTypes().Where(x => x.Namespace == "StudyMateLibrary.Enities");
    //        var dipendancy = new Dictionary<Type, List<Type>>();
    //        foreach (var item in classes)
    //        {
    //            var members = item.GetProperties();
    //            var memberDesclations = new List<MemberDeclaration>();
    //            foreach (var member in members)
    //            {
    //                var memberDeclaration = new MemberDeclaration();
    //                var customAtributes = member.GetCustomAttributes();
    //                memberDeclaration.EnityType = item;
    //                memberDeclaration.MemberInfo = member;
    //                memberDeclaration.MemberName = member.Name;
    //                foreach (var attribute in customAtributes)
    //                {
    //                    memberDeclaration.HandleAttributes(attribute);
    //                }
    //                memberDesclations.Add(memberDeclaration);
    //            }
    //            MemberDeclarationList.Add(item, memberDesclations);
    //        }
    //    }

    //    public static void HandleDepedancy()
    //    {
    //        foreach (var item in MemberDeclarationList)
    //        {
    //            foreach (var declare in item.Value)
    //            {
    //                if (declare.IsForignKey)
    //                {
    //                    if (MemberDeclarationList.ContainsKey(declare.foreignKeyEntity))
    //                    {
    //                        var dep = MemberDeclarationList[declare.foreignKeyEntity].First(x => x.IsPrimaryKey == true);
    //                        dep.Dependancies.Add(declare.EnityType, declare.MemberInfo);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public static IEnumerable<MemberDeclaration> GetDependancy(Type type)
    //    {
    //        return MemberDeclarationList[type];
    //    }
    //}
}