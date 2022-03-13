using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model
{
    public class Food : Product
    {
        private string foodType;
        private string foodDescription;



        public string FoodType { get { return foodType; } set { foodType = value; } }

        public string FoodDescription { get { return foodDescription; } set { foodDescription = value; } }

        public Food(int id) :base(id) { }

        public Food(int id, int priceOfProduct, string productName, string foodType, string foodDescription) : base(id, priceOfProduct, productName)
        {
            FoodType = foodType;
            FoodDescription = foodDescription;
        }

        public override string Examine()
        {
            return $"{ id}: price: { priceOfProduct}: { productName}: { FoodType}: {FoodDescription} ";
        }

        public override string Use()
        {
            if (foodType == "Sandwich")
            {
                return $" Unrapp the sandwich and eat it";
            }
            else
            {
                return $" Remove the lid and take the fork and knife and start to eat.";
            }

        }
    }
}
