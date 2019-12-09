using System;
using System.Collections.Generic;
using System.Text;

namespace array
{   public  class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public CountryEnum Country { get; set; }
    }


    public enum CountryEnum
    {
        TZ,
        KY,
        UG
    }
}
