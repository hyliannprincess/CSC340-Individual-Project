using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PizzaDeliverySystem
{
    internal class Pizza
    {
        double price;
        int size;

        public Pizza(double price, int size)
        {
            this.price = price;
            this.size = size;
        }

        public double getPrice()
        {
            return price;
        }

        public int getSize()
        {
            return size;
        }
    }
}
