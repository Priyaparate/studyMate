using System;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CascadeDeleteAttribute : Attribute
    {
        public bool Allowed { get; set; }

        public CascadeDeleteAttribute(bool isAllowed)
        {
            Allowed = isAllowed;
        }
    }
}