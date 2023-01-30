using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SDove : CBird
    {
        public const string SpecPre = "D";
        
        
        public SDove()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}