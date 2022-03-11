using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Tests.Model
{
    public class DrinkTests
    {

        [Fact]
        public void DrinkNewTest()
        {
            Drink product = new Drink(1);
            int expected = 1;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.Id);
            Assert.Equal(expected, product.Id);
        }

        [Fact]
        public void DrinkGetSetTest()
        {
            Drink product = new Drink(1);

            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.BeverageType = "testType";
            product.PackageType = "Bottle";
            product.BeverageDescription = "candyDeescription two";

            int expected = 2;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.PriceOfProduct);
            Assert.Equal(expected, product.PriceOfProduct);
            Assert.NotNull(product.ProductName);
            Assert.NotNull(product.BeverageType);
            Assert.NotNull(product.PackageType);
            Assert.NotNull(product.BeverageDescription);
            Assert.Equal("testName", product.ProductName);
            Assert.Equal("testType", product.BeverageType);
            Assert.Equal("Bottle", product.PackageType);
            Assert.Equal("candyDeescription two", product.BeverageDescription);
        }

        [Fact]
        public void DrinkExamineUseTest()
        {
            Drink product = new Drink(1);
            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.BeverageType = "testType";
            product.PackageType = "can";
            product.BeverageDescription = "candyDeescription two";

            string expected = " Open the cap and you can now drink from the bottle.";
            string expectedOne = " Bend the opener to uprigth posion and then bend it back to original posion. You can now drink from the can.";
            string expectedTwo = "testType: Bottle: candyDeescription two";

            Assert.Equal(expectedOne, product.Use());

            product.PackageType = "Bottle";

            Assert.NotNull(product.Examine());
            Assert.Equal(expectedTwo, product.Examine());
            Assert.NotNull(product.Examine());
            Assert.Equal(expected, product.Use());

        }
    }
}