using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class HighScore
    {
        List<string> hsNames = new List<string>();
        List<double> hsWallet = new List<double>();
        SqlConnection mydb = new SqlConnection("Server=LAPTOP-MR3G567K;Database=LemonadeHighScore;Integrated Security=true;");

        public void HighScoreList()
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
                string selectQuery = "SELECT TOP 5 Name, Wallet FROM dbo.High_Score ORDER BY Wallet desc";
                SqlCommand myCmd = new SqlCommand(selectQuery, mydb);
                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    hsNames.Add(myReader.GetString(0));
                    hsWallet.Add(double.Parse(myReader.GetSqlMoney(1).ToString()));
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
            catch
            {
                Console.WriteLine("Sorry problem closing the database");
                Console.ReadLine();
            }


            UserInterface.HighScoreList(hsNames,hsWallet);
        }
        public void AddHighScore(string name, double wallet)
        {
            try
            {
                mydb.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

            string addQuery = $"INSERT INTO dbo.High_Score (Name, Wallet) VALUES ('{name}', {wallet})";

            try
            {
                int count = 0;
                SqlCommand myAdd = new SqlCommand(addQuery, mydb);
                IAsyncResult result =  myAdd.BeginExecuteNonQuery();
                while (!result.IsCompleted)
                {
                    Console.WriteLine("Waiting for DB Write {0}", count++);
                    Thread.Sleep(1000);
                }
                myAdd.EndExecuteNonQuery(result);

                
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
            catch
            {
                Console.WriteLine("Sorry problem closing the database");
                Console.ReadLine();
            }

        }
    }
}
