using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1_cs
{
    public class Indexer
    {
        double[] arr;
        int startIndex, endIndex;
        public Indexer(double[] arr, int startIndex, int endIndex)
        {

        }
        public int Length
        {
            get => endIndex - startIndex + 1;
        }
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                return arr[index+startIndex];
            }
            set
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                arr[index + startIndex] = value;
            }
        }
    }
}
