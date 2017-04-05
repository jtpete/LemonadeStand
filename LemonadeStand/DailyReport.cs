using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class DailyReport
    {
        private int dayNumber;
        public int DayNumber { get { return dayNumber; } set { dayNumber = value; } }
        private int wTemp;
        public int WTemp { get { return wTemp; } set { wTemp = value; } }
        private string wCondition;
        public string WCondition { get { return wCondition; } set { wCondition = value; } }
        private string sellerName;
        public string SellerName { get { return sellerName; } set { sellerName = value; } }

        private int pitchersSold;
        public int PitchersSold { get { return pitchersSold; } set { pitchersSold = value; } }

        private double pricePerCup;
        public double PricePerCup { get { return pricePerCup; } set { pricePerCup = value; } }

        private double gross;
        public double Gross { get { return gross; } set { gross = value; } }

        private double net;
        public double Net { get { return net; } set { net = value; } }

        private double costOfPitcher;
        public double CostOfPitcher { get { return costOfPitcher; } set { costOfPitcher = value; } }

        private int pitchersAvailable;
        public int PitchersAvailable { get { return pitchersAvailable; } set { pitchersAvailable = value; } }

        private int cupsSold;
        public int CupsSold { get { return cupsSold; } set { cupsSold = value; } }

        private int crowdCount;
        public int CrowdCount { get { return crowdCount; } set { crowdCount = value; } }

        private string qualityOfSupply;
        public string QualityOfSupply { get { return qualityOfSupply; } set { qualityOfSupply = value; } }

    }
}
