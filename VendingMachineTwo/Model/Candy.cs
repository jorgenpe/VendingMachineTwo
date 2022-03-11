using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine.Model
{
    public class Candy : Product
    {
        private string candyType;
        private string candyDescription;

        public Candy(int id) : base(id)
        {

        }

        public Candy(int id, int priceOfProduct, string productName, string candyType, string candyDescription) : base(id, priceOfProduct, productName)
        {
            this.candyType = candyType;
            this.candyDescription = candyDescription;
        }

        public string CandyType { get { return candyType; } set { candyType = value; } }

        public string CandyDescription { get { return candyDescription; } set { candyDescription = value; } }

        public override string Examine()
        {
            return $"{CandyType}: {CandyDescription}";
        }

        public override string Use()
        {
            return $"Open the rapper and eat your candy";
        }
    }
}
