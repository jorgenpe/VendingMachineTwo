using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Tests.Model
{
    public class CandyTests
    {

        [Fact]
        public void CandyNewTest()
        {
            Candy product = new Candy(1);
            int expected = 1;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.Id);
            Assert.Equal(expected, product.Id);
        }

        [Fact]
        public void CandyGetSetTest()
        {
            Candy product = new Candy(1);
            
            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.CandyType = "testType";
            product.CandyDescription = "candyDeescription two";

            int expected = 2;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.PriceOfProduct);
            Assert.Equal(expected, product.PriceOfProduct);
            Assert.NotNull(product.ProductName);
            Assert.NotNull(product.CandyType);
            Assert.NotNull(product.CandyDescription);
            Assert.Equal("testName", product.ProductName);
            Assert.Equal("testType", product.CandyType);
            Assert.Equal("candyDeescription two", product.CandyDescription);
        }

        [Fact]
        public void CandyExamineUseTest()
        {
            Candy product = new Candy(1);
            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.CandyType = "testType";
            product.CandyDescription = "candyDeescription two";

            string expected = "Open the rapper and eat your candy";
            string expectedTwo = "1: price: 2: testName: testType: candyDeescription two";

            Assert.NotNull( product.Examine());
            Assert.Equal(expectedTwo, product.Examine());
            Assert.NotNull(product.Examine());
            Assert.Equal(expected, product.Use());
        }
    }
}
