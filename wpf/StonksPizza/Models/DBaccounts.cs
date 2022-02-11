using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksPizza.Models
{
    public class DBaccounts:Notify
    {
        private int accountID;
        public int AccountID
        {
            get { return accountID; }
            set { accountID = value; OnPropertyChanged(); }
        }

        private string volledigenaam;
        public string VolledigeNaam
        {
            get { return volledigenaam; }
            set { volledigenaam = value; }
        }

        private string wachtwoord;
        public string Wachtwoord
        {
            get { return wachtwoord; }
            set { wachtwoord = value; }
        }

        private bool ismanager;
        public bool IsManager
        {
            get { return ismanager; }
            set { ismanager = value; }
        }
    }
}
