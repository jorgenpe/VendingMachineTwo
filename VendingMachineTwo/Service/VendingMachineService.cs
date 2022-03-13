using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public class VendingMachineService : IVending
    {
        private static readonly Product[] products = {  new Candy(1, 15, "CandyOne", "Chocolate", "DescriptionOne Candy"), new Drink(2, 10, "DrinkOne", "Cola", "Can", "DescriptionOne Drink"),
                                       new Food(3, 25, "FoodOne", "Sandwich", "DescriptionOne Food"),new Drink(4, 10, "DrinkOne", "Applejuice", "Bottle", "DescriptionTwo Drink"),
                                       new Food(5, 25, "FoodTwo", "Sandwich", "DescriptionTwo Food") };
        protected static readonly int[] currencyOptions = { 1, 5, 10, 20, 50, 100, 200, 500, 1000 };
        private int moneyInserted = 0;

        public Product Purchase(int id)
        {

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Id == id && products[i].PriceOfProduct <= moneyInserted)
                {
                    return products[i];
                }

            }

            return null;
        }


        public List<string> ShowAll()
        {

            List<string> list = new List<string>();
            foreach (Product product in products)
            {
                list.Add($"{product.Id}: {product.ProductName} {product.PriceOfProduct}");
            }

            return list;
        }

        public string Details(int id)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].Id == id)
                {
                    return $"{products[i].Examine()}";
                }
            }

            return null;
        }


        public int InsertMoney(int money)
        {
            for (int i = 0; i < currencyOptions.Length; i++)
            {
                if (currencyOptions[i] == money)
                {
                    moneyInserted = moneyInserted + money;
                    return money;
                }      
                
            }
            throw new ArgumentException(" Your money are not of the right currency");

        }


        public Dictionary<int, int> EndTransaction()
        {

            Dictionary<int, int> result = new Dictionary<int, int>();

            int modelus;
            int rest;
            for (int i = 8; i >= 0; i--)
            {
                if (moneyInserted > 0)
                {
                    modelus = currencyOptions[i];
                    rest = moneyInserted % modelus;
                    moneyInserted = moneyInserted - rest;
                    try
                    {
                        result.Add(currencyOptions[i], moneyInserted / currencyOptions[i]);
                    }catch (ArgumentException)
                    {
                        throw new Exception($"An element with key = {currencyOptions[i]} already exists ") ;
                    }
                    
                    moneyInserted = rest;
                }


            }
            return result;
        }

        public void Clear()
        {
            moneyInserted = 0;
        }
    }
}