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

        }
        public LinearEquation(int n)
        {

        }
        public LinearEquation(LinearEquation le)
        {

        }

    }
}
