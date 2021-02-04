using System;
using System.Linq;

namespace Task2_cs
{
    public class SystemOfLinearEquation
    {
        LinearEquation[] equations;

        public SystemOfLinearEquation(int m)
        {
            if (m <= 0)
            {
                throw new ArgumentException();
            }
            equations = new LinearEquation[m];
            for (int i = 0; i < m; i++)
            {
                equations[i] = new LinearEquation(2);
            }
        }

        public LinearEquation this[int i]
        {
            get
            {
                if (i < 0 || i >= equations.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return equations[i];
            }
            set
            {
                if (i < 0 || i >= equations.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                equations[i] = new LinearEquation(value);
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < equations.Length; i++)
            {
                result += equations[i] + "\n";
            }
            return result;
        }

        public void ToTriangular()
        {
            Array.Sort(equations, (x, y) => (-1 * x.Degree.CompareTo(y.Degree)));
            int maxDegree = equations[0].Degree,
                degreeLimit = Math.Max(maxDegree - equations.Length + 1, 1),
                numberOfEquation = 0;
            for (int d = maxDegree; d >= degreeLimit; d--)
            {
                if (equations[numberOfEquation].Degree < d)
                {
                    continue;
                }
                for (int i = numberOfEquation + 1; i < equations.Length; i++)
                {
                    if (equations[i].Degree >= d)
                    {
                        equations[i] = equations[i] - equations[numberOfEquation] * (equations[i][d] / equations[numberOfEquation][d]);
                    }
                }
                Array.Sort(equations, (x, y) => (-1 * x.Degree.CompareTo(y.Degree)));
                numberOfEquation += 1;
            }
        }

        public double[] Solve()
        {
            SystemOfLinearEquation sle = new SystemOfLinearEquation(equations.Length);
            for (int i = 0; i < sle.equations.Length; i++)
            {
                sle.equations[i] = new LinearEquation(equations[i]);
            }
            sle.ToTriangular();
            for (int i = 0; i < sle.equations.Length; i++)
            {
                if (sle.equations[i])
                {
                    continue;
                }
                else
                {
                    throw new ArithmeticException();
                }
            }
            double[] result = new double[sle.equations[0].Degree];
            result = Enumerable.Repeat(double.PositiveInfinity, result.Length).ToArray();
            for (int i = sle.equations.Length - 1; i >= 0; i--)
            {
                if (sle.equations[i].Degree == 0 || !double.IsInfinity(result[sle.equations[i].Degree - 1]))
                {
                    continue;
                }
                result[sle.equations[i].Degree - 1] = -sle.equations[i][0];
                for (int j = sle.equations[i].Degree - 1; j >= 1; j--)
                {
                    if (!double.IsInfinity(result[j - 1]))
                    {
                        result[sle.equations[i].Degree - 1] -= sle.equations[i][j] * result[j - 1];
                    }
                    else
                    {
                        result[sle.equations[i].Degree - 1] = double.PositiveInfinity;
                        break;
                    }
                }
                result[sle.equations[i].Degree - 1] /= sle.equations[i][sle.equations[i].Degree];
            }
            return result;
        }
    }
}
