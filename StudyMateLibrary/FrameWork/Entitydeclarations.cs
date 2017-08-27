using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyMateLibrary.FrameWork
{
  public  class Entitydeclarations
    {
        public bool CascadeDelete { get; set; }
        public bool ProjectOnly { get; set; }
        public Entitydeclarations()
        {
            CascadeDelete = false;
            ProjectOnly = false;
        }

    }
}
