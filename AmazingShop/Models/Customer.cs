using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmazingShop.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string DeliveryAddress { get; set; }

        public string[] Countries = new string[] { "Ukraine", "Poland", "Moldova", "Croatia", "Slovak Republic" };
    }
}