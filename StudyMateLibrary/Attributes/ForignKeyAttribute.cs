using System;

namespace StudyMateLibrary.Attributes
{
    public class ForeignKeyAttribute : Attribute
    {
        public Type EnityType { get; set; }
        public ForeignKeyAttribute(Type t)
        {
            EnityType = t;
        }
    }
    public class PrimaryKeyAttribute : Attribute
    {
        public Type EnityType { get; set; }
        public PrimaryKeyAttribute()
        {
            //EnityType = t;
        }
    }
}