using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class LoadGame
    {
        SqlConnection mydb = new SqlConnection("Server=LAPTOP-MR3G567K;Database=LemonadeLoadGame;Integrated Security=true;");
        List<string> loadNames = new List<string>();
        List<double> loadWallets = new List<double>();
        List<DateTime> loadGames = new List<DateTime>();
        DateTime loadGameDateTime;
        int loadGameSeasonLength;
        int loadGameDay;


        public void LoadThisGame(Player player)
        {
            GetPlayerInfo(player);
            LoadSeason mySeason = new LoadSeason(loadGameSeasonLength);
            GetPlayerReports(player, mySeason);
            GetPlayerSupplies(player, loadGameDay);
            mySeason.DayCount = loadGameDay +1 ;
            mySeason.SalesSeason(player);

        }
        public bool SetGameToLoad(string response)
        {
            int gamePick = 1;
            bool goodGamePick = true;
            switch (response)
            {
                case "":
                    goodGamePick = false;
                    break;
                default:
                    try
                    {
                        gamePick = Int32.Parse(response);
                    }
                    catch
                    {
                        goodGamePick = false;
                        Console.WriteLine("Sorry, that pick doesn't seem to work.  Hit Enter.");
                        Console.ReadLine();
                    }
                    break;
            }
            if (goodGamePick)
                loadGameDateTime = loadGames.ElementAt(gamePick - 1);

            return goodGamePick;
        }
        public string LoadGameList()
        {
            SqlDataReader myReader;

            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

            try
            {
                string selectQuery = "SELECT TOP 10 Name, Wallet, Game_Date_Time FROM dbo.Player ORDER BY Game_Date_Time desc";
                SqlCommand myCmd = new SqlCommand(selectQuery, mydb);
                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    loadNames.Add(myReader.GetString(0));
                    loadWallets.Add(double.Parse(myReader.GetSqlMoney(1).ToString()));
                    loadGames.Add(myReader.GetDateTime(2));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }


            return UserInterface.LoadGameList(loadNames, loadWallets, loadGames);
        }

        public void GetPlayerInfo(Player player)
        {

            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning player info" + e);
                Console.ReadLine();
            }
            try
            {
                string query = $"SELECT Player_Id, Name, Wallet, Game_Length FROM dbo.Player WHERE Game_Date_Time = '{loadGameDateTime.ToString("yyyy-MM-dd HH:mm:ss tt")}'";
                SqlCommand myCmd = new SqlCommand(query, mydb);
                SqlDataReader myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    player.PlayerId = myReader.GetInt32(0);
                    player.Name = myReader.GetString(1);
                    player.Wallet = double.Parse(myReader.GetSqlMoney(2).ToString());
                    loadGameSeasonLength = myReader.GetInt32(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Finding Player info" + e);
                Console.ReadLine();
            }
            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing Player info" + e);
                Console.ReadLine();
            }

        }
        public void GetPlayerSupplies(Player player, int gameDay)
        {
            SqlCommand myCmd;
            SqlDataReader myReader;
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Getting supply info" + e);
                Console.ReadLine();
            }
            try
            {
                string query = $"SELECT Shelf_Life FROM dbo.Lemons WHERE Person_Id = {player.PlayerId} AND Day = {gameDay}";
                myCmd = new SqlCommand(query, mydb);
                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    Lemon alemon = new Lemon("Lemon", myReader.GetInt32(0), player.mySupplier.GetPrice("Lemon"));
                    player.MySupplies.myLemons.Add(alemon);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Finding supplies" + e);
                Console.ReadLine();
            }
            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing supplies" + e);
                Console.ReadLine();
            }
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Getting supply info" + e);
                Console.ReadLine();
            }
            try
            {
                string query = $"SELECT Shelf_Life FROM dbo.Sugar WHERE Person_Id = {player.PlayerId} AND Day = {gameDay}";
                myCmd = new SqlCommand(query, mydb);
                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    Sugar aSugar = new Sugar("Sugar", myReader.GetInt32(0), player.mySupplier.GetPrice("Sugar"));
                    player.MySupplies.mySugar.Add(aSugar);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Finding supplies" + e);
                Console.ReadLine();
            }

            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing supplies" + e);
                Console.ReadLine();
            }
        }
        public void GetPlayerReports(Player player, LoadSeason season)
        {

            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Getting Reports" + e);
                Console.ReadLine();
            }
            try
            {
                string query = $"SELECT DayNumber, Net, Gross, Temprature, Weather_Condition, Price_Per_Cup, Pitchers_Sold, Cost_Of_Pitcher, Cups_Sold, Pitchers_Available, Quality_Of_Supply FROM dbo.Report WHERE Player_Id = {player.PlayerId} ORDER BY DayNumber";
                SqlCommand myCmd = new SqlCommand(query, mydb);
                SqlDataReader myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    DailyReport report = new DailyReport();
                    report.DayNumber = myReader.GetInt32(0);
                    report.Net = double.Parse(myReader.GetSqlMoney(1).ToString());
                    report.Gross = double.Parse(myReader.GetSqlMoney(2).ToString());
                    report.WTemp = myReader.GetInt32(3);
                    report.WCondition = myReader.GetString(4);
                    report.PricePerCup = double.Parse(myReader.GetSqlMoney(5).ToString());
                    report.PitchersSold = myReader.GetInt32(6);
                    report.CostOfPitcher = double.Parse(myReader.GetSqlMoney(7).ToString());
                    report.CupsSold = myReader.GetInt32(8);
                    report.PitchersAvailable = myReader.GetInt32(9);
                    report.QualityOfSupply = myReader.GetString(10);
                    season.MyReports.Add(report);
                    loadGameDay = report.DayNumber;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Finding reports" + e);
                Console.ReadLine();
            }

            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing reports" + e);
                Console.ReadLine();
            }
        }
    }
}
