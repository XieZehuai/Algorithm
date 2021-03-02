using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Sort
{
    interface ISorter
    {
        string Name { get; }

        void Sort<T>(T[] arr) where T : IComparable<T>;

        void Sort<T>(T[] arr, int low, int high) where T : IComparable<T>;
    }
}
