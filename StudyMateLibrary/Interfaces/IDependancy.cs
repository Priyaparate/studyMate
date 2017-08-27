using System;
using System.Collections.Generic;

namespace StudyMateLibrary.Interfaces
{
    public interface IDependancy
    {
        IDictionary<Type, string> GetDipendancies();
    }
}