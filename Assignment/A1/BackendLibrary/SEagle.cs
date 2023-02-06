using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SEagle : CBird
    {
        public const string SpecPre = "E";
        
        public int SpecData = 0; // Weight kg
        
        public SEagle()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Weight: {SpecPre} kg";
        }
    }
}