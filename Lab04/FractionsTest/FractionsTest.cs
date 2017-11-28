using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Lab04;

namespace FractionsTest
{
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void Constructor_simpleInt32()
        {
            Fraction fraction = new Fraction(-4);
            Assert.That(fraction.Numerator, Is.EqualTo(-4));
        }

        [TestMethod]
        public void Constructor_simpleInt32_Zerp()
        {
            Fraction fraction = new Fraction(0);
            Assert.That(fraction.Numerator, Is.EqualTo(0));
        }

        [TestMethod]
        public void Constructor_SuccessNumeratorCoprimePositive()
        {
            Fraction fraction = new Fraction(3, 5);
            Assert.That(fraction.Numerator, Is.EqualTo(3));
        }

        [TestMethod]
        public void Constructor_SuccessDenominatorCoprimePositive()
        {
            Fraction fraction = new Fraction(3, 5);
            Assert.That(fraction.Denominator, Is.EqualTo(5));
        }
        [TestMethod]
        public void Constructor_SuccessNumeratorCoprimeNegative()
        {
            Fraction fraction = new Fraction(3, -5);
            Assert.That(fraction.Numerator, Is.EqualTo(-3));
        }

        [TestMethod]
        public void Constructor_SuccessDenominatorCoprimeNegative()
        {
            Fraction fraction = new Fraction(3, -5);
            Assert.That(fraction.Denominator, Is.EqualTo(5));
        }

        [TestMethod]
        public void Constructor_SuccessNumeratorCoprimeNegative_2()
        {
            Fraction fraction = new Fraction(-3, 5);
            Assert.That(fraction.Numerator, Is.EqualTo(-3));
        }

        [TestMethod]
        public void Constructor_SuccessDenominatorCoprimeNegative_2()
        {
            Fraction fraction = new Fraction(-3, 5);
            Assert.That(fraction.Denominator, Is.EqualTo(5));
        }

        [TestMethod]
        public void Constructor_SuccessNumeratorCoprimeBothNegative()
        {
            Fraction fraction = new Fraction(-3, -5);
            Assert.That(fraction.Numerator, Is.EqualTo(3));
        }

        [TestMethod]
        public void Constructor_SuccessDenominatorCoprimeBothNegative()
        {
            Fraction fraction = new Fraction(-3, -5);
            Assert.That(fraction.Denominator, Is.EqualTo(5));
        }

        [TestMethod]
        public void Constructor_SuccessNumeratorSemplification()
        {
            Fraction fraction = new Fraction(30, 42);
            Assert.That(fraction.Numerator, Is.EqualTo(5));
        }
        [TestMethod]
        public void Constructor_SuccessDenominatorSemplification()
        {
            Fraction fraction = new Fraction(30, 42);
            Assert.That(fraction.Denominator, Is.EqualTo(7));
        }
        [TestMethod]
        public void Constructor_SuccessNumeratorSemplificationMinusNum()
        {
            Fraction fraction = new Fraction(-30, 42);
            Assert.That(fraction.Numerator, Is.EqualTo(-5));
        }
        [TestMethod]
        public void Constructor_SuccessDenominatorSemplificationMinusNum()
        {
            Fraction fraction = new Fraction(-30, 42);
            Assert.That(fraction.Denominator, Is.EqualTo(7));
        }
        [TestMethod]
        public void Constructor_SuccessNumeratorSemplificationMinusDen()
        {
            Fraction fraction = new Fraction(30, -42);
            Assert.That(fraction.Numerator, Is.EqualTo(-5));
        }
        [TestMethod]
        public void Constructor_SuccessDenominatorSemplificationMinusDen()
        {
            Fraction fraction = new Fraction(30, -42);
            Assert.That(fraction.Denominator, Is.EqualTo(7));
        }
        [TestMethod]
        public void Constructor_SuccessNumeratorSemplificationMinusBotNegative()
        {
            Fraction fraction = new Fraction(-30, -42);
            Assert.That(fraction.Numerator, Is.EqualTo(5));
        }
        [TestMethod]
        public void Constructor_SuccessDenominatorSemplificationMinusBothNegative()
        {
            Fraction fraction = new Fraction(-30, -42);
            Assert.That(fraction.Denominator, Is.EqualTo(7));
        }
        [TestMethod]
        public void Constructor_ExceptionOnZero()
        {
            Assert.That(() => new Fraction(5, 0), Throws.TypeOf<ArgumentException>());
        }

        [TestMethod]
        public void SumFractions_Sum_Positive_DifferentDenominators()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(1, 2);
            Fraction result = new Fraction(7, 6);
            Assert.That(f1.SumFraction(f2), Is.EqualTo(result));
        }
        [TestMethod]
        public void SumFractions_Sum_Positive_SimilarDenominators()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(5, 3);
            Fraction result = new Fraction(2, 1);
            Assert.That(f1.SumFraction(f2), Is.EqualTo(result));
        }
        [TestMethod]
        public void SumFractions_Sum_Negative_DifferentDenominators()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(-1, 2);
            Fraction result = new Fraction(1, 6);
            Assert.That(f1.SumFraction(f2), Is.EqualTo(result));
        }
        [TestMethod]
        public void SumFractions_Sum_Negative_SimilarDenominators()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(-4, 3);
            Fraction result = new Fraction(-2, 3);
            Assert.That(f1.SumFraction(f2), Is.EqualTo(result));
        }
        [TestMethod]
        public void SubFractions_Sum_Positive_DifferentDenominators()
        {
            Fraction f1 = new Fraction(33, 7);
            Fraction f2 = new Fraction(4, 1);
            Fraction result = new Fraction(-5, 7);
            Assert.That(f2.SubFraction(f1), Is.EqualTo(result));
        }

        [TestMethod]
        public void MulFraction_Zero_Returns_Zero()
        {
            Fraction f1 = new Fraction(42);
            int zero = 0;
            Fraction zeroFract = new Fraction(0);
            Assert.That(f1.MulFraction(zero), Is.EqualTo(zeroFract));
        }

        [TestMethod]
        public void MulFraction_PositiveIntegerMul()
        {
            Fraction f1 = new Fraction(2);
            Fraction f2 = new Fraction(3);
            Fraction result = new Fraction(6);
            Assert.That(f1.MulFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void MulFraction_GenericPositiveFraction()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction result = new Fraction(2, 9);
            Assert.That(f1.MulFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void MulFraction_GenericPositiveFractionSimplify()
        {
            Fraction f1 = new Fraction(1, 3);
            Fraction f2 = new Fraction(3, 2);
            Fraction result = new Fraction(1, 2);
            Assert.That(f1.MulFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void MulFraction_GenericPositiveFractionMulIntegerSimplify()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(6);
            Fraction result = new Fraction(4);
            Assert.That(f1.MulFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void DivFraction_GenericDivisionProducesOne()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(2, 3);
            Fraction result = new Fraction(1);
            Assert.That(f1.DivideFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void DivFraction_GenericDivisionSimplify()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(1, 3);
            Fraction result = new Fraction(2);
            Assert.That(f1.DivideFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void DivFraction_GenericDivisionNoSimplify()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(1, 7);
            Fraction result = new Fraction(14, 3);
            Assert.That(f1.DivideFraction(f2), Is.EqualTo(result));
        }

        [TestMethod]
        public void DivFraction_DivideByZeroException()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(0);
            Assert.That(() => f1.DivideFraction(f2), Throws.TypeOf<DivideByZeroException>());
        }

        [TestMethod]
        public void Fractions_Are_Equal_To_Zero()
        {
            Fraction f1 = new Fraction(0, 1);
            Fraction f2 = new Fraction(0, 22);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [TestMethod]
        public void Fractions_Are_Equal_Each_Other()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 4);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [TestMethod]
        public void ToString_Equality_Test()
        {
            Fraction f1 = new Fraction(11, 5);
            Assert.That(f1.ToString(), Is.EqualTo("11/5"));
        }

        [TestMethod]
        public void ToString_Equality_Explicit_Conversion_Test()
        {
            Fraction f1 = new Fraction(22, 11);
            Assert.That(f1.ToString(), Is.EqualTo("2"));
        }

        [TestMethod]
        public void ToString_Equality_Explicit_Conversion_Negative_Test()
        {
            Fraction f1 = new Fraction(22, -11);
            Assert.That(f1.ToString(), Is.EqualTo("-2"));
        }

        [TestMethod]
        public void Explicit_Conversion_Success()
        {
            Fraction f1 = new Fraction(42, 1);
            Assert.That(Fraction.ExplicitConversion(f1), Is.EqualTo(42));
        }

        [TestMethod]
        public void Explicit_Conversion_Fail()
        {
            Fraction f1 = new Fraction(42, 11);
            Assert.That(() => Fraction.ExplicitConversion(f1), Throws.TypeOf<ExplicitConversionException>());
        }

        [TestMethod]
        public void Implicit_Conversion_Success()
        {
            int n = 42;
            Fraction returnValue = new Fraction(42);
            Assert.That(Fraction.ImplicitConversion(n), Is.EqualTo(returnValue));
        }

        [TestMethod]
        public void Implicit_Conversion_Success_2()
        {
            int n = 0;
            Fraction returnValue = new Fraction(0, 1);
            Assert.That(Fraction.ImplicitConversion(n), Is.EqualTo(returnValue));
        }
    }
}
