using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
    [TestFixture]
    public class ProductComparerShould
    {
        private List<LoanProduct> products;
        private ProductComparer sut;

        [OneTimeSetUp]
        public void OneTimeSetup() //Execute only one time before the first test.
        {
            products = new List<LoanProduct>
            {
                new LoanProduct(1,"a",1),
                new LoanProduct(2,"b",2),
                new LoanProduct(3,"c",3)
            };
        }

        [SetUp]
        public void SetUp() //run before each test
        {
             sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
        }

        [TearDown] //run after each test
        public void TearDown()
        {

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()// run after last test executed.
        {

        }

        [Test]
        [Category("Product Comparison")]
        public void ReturnCorrectnumberOfComparision()
        {   

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            Assert.That(comparisons, Has.Exactly(3).Items);

            Assert.That(comparisons, Is.Unique);

            var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);

            //Test if expected product is there.
            Assert.That(comparisons, Does.Contain(expectedProduct));
        }

        [Test]
        public void ReturnComparisionForFirstProduct_WithPartialKnownExpectedValues()
        {

            List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));

            //Check Property
            Assert.That(comparisons, Has.Exactly(1)
                .Property("ProductName").EqualTo("a")
                .And
                .Property("MonthlyRepayment").GreaterThan(0));

            //Check property by lambda expression
            Assert.That(comparisons, Has.Exactly(1)
                .Matches<MonthlyRepaymentComparison>(
                item => item.ProductName == "a" &&
                item.InterestRate == 1 &&
                item.MonthlyRepayment > 0));
        }
    }
}
 