using System;

namespace drink_distributor
{
    class Program
    {    
        static string coca = "Coca Cola";
        static string fanta = "Fanta";
        static string sprite = "Sprite";
        static float cocaPrice = 1.50f;
        static float fantaPrice = 1.60f;
        static float spritePrice = 1.25f;
        static string coinsValue = "0";
        static float coinsValueF = 0.0f;

        static string selectedDrink;


        static void SelectDrink()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Please select a drink : ");
            Console.WriteLine("1 : " + coca);
            Console.WriteLine("2 : " + fanta);
            Console.WriteLine("3 : " + sprite);

            selectedDrink = Console.ReadLine();
            int selectedDrink_num = int.Parse(selectedDrink);


            switch (selectedDrink_num)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + coca);
                    PayDrink(1);
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + fanta);
                    PayDrink(2);
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + sprite);
                    PayDrink(3);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Please Select again");
                    Console.WriteLine("--------------------");
                    SelectDrink();
                    break;
            }
        }

        static void PayDrink(int drinkSelection)
        {

            try
            {
                switch (drinkSelection)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + cocaPrice + " € for " + coca);
                        coinsValue = Console.ReadLine();
                        coinsValueF = float.Parse(coinsValue);
                        CalculateDrinkPrice(coinsValueF, cocaPrice);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + fantaPrice + " € for " + fanta);
                        coinsValue = Console.ReadLine();
                        coinsValueF = float.Parse(coinsValue);
                        CalculateDrinkPrice(coinsValueF, fantaPrice);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + spritePrice + " € for " + sprite);
                        coinsValue = Console.ReadLine();
                        coinsValueF = float.Parse(coinsValue);
                        CalculateDrinkPrice(coinsValueF, spritePrice);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please choose a correct price in €");
                PayDrink(drinkSelection);
            }
        }

        static void CalculateDrinkPrice(float coins, float drinkPrice)
        {
            float moneyDifference = 0.0f;
            if (coins < drinkPrice)
            {
                moneyDifference = drinkPrice - coins;
                moneyDifference = RoundNumber(moneyDifference);
                Console.WriteLine("there is still " + moneyDifference + "€ missing");

                string missingMoneyValue = Console.ReadLine();
                float missingMoneyValueF = float.Parse(missingMoneyValue);
                missingMoneyValueF = RoundNumber(missingMoneyValueF);

                moneyDifference = moneyDifference - missingMoneyValueF;
                moneyDifference = RoundNumber(moneyDifference);

                while (moneyDifference > 0.00)
                {
                    Console.WriteLine();
                    Console.WriteLine("there is still " + moneyDifference + "€ missing");
                    missingMoneyValue = Console.ReadLine();
                    missingMoneyValueF = float.Parse(missingMoneyValue);
                    moneyDifference = moneyDifference - missingMoneyValueF;
                    moneyDifference = RoundNumber(moneyDifference);
                }
            }
            else
            {
                moneyDifference = drinkPrice - coins;
            }
            Console.WriteLine();
            Console.WriteLine("Here is your change " + moneyDifference + "€ ");
            Console.WriteLine("And drink number " + selectedDrink);
        }

        // Round Number to 2 decimal places
        static float RoundNumber(float coinsValue)
        {
            coinsValue = (float)Math.Round(coinsValue * 100f) / 100f;

            return coinsValue;
        }



        static void Main(string[] args)
        {
            // Convert special symbols to show on console ex : €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SelectDrink();
        }
    }
}
