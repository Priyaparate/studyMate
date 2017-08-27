using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
      public class ProjectOnlyAttribute :Attribute
    {
        public bool ProjectOnly { get; set; }
        public ProjectOnlyAttribute(bool isProjectOnly)
        {
            ProjectOnly = isProjectOnly;
        }
    }
}
