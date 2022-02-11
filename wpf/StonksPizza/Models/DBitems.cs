using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class DBitems
    {
        private int itemID;
        public int ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemCount;
        public string ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; }
        }

        private double itemPrice;
        public double ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
    }
}
