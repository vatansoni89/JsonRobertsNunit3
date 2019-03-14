using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    [TestFixture] //This class is atest class and contains Test methods.
    public class LoanTermShould
    {  
        [Test] //make a method as test.
        public void ReturnTermInMonths()
        {
            var sut = new LoanTerm(1); // sut = system under test

            Assert.That(sut.ToMonths(), Is.EqualTo(12));
        }

        [Test] //make a method as test.
        public void ReturnTermInYear()
        {
            var sut = new LoanTerm(1); // sut = system under test

            Assert.That(sut.Years, Is.EqualTo(1));
        }
        [Test]
        public void RespectValueEqality()
        {
            var a = 1;
            var b = 1;

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RespectValueEqality1() // Its passing bcz of override Equals in ValueObject
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test] // Test if object are at same memory location.
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);

            Assert.That(a, Is.SameAs(b));
            //Assert.That(a, Is.SameAs(c));  Fails
            Assert.That(a, Is.Not.SameAs(c));
        }

        [Test]
        public void Double()
        {
            double a = 1.0 / 3;

            var tt = Is.EqualTo(0.33).Within(0.004);
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));

            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

        //Exception test
        [Test]
        public void NotAllowedZeroYears()
        {
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());

            //Checks the meaage thrown as expected or not.
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Property("Message").EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));

            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Message.EqualTo("Please specify a value greater than 0.\r\nParameter name: years"));

            //Jst care for ParamName
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With.Property("ParamName").EqualTo("years"));

            //Jst care for ParamName using Lambda
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With
                .Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "years"));
        }
    }
}
