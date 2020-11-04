using System;
using System.Collections.Generic;
using System.Text;

namespace Lotto
{
    public abstract class Ticket
    {
        // This is the base class Ticket, Euro and Lotto are subclasses
        public Customer Customer { get; set; }   // property

        private int[] _numbers = new int[6];      // field
        public int[] Numbers
        {
            get { return _numbers; }
            set
            {
                Boolean bOK = true;
                foreach (int number in value)  // value is the numbers array being set through the object
                {
                    if (number < 0 | number > 49)  // use single | as we want both conditoins to be tested
                    {
                        bOK = false;
                        throw new Exception("The ball numbers must be between 1 and 49");
                    }

                }
                if (bOK) { _numbers = value; }
            }
        }      // autoproperty, integer array, with logic

        public string Day { get; set; }  // This could be a dictionary object

        public DateTime DateOfPurchase { get; set; } // date of Purchase

        //public List<string> contacts { get; set;}   //syntax for a list named contacts
        public Ticket() // CONSTRUCTOR
        {
            // may well set date of purchase
        }

        public override abstract string ToString(); // This overrides the standard String ToString() class.
        
        public static int[] RandomNum()  // static as it is irrespective of object data
        {/* this is a utility to create a random number for the ticket, 
            this will be moved to a utility class.*/
            Random rand = new Random();

            int min = 1;
            int max = 50;

            int[] randNums = new int[7];
            for (int i = 0; i < randNums.Length; i++)
            {
                randNums[i] = rand.Next(min, max);
            }
            return randNums;
        }

    }
}

