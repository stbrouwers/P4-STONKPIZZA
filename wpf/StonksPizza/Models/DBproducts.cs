using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class DBproducts
    {
        private int productid;
        public int ProductID
        {
            get { return productid; }
            set { productid = value; }
        }

        private string productname;
        public string ProductName
        {
            get { return productname; }
            set { productname = value; }
        }

        private string productprice;
        public string ProductPrice
        {
            get { return productname; }
            set { productname = value; }
        }
    }
}
