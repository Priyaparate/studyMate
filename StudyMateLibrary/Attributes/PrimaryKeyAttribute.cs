using System;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
        public Type EnityType { get; set; }

        public PrimaryKeyAttribute()
        {
        }
    }
}