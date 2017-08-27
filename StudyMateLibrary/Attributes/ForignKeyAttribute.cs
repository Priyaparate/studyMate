using System;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public Type EnityType { get; set; }
        public ForeignKeyAttribute(Type t)
        {
            EnityType = t;
        }
    }
   
}