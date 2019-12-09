using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace array
{
    public class ListOPeolpe
    {

        public SortedList<string, Person> People()
        {
            var people = new SortedList<string, Person>
            {
                { "Agaba", new Person { Name = "Agaba", Country = CountryEnum.TZ, Age = 43 } },
                { "Stella", new Person { Name = "Stella", Country = CountryEnum.UG, Age = 42 } },
                { "Megan", new Person { Name = "Megan", Country = CountryEnum.KY, Age = 35 } }
            };
            return people;
        }
    }
}
