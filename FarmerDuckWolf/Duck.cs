using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    class Duck : Animal
    {
        private Boolean canSwim;

        public Boolean CanSwim
        {
            get { return canSwim; }
            set { canSwim = value; }
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="Name">String. Name of the animal.</param>
        /// <param name="IsHungry">Boolean. Is the animal hungry?</param>
        /// <param name="FavFood">String. Animals Favorite Food.</param>
        /// <param name="canSwim">Boolean. Can the duck swim?</param>
        public Duck(string Name,String Side, Boolean IsHungry, string FavFood, Boolean CanRow,Boolean CanSwim) : base(Name,Side, IsHungry, FavFood, CanRow)
        {
            canSwim = CanSwim;
        }

        /// <summary>
        /// prints ducks responce
        /// </summary>
        public void quack()
        {
            Console.WriteLine("Quack!");
        }

        /// <summary>
        /// prints the attributes of the duck
        /// </summary>
        public new void printBio()
        {
            base.printBio();
            Console.WriteLine("Can Duck Swim? " + canSwim);
        }

    }
}
