using System;
using System.Collections.Generic;
using System.Text;

namespace drink_distributor.Models
{
    public class DrinkModel
    {

        public string drinkName { get; set; }
        public float drinkPrice { get; set; }
        public int drinkQuantity { get; set; }
        public int drinkPosition { get; set; }
        public string drinkID { get; set; }

        public DrinkModel(string Name = "", float Price = 0.0f ,int Quantity = 0, int Position = 0)
        {
            drinkName = Name;
            drinkPrice = Price;
            drinkQuantity = Quantity;
            drinkPosition = Position;

        }
    }
}
