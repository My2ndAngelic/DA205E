using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SEagle : CBird
    {
        public const string SpecPre = "E";
        public SEagle()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}