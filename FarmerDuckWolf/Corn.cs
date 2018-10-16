using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    class Corn : Transportable
    {
        private Boolean isDelicious;
        private string howMuch;

        public Boolean IsDelicious
        {
            get { return IsDelicious; }
            set { IsDelicious = value; }
        }

        public string HowMuch
        {
            get { return howMuch; }
            set { howMuch = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsDelicious"></param>
        /// <param name="HowMuch"></param>
        public Corn(string Name, string Side, Boolean IsDelicious, string HowMuch) : base(Name, Side)
        {
            isDelicious = IsDelicious;
            howMuch = HowMuch;
        }

        /// <summary>
        /// Displays the attributes of the Corn 
        /// </summary>
        private void displayBio()
        {
            Console.WriteLine("Is the corn delicious? " + isDelicious);
            Console.WriteLine("How much corn is there? " + howMuch);
        }
    }
}
