using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Model
{
    public class Drink : Product
    {
        private string beverageType;
        private string packageType;
        private string beverageDescription;

        public string BeverageType { get { return beverageType; } set { beverageType = value; } }

        public string PackageType { get { return packageType; } set { packageType = value; } }

        public string BeverageDescription { get { return beverageDescription; } set { beverageDescription = value; } }

        public Drink (int id) : base(id)
        {

        }

        public Drink(int id, int priceOfProduct, string productName, string beverageType, string packageType, string beverageDescription) : base(id, priceOfProduct, productName)
        {
            this.beverageType = beverageType;
            this.packageType = packageType;
            this.beverageDescription = beverageDescription;
        }

        public override string Examine()
        {
            return $"{BeverageType}: {PackageType}: {BeverageDescription}";
        }

        public override string Use()
        {
            if (packageType == "Bottle")
            {
                return $" Open the cap and you can now drink from the bottle.";
            }
            else { return $" Bend the opener to uprigth posion and then bend it back to original posion. You can now drink from the can."; }
        }
    }
}
