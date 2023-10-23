using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Prize
    {
        /// <summary>
        /// Unique ID of the Prize
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Place number for the Prize
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Place name for the Prize
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Amount of the Prize
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Percentage of the total for the Prize
        /// </summary>
        public double PrizePercentage { get; set; }

        public Prize()
        {

        }

        public Prize(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int.TryParse(placeNumber, out int placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal.TryParse(prizeAmount, out decimal prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double.TryParse(prizePercentage, out double prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }

    }
}
