using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    class Wolf : Animal
    {
        public Wolf(string Name,String Side, Boolean IsHungry, string FavFood, Boolean CanRow) : base(Name,Side, IsHungry, FavFood, CanRow)
        {

        }


        public void bark()
        {
            Console.WriteLine("Woof!");
        }



    }
}
