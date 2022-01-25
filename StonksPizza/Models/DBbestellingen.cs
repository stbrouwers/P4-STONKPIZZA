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
            get { return BestellingID; }
            set { BestellingID = value; }
        }

        private int userID;
        public int UserID
        {
            get { return UserID; }
            set { UserID = value; }
        }

        private string bestellingContent;
        public string BestellingContent
        {
            get { return BestellingContent; }
            set { BestellingContent = value; }
        }

        private string status;
        public string Status
        {
            get { return Status; }
            set { Status = value; }
        }
    }
}
