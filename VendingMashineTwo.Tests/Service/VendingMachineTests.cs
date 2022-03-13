using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VendingMachine.Model;
using VendingMachine.Service;
namespace VendingMashineTwo.Tests.Service
{
    
    public class VendingMachineTests
    {
        [Fact]
        public void pururchaseTest()
        {
            
            IVending vendingMachineService = new VendingMachineService();

            int expected = 3;

            Assert.Null(vendingMachineService.Purchase(3));
            vendingMachineService.InsertMoney(20);
            vendingMachineService.InsertMoney(5);

            Product result = vendingMachineService.Purchase(3);
            Assert.NotNull(result);
            Assert.Equal(expected, result.Id);
        }

        [Fact]
        public void ShowAllTest()
        {
            IVending vendingMachineService = new VendingMachineService();
            string expected = "4: DrinkOne 10";
            List<string> result = vendingMachineService.ShowAll();
            Assert.NotNull(result);
            Assert.Equal(expected, result[3]);
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void DetailsTest()
        {
            IVending vendingMachineService = new VendingMachineService();
            string expected = "2: price: 10: DrinkOne: Cola: Can: DescriptionOne Drink";
            string expectedTwo = "4: price: 10: DrinkOne: Cola: Can: DescriptionOne Drink";
            String result = vendingMachineService.Details(2);
            Assert.NotNull(result);
            Assert.Equal(expected, result);
            Assert.NotEqual(expectedTwo, result);

        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(5,5)]
        [InlineData(10,10)]
        [InlineData(20,20)]
        [InlineData(50,50)]
        [InlineData(100,100)]
        [InlineData(200,200)]
        [InlineData(500,500)]
        [InlineData(1000,1000)]
        public void InsertMoneyTest(int money, int expected)
        {
            IVending vendingMachineService = new VendingMachineService();
            int result = vendingMachineService.InsertMoney(money);
            Assert.Equal(expected, result);
            
        }


        [Fact]
       
        public void InsertMoneyTestTwo()
        {
            IVending vendingMachineService = new VendingMachineService();
            string expected = " Your money are not of the right currency";

            var result = Assert.Throws<ArgumentException>(() => vendingMachineService.InsertMoney(2));
            Assert.Equal(expected, result.Message);

        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(5,0)]
        [InlineData(10,0)]
        [InlineData(20, 0)]
        [InlineData(50,1)]
        [InlineData(100,0)]
        [InlineData(200,2)]
        [InlineData(500,1)]
        [InlineData(1000,2)]
        public void EndTransaction(int index, int expected)
        {
            IVending vendingMachineService = new VendingMachineService();
            vendingMachineService.Clear();
            vendingMachineService.InsertMoney(1);
            vendingMachineService.InsertMoney(50);
            vendingMachineService.InsertMoney(100);
            vendingMachineService.InsertMoney(100);
            vendingMachineService.InsertMoney(200);
            vendingMachineService.InsertMoney(500);
            vendingMachineService.InsertMoney(1000);
            vendingMachineService.InsertMoney(1000);

            Dictionary<int,int> result = vendingMachineService.EndTransaction();
            Assert.NotNull(result);
            Assert.Equal(expected, result[index]);
            

        }
    }
}
