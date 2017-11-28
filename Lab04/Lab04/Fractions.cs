using System;

namespace Lab04
{
    public class Fraction
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int num)
        {
            Numerator = num;
            Denominator = 1;
        }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero");
            if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else if (Math.Abs(numerator) == Math.Abs(denominator))
            {
                Numerator = numerator / denominator;
                Denominator = 1;
            }
            else
            {
                Normalize(ref numerator, ref denominator);
                Numerator = numerator;
                Denominator = denominator;
            }
        }

        private void Normalize(ref int numerator, ref int denominator)
        {
            for (int i = 2; i <= Math.Abs(numerator) && i <= Math.Abs(denominator); i++)
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator = numerator / i;
                    denominator = denominator / i;
                    i--;
                }
            if (denominator < 0)
            {
                denominator = -denominator;
                numerator = -numerator;
            }
        }

        public static int ExplicitConversion(Fraction f)
        {
            if (f.Denominator != 1)
                throw new ExplicitConversionException("Could not perform implicit convertion");
            return f.Numerator;
        }

        public static Fraction ImplicitConversion(int n)
        {
            return new Fraction(n);
        }

        private int McmRic(int a, int b, int c)
        {
            if (b == 0)
                return c / a;
            return McmRic(b, a % b, c);
        }

        private int Mcm(int a, int b)
        {
            return McmRic(a, b, a * b);
        }

        public Fraction SumFraction(Fraction f)
        {
            if (f == null)
                throw new NullReferenceException();
            if (f.Denominator == Denominator)
                return new Fraction(Numerator + f.Numerator, Denominator);
            int mcm = Mcm(Denominator, f.Denominator);
            return new Fraction(mcm / Denominator * Numerator + mcm / f.Denominator * f.Numerator, mcm);
        }

        public Fraction SumFraction(int n)
        {
            return SumFraction(new Fraction(n));
        }

        public Fraction SubFraction(Fraction f)
        {
            if (f == null)
                throw new NullReferenceException();
            if (f.Denominator == Denominator)
                return new Fraction(Numerator - f.Numerator, Denominator);
            int mcm = Mcm(Denominator, f.Denominator);
            return new Fraction((mcm / Denominator * Numerator) - (mcm / f.Denominator * f.Numerator), mcm);
        }

        public Fraction SubFraction(int n)
        {
            return SubFraction(new Fraction(n));
        }

        public Fraction MulFraction(Fraction f)
        {
            return new Fraction(Numerator * f.Numerator, Denominator * f.Denominator);
        }

        public Fraction MulFraction(int n)
        {
            return MulFraction(new Fraction(n));
        }

        public Fraction DivideFraction(Fraction f)
        {
            if (f.Numerator == 0)
                throw new DivideByZeroException("Denominator cannot be zero");
            return MulFraction(new Fraction(f.Denominator, f.Numerator));
        }

        public Fraction DivideFraction(int n)
        {
            return DivideFraction(new Fraction(n));
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj is null)
                return false;
            if (obj is int)
            {
                int convertedFraction = (int)obj;
                return Numerator == convertedFraction && Denominator == 1;
            }
            if (!(obj is Fraction))
                return false;
            Fraction argObj = (Fraction)obj;
            return Numerator == argObj.Numerator && Denominator == argObj.Denominator;
        }

        public override int GetHashCode()
        {
            return 17 * (Numerator + Denominator);
        }

        public override String ToString()
        {
            return Denominator == 1 ? Numerator.ToString() : Numerator + "/" + Denominator;
        }
    }

    public class ImplicitConversionException : Exception
    {
        public ImplicitConversionException(string message) : base(message) { }
    }

    public class ExplicitConversionException : Exception
    {
        public ExplicitConversionException(string message) : base(message) { }
    }
}
