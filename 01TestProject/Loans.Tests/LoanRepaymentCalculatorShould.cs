﻿using Loans.Domain.Applications;
using NUnit.Framework;
using System;

namespace Loans.Tests
{
    public class LoanRepaymentCalculatorShould
    {
        [Test]
        [TestCase(200_000, 6.5, 30, 1264.14)]
        [TestCase(200_000, 10, 30, 1755.14)]
        [TestCase(500_000, 10, 30, 4387.86)]
        public void CalculateCorrectMonthlyRepayment(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears,
                                                     decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        /// <summary>
        /// Below test is just betterment formation of above with "ExpectedResult"
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="interestRate"></param>
        /// <param name="termInYears"></param>
        /// <returns></returns>
        [Test]
        [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
        [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
        [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
        public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));

            //Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        /// <summary>
        /// Get test data from centralised class.
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="interestRate"></param>
        /// <param name="termInYears"></param>
        /// <param name="expectedMonthlyPayment"></param>
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public void CalculateCorrectMonthlyRepayment_Centralised(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears,
                                                     decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }

        /// <summary>
        /// Below test is just betterment formation of above with "CentralizeWithReturn"
        /// It have Return and only 3 parameters, not the result parameter.
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="interestRate"></param>
        /// <param name="termInYears"></param>
        /// <returns></returns>
        [Test]
        [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
        public decimal CalculateCorrectMonthlyRepayment_CentralizeWithReturn(decimal principal,
                                                     decimal interestRate,
                                                     int termInYears)
        {
            var sut = new LoanRepaymentCalculator();

            return sut.CalculateMonthlyRepayment(
                                     new LoanAmount("USD", principal),
                                     interestRate,
                                     new LoanTerm(termInYears));

            //Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
    }
}