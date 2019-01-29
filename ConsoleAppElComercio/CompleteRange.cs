using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppElComercio
{
    public class CompleteRange
    {
        public List<int> build(List<int> list)
        {
            var listInt = new List<int>();
            var maxInt = list.Max();
            listInt = Enumerable.Range(1, maxInt).ToList();
            return listInt;
        }
    }
}
