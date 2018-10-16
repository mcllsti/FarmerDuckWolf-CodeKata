using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerDuckWolf
{
    class Boat : Transportable
    {
        const int capacity = 2;
        private string madeOf;
        private Stack<Transportable> inBoat;
        private int seatsTaken = 0;

        public string MadeOf
        {
            get { return madeOf; }
            set { madeOf = value; }
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="MadeOf">String. What is the boat made of?</param>
        public Boat(string Name,string Side,string MadeOf) : base(Name,Side)
        {
            madeOf = MadeOf;
            seatsTaken = 0;
            inBoat = new Stack<Transportable>();
        }

        public void Reset()
        {
            inBoat.Clear();
            seatsTaken = 0;
        }

        /// <summary>
        /// Displays the arrtributes of the boat
        /// </summary>
        public void displayBio()
        {
            Console.WriteLine("There is " + capacity + " seats.");
            Console.WriteLine("The boat is made of : " + madeOf);
        }

        /// <summary>
        /// Checks if the boat is full
        /// </summary>
        /// <returns>Boolean. True if full</returns>
        public Boolean isFull()
        {
            if (seatsTaken == capacity)
            {
                return true;
            }
            else return false;

        }

        /// <summary>
        /// Checks if the boat is empty
        /// </summary>
        /// <returns>Boolean. True if empty</returns>
        public Boolean isEmpty()
        {
            if (seatsTaken == 0)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Adds a object to the boat stack.
        /// </summary>
        /// <param name="AddObject">Object. The thing to be added</param>
        public void addBoat(Transportable AddObject)
        {


            if(AddObject.Side.Equals(this.Side))
            {
                if (isEmpty())
                {
                    if (AddObject is Farmer)
                    {
                        inBoat.Push(AddObject);
                        Console.WriteLine("The farmer gets in.");
                        seatsTaken++;
                    }
                    else
                    {
                        Console.WriteLine("The farmer must get in first!");
                    }
                }
                else if (isFull())
                {
                    Console.WriteLine("The boat is full");
                }
                else
                {
                    if ((inBoat.Peek() is Farmer) && (AddObject is Farmer))
                    {
                        Console.WriteLine("The farmer is already in the boat!");

                    }
                    else
                    {
                        inBoat.Push(AddObject);
                        Console.WriteLine(AddObject.Name +" gets in the boat.");
                        seatsTaken++;
                    }
                }
            }
            else
            {
                Console.WriteLine("They must be on the same side!");
            }

        }

        /// <summary>
        /// Removes a object from the boat stack
        /// </summary>
        /// <param name="removeObject">Object. Object to be removed</param>
        public Transportable removeBoat()
        {
            if (isEmpty())
            {
                Console.WriteLine("The boat is empty");
                return null;
            }
            else
            {
                Transportable temp = inBoat.Pop();
                Console.WriteLine(temp.Name + " was removed from the boat. It is now on the " + this.Side);
                seatsTaken--;
                return temp;
            }
        }

    }
}
