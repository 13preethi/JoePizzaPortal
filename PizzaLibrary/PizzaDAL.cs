using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary
{
   public class PizzaDAL
    {
        public List<Pizza> pizzalist;
        public PizzaDAL()
        {
            pizzalist = new List<Pizza>();
        }
        public List<Pizza> PizzaDetails()
        {
            Pizza p1 = new Pizza() { Id = 1, Type = "Corn Cheesy Pizza", Price = 90.00 };
            Pizza p2 = new Pizza() { Id = 2, Type = "Golden Corn Pizza", Price = 99.87 };
            Pizza p3 = new Pizza() { Id = 3, Type = "Mushroom Pizza", Price = 145.67 };
            Pizza p4 = new Pizza() { Id = 4, Type = "Chicken Pizza", Price = 450.76 };
            Pizza p5 = new Pizza() { Id = 5, Type = "Paneer Tikka Pizza", Price = 199.49 };


            pizzalist.Add(p1);
            pizzalist.Add(p2);
            pizzalist.Add(p3);
            pizzalist.Add(p4);
            pizzalist.Add(p5);

            return pizzalist;

        }
     

    }
}
