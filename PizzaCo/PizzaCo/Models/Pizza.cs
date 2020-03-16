using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCo.Models
{
    public class Pizza
    {
        public List<string> Toppings { get; set; }
    }

    public class PizzaFavorite
    {
        public string Toppings { get; set; }
        public int Count { get; set; }
    }
}
