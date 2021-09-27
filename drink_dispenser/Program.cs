using drink_distributor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using drink_distributor.Processing;


namespace drink_distributor
{


    class Program
    {
        
        static void Main(string[] args)
        {
            // Convert special symbols to show on console ex : €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Console.WriteLine($" INFO {coca}");
            //Index();

            Distributor p = new Distributor();
            p.SelectDrink();

        }
    }
}
