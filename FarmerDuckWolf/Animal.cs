using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    abstract class Animal : Transportable
    {
        
        protected Boolean isHungry;
        protected string favFood;
        protected Boolean canRow;
        

        public Boolean IsHungry
        {
            get { return isHungry; }
            set { isHungry = value; }
        }

        public string FavFood
        {
            get { return favFood; }
            set { favFood = value; }
        }

        public Boolean CanRow
        {
            get { return canRow; }
            set { canRow = value; }
        }





        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="Name">String. Name of the animal.</param>
        /// <param name="IsHungry">Boolean. Is the animal hungry?</param>
        /// <param name="FavFood">String. Animals Favorite Food.</param>
        public Animal(string Name,String Side,Boolean IsHungry,string FavFood,Boolean CanRow) : base(Name,Side)
        {
            
            isHungry = IsHungry;
            favFood = FavFood;
            canRow = CanRow;
        }

        /// <summary>
        /// Prints the animals infomration to the console.
        /// </summary>
        public void printBio()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Hungry?: " + isHungry);
            Console.WriteLine("Favorite Food: " + favFood);
            Console.WriteLine("Can they row?: " + canRow);

        }

        
    }
}
