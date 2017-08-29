using System;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ProjectOnlyAttribute : Attribute
    {
        public bool ProjectOnly { get; set; }

        public ProjectOnlyAttribute(bool isProjectOnly)
        {
            ProjectOnly = isProjectOnly;
        }
    }
}