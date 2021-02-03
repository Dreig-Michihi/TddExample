using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_cs
{
    public class LinearEquation
    {
        double[] coefficients;

        public static implicit operator double[](LinearEquation le)
        {
            return le.coefficients;
        }
        public LinearEquation(string str)
        {
            string[] strArr = str.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (strArr.Length == 0)
                coefficients = new double[] { 0, 0 };
            else if (strArr.Length == 1)
                try
                {
                    coefficients = new double[] { Convert.ToDouble(strArr[0]), 0 };
                }
                catch
                {
                    throw new ArgumentException();
                }
            else
            {
                coefficients = new double[strArr.Length];
                try
                {
                    for(int i=0; i< strArr.Length; i++)
                    {
                        coefficients[i] = Convert.ToDouble(strArr[i]);
                    }
                }
                catch
                {
                    throw new ArgumentException();
                }
            }
        }

        public LinearEquation(IList<double> list)
        {
            if (list.Count == 0)
            {
                coefficients = new double[] { 0, 0 };
            }
            else if (list.Count == 1)
            {
                coefficients = new double[] { list[0], 0 };
            }
            else
            {
                coefficients = new double[list.Count];
                for (int i = 0; i < list.Count; i++)
                    coefficients[i] = list[i];
            }
        }
        public LinearEquation(int n)
        {
            if (n >= 2)
                coefficients = new double[n];
            else if (n >= 0)
                coefficients = new double[2];
            else
                throw new ArgumentException();
        }
        public LinearEquation(LinearEquation le)
        {
            coefficients = le.coefficients;
        }

    }
}
