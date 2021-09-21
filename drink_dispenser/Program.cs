using drink_distributor.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace drink_distributor
{


    class Program
    {
        // VARIABLES
        static float selectedCoinValue = 0.0f;
        static string selectedDrink;

        static CoinModel coin1C = new CoinModel(0.01f, 13);
        static CoinModel coin2C = new CoinModel(0.02f, 45);
        static CoinModel coin5C = new CoinModel(0.05f, 31);
        static CoinModel coin10C = new CoinModel(0.10f, 22);
        static CoinModel coin20C = new CoinModel(0.20f, 33);
        static CoinModel coin50C = new CoinModel(0.50f, 0);
        static CoinModel coin1Eur = new CoinModel(1, 74);
        static CoinModel coin2Eur = new CoinModel(2, 44);

        DrinkModel coca = new DrinkModel("Coca Cola", 1.35f, 12, 1);
        DrinkModel fanta = new DrinkModel("Fanta", 1.49f, 20, 2);
        DrinkModel sprite = new DrinkModel("Sprite", 1.23f, 22, 3);
     

        // METHODES
        public void SelectDrink()
        {
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("");
            Console.WriteLine("Hello");
            Console.WriteLine();
            Console.WriteLine("Please select a drink : ");

            Console.WriteLine("1 : " + coca.drinkName);
            Console.WriteLine("2 : " + fanta.drinkName);
            Console.WriteLine("3 : " + sprite.drinkName);
            Console.WriteLine();
            selectedDrink = Console.ReadLine();
            int selectedDrink_num = int.Parse(selectedDrink);


            switch (selectedDrink_num)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + coca.drinkName);
                    PayDrink(1);
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + fanta.drinkName);
                    PayDrink(2);
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("You selected " + sprite.drinkName);
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


        public float SelectedCoin()
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

        public void PayDrink(int drinkSelection)
        {

            try
            {
                switch (drinkSelection)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + coca.drinkPrice + " € for " + coca.drinkName);
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateDrinkPrice(selectedCoinValue, coca.drinkPrice);
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + fanta.drinkPrice + " € for " + fanta.drinkName);
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateDrinkPrice(selectedCoinValue, fanta.drinkPrice);
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Please pay " + sprite.drinkPrice + " € for " + sprite.drinkName);
                        Console.WriteLine();
                        selectedCoinValue = SelectedCoin();
                        CalculateDrinkPrice(selectedCoinValue, sprite.drinkPrice);
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please choose a correct price in €");
                PayDrink(drinkSelection);
            }
        }

        public void CalculateDrinkPrice(float coins, float drinkPrice)
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
        public float ConvertToPositivNumber(float number)
        {
            number = number * -1;

            return number;
        }

        // Round Number to 2 decimal places
        public float RoundNumber(float coinsValue)
        {
            coinsValue = (float)Math.Round(coinsValue * 100f) / 100f;

            return coinsValue;
        }

        public void ReturnMoney(float moneyGiveBack)
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

            Console.WriteLine("Monnaie rendu de : (" + selectedCoinValue + ")");

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
        public static List<CoinModel> Index()
        {
            string connetionString = null;
            List<CoinModel> coinList = new List<CoinModel>();

            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = "Data Source=localhost;Database=distributor;Integrated Security=true;";
            sql = "SELECT * From coins";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    CoinModel coins = new CoinModel();
                    coins.coinID = Convert.ToString(dataReader["coinID"]);
                    //Console.WriteLine(dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + " - " + dataReader.GetValue(2));
                    coinList.Add(coins);
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }

            return coinList;
        }



        static void Main(string[] args)
        {
            // Convert special symbols to show on console ex : €
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Console.WriteLine($" INFO {coca}");
            Index();

            //Program p = new Program();
            //p.SelectDrink();

        }
    }
}
