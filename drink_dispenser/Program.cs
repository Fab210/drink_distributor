using System;

namespace drink_distributor
{

    class CoinsValueQuantity
    {
        public float coinValue;
        public int coinQuantity;

        public CoinsValueQuantity(float Value, int Quantity)
        {
            coinValue = Value;
            coinQuantity = Quantity;
        }
    }



    class Program
    {
        static string coca = "Coca Cola";
        static string fanta = "Fanta";
        static string sprite = "Sprite";
        static float cocaPrice = 1.50f;
        static float fantaPrice = 1.60f;
        static float spritePrice = 1.25f;
        static float coinsValueF = 0.0f;

 
        static string selectedDrink;

        static CoinsValueQuantity coin1C = new CoinsValueQuantity(0.01f, 13);
        static CoinsValueQuantity coin2C = new CoinsValueQuantity(0.02f, 45);
        static CoinsValueQuantity coin5C = new CoinsValueQuantity(0.05f, 31);
        static CoinsValueQuantity coin10C = new CoinsValueQuantity(0.10f, 22);
        static CoinsValueQuantity coin20C = new CoinsValueQuantity(0.20f, 33);
        static CoinsValueQuantity coin50C = new CoinsValueQuantity(0.50f, 0);
        static CoinsValueQuantity coin1Eur = new CoinsValueQuantity(1, 74);
        static CoinsValueQuantity coin2Eur = new CoinsValueQuantity(2, 44);



        static void SelectDrink()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Hello");
            Console.WriteLine();
            Console.WriteLine("Please select a drink : ");
            
            Console.WriteLine("1 : " + coca);
            Console.WriteLine("2 : " + fanta);
            Console.WriteLine("3 : " + sprite);
            Console.WriteLine();
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


        static float SelectedCoin()
        {
            Console.WriteLine("Select coin for paying");
            Console.WriteLine("______________________________________");
            Console.WriteLine("[1]" + coin1C.coinValue + " cent");
            Console.WriteLine("[2]" + coin2C.coinValue + " cents");
            Console.WriteLine("[3]" + coin5C.coinValue + " cents");
            Console.WriteLine("[4]" + coin10C.coinValue + " cents");
            Console.WriteLine("[5]" + coin20C.coinValue + " cents");
            Console.WriteLine("[6]" + coin50C.coinValue + " cents");
            Console.WriteLine("[7]" + coin1Eur.coinValue + " euro");
            Console.WriteLine("[8]" + coin2Eur.coinValue + " euro");


            string selectedcoin = Console.ReadLine();
            int selectedcoin_num = int.Parse(selectedcoin);
            float coinSelected = 0.0f;

            switch (selectedcoin_num)
            {
                case 1:
                    coinSelected = coin1C.coinValue;
                    break;
                case 2:
                    coinSelected = coin2C.coinValue;
                    break;
                case 3:
                    coinSelected = coin5C.coinValue;
                    break;
                case 4:
                    coinSelected = coin10C.coinValue;
                    break;
                case 5:
                    coinSelected = coin20C.coinValue;
                    break;
                case 6:
                    coinSelected = coin50C.coinValue;
                    break;
                case 7:
                    coinSelected = coin1Eur.coinValue;
                    break;
                case 8:
                    coinSelected = coin2Eur.coinValue;
                    break;
            }

            return coinSelected;

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
                        Console.WriteLine();
                        coinsValueF = SelectedCoin();
                        CalculateDrinkPrice(coinsValueF, cocaPrice);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + fantaPrice + " € for " + fanta);
                        Console.WriteLine();
                        coinsValueF = SelectedCoin();
                        CalculateDrinkPrice(coinsValueF, fantaPrice);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + spritePrice + " € for " + sprite);
                        Console.WriteLine();
                        coinsValueF = SelectedCoin();
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

                float missingMoneyValueF = SelectedCoin();

                moneyDifference = moneyDifference - missingMoneyValueF;
                moneyDifference = RoundNumber(moneyDifference);

                while (moneyDifference > 0.00)
                {
                    Console.WriteLine();
                    Console.WriteLine("there is still " + moneyDifference + "€ missing");
                    missingMoneyValueF = SelectedCoin();
                   
                    moneyDifference = moneyDifference - missingMoneyValueF;
                    moneyDifference = RoundNumber(moneyDifference);
                }
                ReturnMoney(moneyDifference);
            }
            else
            {
                moneyDifference = drinkPrice - coins;
                ReturnMoney(moneyDifference);
            }
            Console.WriteLine();

            moneyDifference = ConvertToPositivNumber(moneyDifference);
            moneyDifference = RoundNumber(moneyDifference);
            Console.WriteLine("Here is your change " + moneyDifference + "€ ");
            Console.WriteLine();
            Console.WriteLine("And drink number " + selectedDrink);

            SelectDrink();
        }


        // Convert negativ number into positiv
        static float ConvertToPositivNumber(float number)
        {
            number = number * -1;

            return number;
        }

        // Round Number to 2 decimal places
        static float RoundNumber(float coinsValue)
        {
            coinsValue = (float)Math.Round(coinsValue * 100f) / 100f;

            return coinsValue;
        }

        static void ReturnMoney(float moneyGiveBack)
        {
            moneyGiveBack = RoundNumber(moneyGiveBack);
            moneyGiveBack = ConvertToPositivNumber(moneyGiveBack);

            Console.WriteLine("Coins before Quantity : " + coin1C.coinQuantity + " / value : " + coin1C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin2C.coinQuantity + " / value : " + coin2C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin5C.coinQuantity + " / value : " + coin5C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin10C.coinQuantity + " / value : " + coin10C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin20C.coinQuantity + " / value : " + coin20C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin50C.coinQuantity + " / value : " + coin50C.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin1Eur.coinQuantity + " / value : " + coin1Eur.coinValue);
            Console.WriteLine("Coins before Quantity : " + coin2Eur.coinQuantity + " / value : " + coin2Eur.coinValue);

            Console.WriteLine("Monnaie rendu de : (" + coinsValueF + ")");

            while (moneyGiveBack != 0.0f)
            {
                if ((coin2Eur.coinValue <= moneyGiveBack) && (coin2Eur.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin2Eur.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin2Eur.coinQuantity = coin2Eur.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 2 euro");
                }
                else if ((coin1Eur.coinValue <= moneyGiveBack) && (coin1Eur.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin1Eur.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin1Eur.coinQuantity = coin1Eur.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 1 euro");
                }
                else if ((coin50C.coinValue <= moneyGiveBack) && (coin50C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin50C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin50C.coinQuantity = coin50C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 50 cents");
                }
                else if ((coin20C.coinValue <= moneyGiveBack) && (coin20C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin20C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin20C.coinQuantity = coin20C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 20 cents");
                }
                else if ((coin10C.coinValue <= moneyGiveBack) && (coin10C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin10C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin10C.coinQuantity = coin10C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 10 cents");
                }
                else if ((coin5C.coinValue <= moneyGiveBack) && (coin5C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin5C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin5C.coinQuantity = coin5C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 5 cents");
                }
                else if ((coin2C.coinValue <= moneyGiveBack) && (coin2C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin2C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin2C.coinQuantity = coin2C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 2 cents");
                }
                else if ((coin1C.coinValue <= moneyGiveBack) && (coin1C.coinQuantity >= 1))
                {
                    moneyGiveBack = moneyGiveBack - coin1C.coinValue;
                    moneyGiveBack = RoundNumber(moneyGiveBack);
                    coin1C.coinQuantity = coin1C.coinQuantity - 1;
                    Console.WriteLine("\t - Piece : 1 cent");
                }
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Coins after Quantity : " + coin1C.coinQuantity + " / value : " + coin1C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin2C.coinQuantity + " / value : " + coin2C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin5C.coinQuantity + " / value : " + coin5C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin10C.coinQuantity + " / value : " + coin10C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin20C.coinQuantity + " / value : " + coin20C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin50C.coinQuantity + " / value : " + coin50C.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin1Eur.coinQuantity + " / value : " + coin1Eur.coinValue);
            Console.WriteLine("Coins after Quantity : " + coin2Eur.coinQuantity + " / value : " + coin2Eur.coinValue);

        }





        static void Main(string[] args)
        {
            // Convert special symbols to show on console ex : €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SelectDrink();

        }
    }
}
