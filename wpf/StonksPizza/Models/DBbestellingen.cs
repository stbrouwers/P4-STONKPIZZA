using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class DBbestellingen
    {
        private int bestellingID;
        public int BestellingID
        {
            get { return bestellingID; }
            set { bestellingID = value; }
        }

        private int userID;
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string bestellingContent;
        public string BestellingContent
        {
            get { return bestellingContent; }
            set { bestellingContent = value; }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
