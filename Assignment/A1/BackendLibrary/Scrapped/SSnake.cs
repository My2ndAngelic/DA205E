using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendLibrary
{
    public class SSnake : CReptile
    {
        public const string SpecPre = "S";
        public SSnake()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}