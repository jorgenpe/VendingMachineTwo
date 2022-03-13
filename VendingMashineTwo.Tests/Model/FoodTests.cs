using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;

namespace VendingMachine.Tests.Model
{
    public class FoodTests
    {

        [Fact]
        public void FoodNewTest()
        {
            Food product = new Food(1);
            int expected = 1;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.Id);
            Assert.Equal(expected, product.Id);
        }

        [Fact]
        public void FoodGetSetTest()
        {
            Food product = new Food(1);

            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.FoodType = "testType";
            product.FoodDescription = "foodDeescription two";

            int expected = 2;
            int notExpected = 0;

            Assert.NotEqual(notExpected, product.PriceOfProduct);
            Assert.Equal(expected, product.PriceOfProduct);
            Assert.NotNull(product.ProductName);
            Assert.NotNull(product.FoodType);
            Assert.NotNull(product.FoodDescription);
            Assert.Equal("testName", product.ProductName);
            Assert.Equal("testType", product.FoodType);
            Assert.Equal("foodDeescription two", product.FoodDescription);
        }

        [Fact]
        public void FoodExamineUseTest()
        {
            Food product = new Food(1);
            product.PriceOfProduct = 2;
            product.ProductName = "testName";
            product.FoodType = "Salad";
            product.FoodDescription = "foodDescription two";

            string expected = " Unrapp the sandwich and eat it";
            string expectedOne = " Remove the lid and take the fork and knife and start to eat.";
            string expectedTwo = "1: price: 2: testName: Sandwich: foodDescription two ";

            Assert.Equal(expectedOne, product.Use());

            product.FoodType= "Sandwich";

            Assert.NotNull(product.Examine());
            Assert.Equal(expectedTwo, product.Examine());
            Assert.NotNull(product.Examine());
            Assert.Equal(expected, product.Use());
        }
    }
}
