using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleItemManagement.Classes
{
   public class Location
    {
        public Guid Id { get; set; }
        public string code { get; set; }
        public int Quantity { get; set; }
        public string ItemCode { get; set; }
    }
}
