namespace ProgressionLib
{
    abstract class Pr
    {
        public abstract double[] returnMass(int finish);

        public abstract double[] returnMass(int start, int finish);

    }

    class ArifmeticPr : Pr  //by Sokol_Lonely
    {
        private double a1;
        private double d;
        public ArifmeticPr(double a1, double d)
        {
            this.a1 = a1;
            this.d = d;
        }
        public double A1
        {
            get { return a1; }
            set { a1 = value; }
        }
        public double D
        {
            get { return d; }
            set { if (value != 0) d = value; }
        }
        public double this[int n]
        {
            get { return a1 + d * (n - 1); }
        }
        public double sum(int n)// sum of elements from first element to finish
        {
            return n * (2 * a1 + d * (n - 1)) / 2;
        }
        public double sum(int start, int finish) // sum of elements from start to finish (включительно)
        {
            return (this[start] + this[finish]) / 2 * (finish - start + 1);
        }
        public bool isInPr(double a)
        {
            if ((a - d) % a1 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override double[] returnMass(int finish)///
        {
            int start = 1;
            double[] ans = new double[finish];
            for (int i = start; i <= finish; i++)
            {
                ans[i - 1] = this[i];
            }
            return ans;
        }
        public override double[] returnMass(int start, int finish)///
        {
            double[] ans = new double[finish - start + 1];
            for (int i = start; i <= finish; i++)
            {
                ans[i - start] = this[i];
            }
            return ans;
        }

    }//by Sokol_Lonely
    class GeometricPr : Pr
    {
        private double a1;
        private double q;
        public GeometricPr(double a1, double q)
        {
            this.a1 = a1;
            this.q = q;
        }
        public double A1
        {
            get { return a1; }
            set { a1 = value; }
        }
        public double Q
        {
            get { return q; }
            set { if (value != 0) q = value; }
        }
        public double this[int n]
        {
            get { return a1 * Math.Pow(q, n - 1); }
        }
        public double sum(int n)// sum of elements from first element to finish
        {
            if (q == 1)
                return n * a1;
            else
                return a1 * (1 - Math.Pow(q, n)) / (1 - q);
        }
        public double sum(int start, int finish) // sum of elements from start to finish (including finish)
        {
            if (q == 1)
                return (finish - start + 1) * a1;
            else
                return a1 * (1 - Math.Pow(q, finish - start + 1)) / (1 - q);
        }
        public bool isInPr(double num)
        {
            double n = Math.Log(num / a1, q);
            return Math.Abs(n % 1) < double.Epsilon;
        }
        public override double[] returnMass(int finish)///
        {
            int start = 1;
            double[] ans = new double[finish];
            for (int i = start; i <= finish; i++)
            {
                ans[i - 1] = this[i];
            }
            return ans;
        }
        public override double[] returnMass(int start, int finish)///
        {
            double[] ans = new double[finish - start + 1];
            for (int i = start; i <= finish; i++)
            {
                ans[i - start] = this[i];
            }//by Sokol_Lonely
            return ans;
        }
    }
}
