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
        public void FillByDuplicates( double value)
        {
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = value;
            }
        }
        public void FillByRandomValues(double min, double max)
        {
            if (max >= min)
            {
                Random rand = new Random();
                for (int i = 0; i < coefficients.Length; i++)
                    coefficients[i] = rand.NextDouble() * (max - min) + min;
            }
            else throw new ArgumentException();
        }
        public void FillByRandomValues(double min, double max, int seed)
        {
            if (max >= min)
            {
                Random rand = new Random(seed);
                for (int i = 0; i < coefficients.Length; i++)
                    coefficients[i] = rand.NextDouble() * (max - min) + min;
            }
            else throw new ArgumentException();
        }
        public static LinearEquation operator +(LinearEquation a, LinearEquation b)
        {
            int resLength = a.coefficients.Length>=b.coefficients.Length?a.coefficients.Length:b.coefficients.Length;
            List<double> res = new List<double>();
            for (int i = 0; i < resLength; i++)
            {
                res.Add(
                    (i < a.coefficients.Length ? a.coefficients[i] : 0) + 
                    (i < b.coefficients.Length ? b.coefficients[i] : 0));
            }
            return new LinearEquation(res);
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            int resLength = a.coefficients.Length >= b.coefficients.Length ? a.coefficients.Length : b.coefficients.Length;
            List<double> res = new List<double>();
            for (int i = 0; i < resLength; i++)
            {
                res.Add(
                    (i < a.coefficients.Length ? a.coefficients[i] : 0) - 
                    (i < b.coefficients.Length ? b.coefficients[i] : 0));
            }
            return new LinearEquation(res);
        }
        public static LinearEquation operator *(LinearEquation a, double r)
        {
            LinearEquation res = new LinearEquation(a);
            for (int i = 0; i < res.coefficients.Length; i++)
            {
                res.coefficients[i] *= r;
            }
            return res;
        }
        public static LinearEquation operator *(double r, LinearEquation a)
        {
            return a * r;
        }
        public static LinearEquation operator -(LinearEquation a)
        {
            LinearEquation res = new LinearEquation(a);
            for (int i = 0; i < res.coefficients.Length; i++)
            {
                res.coefficients[i] *= -1;
            }
            return res;
        }

        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            int maxLength = a.coefficients.Length >= b.coefficients.Length ? a.coefficients.Length : b.coefficients.Length;
            for (int i = 0; i < maxLength; i++)
            {
                if (
                    (i < a.coefficients.Length ? a.coefficients[i] : 0) !=
                    (i < b.coefficients.Length ? b.coefficients[i] : 0))
                    return false;
            }
            return true;
        }
        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            return !(a == b);
        }
        public static bool operator false(LinearEquation a)
        {
            return a ? false : true;
        }
        public static bool operator true(LinearEquation a)
        {
            if (a.coefficients[0] == 0)
            {
                return true;
            }
            for (int i = 1; i < a.coefficients.Length; i++)
            {
                if (a.coefficients[i] != 0)
                {
                    return true;
                }
            }
            return false;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                if (coefficients[i] != 0)
                {
                    if (res != "" && coefficients[i] > 0)
                    {
                        res += "+";
                    }
                    res += "" + coefficients[i];
                    if (i != 0)
                    {
                        res += "x" + i;
                    }
                }
            }
            if (res == "")
            {
                res += "0";
            }
            res += "=0";
            return res;
        }
        public int Degree
        {
            get
            {
                int degree = 0;
                for (int i = 0; i < coefficients.Length; i++)
                {
                    if (coefficients[i] != 0)
                    {
                        degree = i;//x's index of the far left non zero coefficient(in ToString)
                    }
                }
                return degree;
            }
        }
        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Degree)
                    throw new ArgumentOutOfRangeException();
                return coefficients[index];
            }
        }
    }
}
