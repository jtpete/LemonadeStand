using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        private int currentTemp;
        public int CurrentTemp { get { return currentTemp; } }
        private string currentCondition;
        public string CurrentCondition { get { return currentCondition; } }
        string[] allConditions = new string[10];
        int[] allTemps = new int[10];
        private List<int> fiveDayTemps = new List<int> { };
        public List<int> FiveDayTemps { get { return fiveDayTemps; } }
        private List<string> fiveDayConditions = new List<string> { };
        public List<string> FiveDayConditions { get { return fiveDayConditions; } }

        public Weather()
        {
            allConditions[0] = "Sunny";
            allConditions[1] = "Cloudy";
            allConditions[2] = "Breezy";
            allConditions[3] = "Overcast";
            allConditions[4] = "Rainy";
            allConditions[5] = "Partly Sunny";
            allConditions[6] = "Foggy";
            allConditions[7] = "Humid";
            allConditions[8] = "Light Breeze";
            allConditions[9] = "Mostly Sunny";

            allTemps[0] = 80;
            allTemps[1] = 76;
            allTemps[2] = 55;
            allTemps[3] = 84;
            allTemps[4] = 93;
            allTemps[5] = 62;
            allTemps[6] = 100;
            allTemps[7] = 79;
            allTemps[8] = 83;
            allTemps[9] = 91;

            FillForcast();

        }

        private void FillForcast()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                fiveDayTemps.Add(allTemps[rand.Next(0, 10)]);
                fiveDayConditions.Add(allConditions[rand.Next(0, 10)]);
            }
            currentCondition = allConditions[rand.Next(0, 10)];
            currentTemp = allTemps[rand.Next(0, 10)];
        }

        public void AdvanceForcast()
        {
            currentTemp = fiveDayTemps.First();
            FiveDayTemps.RemoveAt(0);
            currentCondition = fiveDayConditions.First();
            fiveDayConditions.RemoveAt(0);
            Random rand = new Random();
            fiveDayTemps.Add(allTemps[rand.Next(0, 10)]);
            fiveDayConditions.Add(allConditions[rand.Next(0, 10)]);
        }
    }
}
