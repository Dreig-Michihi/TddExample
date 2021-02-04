using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_cs
{
    public class Indexer
    {
        double[] arr;
        int startIndex, endIndex;
        public Indexer(double[] array, int firstIndex, int length)
        {
            if (firstIndex < 0 || length <= 0 || firstIndex + length >= array.Length)
                throw new ArgumentException();
            arr = array;
            startIndex = firstIndex;
            endIndex = firstIndex + length - 1;
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
