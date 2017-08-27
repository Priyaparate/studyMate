using StudyMateLibrary.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StudyMateLibrary.FrameWork
{
    public class MemberDeclaration
    {
        public Type foreignKeyEntity { get; set; }

        public MemberInfo MemberInfo { get; set; }
        public Type EnityType { get; set; }

        public MemberDeclaration()
        {
            IsPrimaryKey = false;
            IsForignKey = false;
            Dependancies = new Dictionary<Type, MemberInfo>();
        }

        public Dictionary<Type, MemberInfo> Dependancies { get; set; }
        public MemberInfo PrimaryKey { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForignKey { get; set; }

        public string MemberName { get; set; }

        public void HandleAttributes(Attribute attr)
        {
            if (attr is ForeignKeyAttribute)
            {
                var attrforing = (ForeignKeyAttribute)attr;
                IsForignKey = true;
                foreignKeyEntity = attrforing.EnityType;

                // set
            }
            if (attr is PrimaryKeyAttribute)
            {
                var attrforing = (PrimaryKeyAttribute)attr;
                IsPrimaryKey = true;

                // set
            }
        }
    }
}