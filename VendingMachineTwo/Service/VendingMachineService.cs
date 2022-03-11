using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public class VendingMachineService
    {
        private Product[] products = new Product[10];
        protected static readonly int[] currencyOptions = { 1, 5, 10, 20, 50, 100, 200, 500, 1000 };
        private int moneyInserted = 0;

        Product Purchase(int id)
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


        List<string> ShowAll()
        {

            List<string> list = new List<string>();
            foreach (Product product in products)
            {
                list.Append($"{product.Id}: {product.ProductName}  {product.PriceOfProduct}");
            }

            return list;
        }

        string Details(int id)
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


        void InsertMoney(int money)
        {
            for (int i = 0; i < currencyOptions.Length; i++)
            {
                if (currencyOptions[i] == money)
                {
                    moneyInserted = money;
                }
                else
                {
                    throw new ArgumentException(" Your money are not of the right currency");
                }
            }

        }


        Dictionary<int, int> EndTransactin()
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
                    result.Add(currencyOptions[i], moneyInserted / currencyOptions[i]);
                    moneyInserted = rest;
                }


            }



            return null;
        }

        public Product CreateFood(int id, int price, string name, string foodType, string foodDescription)
        {
            Food product = new Food(id, price, name, foodType, foodDescription);
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = product;
                    return product;
                }
            }
            return null;
        }

        public Product CreateDrink(int id, int price, string name, string beverageType, string packageType, string beverageDescription)

        {
            Drink product = new Drink(id, price, name, beverageType, packageType, beverageDescription);
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = product;
                    return product;
                }
            }
            return null;

        }

        public Product CreateCandy(int id, int price, string name, string candyType, string candyDescription)
        {
            Candy product = new Candy(id, price, name, candyType, candyDescription);
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    products[i] = product;
                    return product;
                }
            }
            return null;
        }

        public void Clear()
        {
            products = new Product[10];
            moneyInserted = 0;
        }

    }
}