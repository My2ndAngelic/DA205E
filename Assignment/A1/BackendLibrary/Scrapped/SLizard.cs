using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SLizard : CReptile
    {
        public const string SpecPre = "L";
        public SLizard()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}