using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class SaveGame
    {
        SqlConnection mydb = new SqlConnection("Server=LAPTOP-MR3G567K;Database=LemonadeLoadGame;Integrated Security=true;");


        public int GetPlayerId(Player player, DateTime myGame)
        {

            int thisId = 0;
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Getting Player Id" + e);
                Console.ReadLine();
            }


            try
            {

                string query = $"SELECT Player_Id FROM dbo.Player WHERE Game_Date_Time = '{myGame.ToString("yyyy-MM-dd HH:mm:ss tt")}'";
                SqlCommand myCmd = new SqlCommand(query, mydb);
                SqlDataReader myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    thisId = myReader.GetInt32(0);

                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Finding Player Id" + e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ClosingPlayer Id" + e);
                Console.ReadLine();
            }
            return thisId;

        }

        public void InsertIntoPlayer(Player player, DateTime myGame, int gameLength)

        {
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Player Insert" + e);
                Console.ReadLine();
            }
            
            string addQuery = $"INSERT INTO dbo.Player (Name, Wallet, Game_Date_Time, Game_Length) VALUES ('{player.Name}', {player.Wallet}, '{myGame.ToString("yyyy-MM-dd HH:mm:ss tt")}', {gameLength})";

            try
            {
                SqlCommand myAdd = new SqlCommand(addQuery, mydb);
                myAdd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Player Insert" + e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing Player Insert" + e);
                Console.ReadLine();
            }

        }
        public void InsertIntoReport(DailyReport aReport, int playerId)
        {
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Inser to Reports" + e);
                Console.ReadLine();
            }

            string addQuery = $"INSERT INTO dbo.Report (DayNumber, Net, Gross, Temprature, Weather_Condition, Price_Per_Cup, Pitchers_Sold, Cost_Of_Pitcher, Cups_Sold, Pitchers_Available, Quality_Of_Supply, Player_Id) VALUES ({aReport.DayNumber}, {aReport.Net}, {aReport.Gross}, {aReport.WTemp}, '{aReport.WCondition}', {aReport.PricePerCup}, {aReport.PitchersSold}, {aReport.CostOfPitcher}, {aReport.CupsSold}, {aReport.PitchersAvailable}, '{aReport.QualityOfSupply}', {playerId})";

            try
            {
                SqlCommand myAdd = new SqlCommand(addQuery, mydb);
                myAdd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Inserting to Reports " + e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing Report Insert" + e);
                Console.ReadLine();
            }

        }

        public void InsertIntoLemons(List<Lemon> lemons, int playerId, int day)
        {
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Openning Insert into Lemons " + e);
                Console.ReadLine();
            }



            try
            {
                string addQuery;
                foreach (Lemon lemon in lemons)
                {
                    addQuery = $"INSERT INTO dbo.Lemons (Shelf_Life, Person_Id, Day) VALUES ({lemon.ShelfLifeDays}, {playerId},{day})";
                    SqlCommand myAdd = new SqlCommand(addQuery, mydb);
                    myAdd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Inserting into Lemons " + e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing Lemon Insert" + e);
                Console.ReadLine();
            }

        }

        public void InsertIntoSugar(List<Sugar> sugar, int playerId, int day)
        {
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Opening Sugar Insert " + e);
                Console.ReadLine();
            }



            try
            {
                string addQuery;
                foreach (Sugar s in sugar)
                {
                    addQuery = $"INSERT INTO dbo.Sugar (Shelf_Life, Person_Id, Day) VALUES ({s.ShelfLifeDays}, {playerId},{day})";
                    SqlCommand myAdd = new SqlCommand(addQuery, mydb);
                    myAdd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert into Sugar " + e);
                Console.ReadLine();
            }


            try
            {
                mydb.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Closing Sugar Insert" + e);
                Console.ReadLine();
            }

        }
    }


}
