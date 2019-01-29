using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionCode1
{
    public class ArrayProcessor
    {
        readonly int _filterValue = 999;

        public int[] SortAndFilter(int[] a)
        {
            if (a == null)
                throw new ArgumentNullException();

            return a.Where(t => t > _filterValue).OrderBy(t => t).ToArray();
        }
    }
}
