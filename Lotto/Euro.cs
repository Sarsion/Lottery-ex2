using System;
using System.Collections.Generic;
using System.Text;

namespace Lotto
{
    public class Euro : Ticket  // Euro is a subclass of the base class Ticket
    {
        public int[] LuckyStar { get; set; } = new int[2];
        public string Country { get; set; }

        public override string ToString() // This overrides the ToString() class in Ticket.
        {
            string message;
            StringBuilder sb = new StringBuilder();
  
            sb.Append(Customer.Name);
            sb.Append(Customer.email);
            sb.Append(Day);
            sb.Append(Numbers[1]);
            sb.Append(Country);
            message = sb.ToString();

            return message;

        }
    }
}
