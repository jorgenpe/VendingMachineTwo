using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine.Model
{
    public abstract class Product
    {
        protected readonly int id;
        protected int priceOfProduct;
        protected string productName;

        public Product(int id)
        {
            this.id = id;
        }

        public Product(int id, int priceOfProduct, string productName) : this(id)
        {

            this.priceOfProduct = priceOfProduct;
            this.productName = productName;
        }

        public int Id { get { return id; } }

        public int PriceOfProduct { get { return priceOfProduct; } set { this.priceOfProduct = value; } }

        public string ProductName { get { return productName; } set { this.productName = value; } }

        public abstract string Examine();
        public abstract string Use();
    }
}
