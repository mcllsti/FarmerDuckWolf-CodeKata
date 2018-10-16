using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    class Transportable
    {
        protected string side = "Left Bank";
        protected string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Side
        {
            get { return side; }
            set { side = value; }
        }

        public Transportable(string Name,string Side)
        {
            name = Name;
            side = Side;
        }

        public void sideOn()
        {
            Console.WriteLine("They are on the " + side);
        }

        public override string ToString()
        {
            return base.ToString().Remove(0,15) ;//.ToString() + ": ";
        }
    }
}
