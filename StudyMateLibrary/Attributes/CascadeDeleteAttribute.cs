using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMateLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CascadeDeleteAttribute :Attribute
    {
        public bool Allowed { get; set; }
        public CascadeDeleteAttribute( bool isAllowed)
        {
            Allowed = isAllowed;
        }
    }
}
