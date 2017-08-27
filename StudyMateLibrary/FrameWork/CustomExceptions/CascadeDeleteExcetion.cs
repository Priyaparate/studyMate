using System;
using System.Collections.Generic;

namespace StudyMateLibrary.FrameWork.CustomExceptions
{
    public class ProhibitCascadeDeleteException : Exception
    {
        public List<string> ValidationResults { get; set; }
        public new string Message { get; set; }

        public ProhibitCascadeDeleteException()
        {
            Message = "Associated entity Present Record -Exception";
        }
    }
}