using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SDove : CBird
    {
        public const string SpecPre = "D";

        public int SpecData = 0; // Weight kg
        
        public SDove()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Weight: {SpecData} kg";
        }
    }
}