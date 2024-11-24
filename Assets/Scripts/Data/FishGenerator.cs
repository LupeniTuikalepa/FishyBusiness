using System.Collections.Generic;
using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Helpers
{
    public class FishGenerator
    {
        private string[] fishNamesBuffer;
        private string[] mafiaTitlesBuffer;
        private string[] adjectivesBuffer;
        private string[] epithetsBuffer;
        private string[] countryBuffer;
        private string[] mafiaBuffer;
        private string[] rankBuffer;

        public FishGenerator()
        {
            fishNamesBuffer = new string[]
            {
                "Guppy", "Salmon", "Tuna", "Trout", "Shark", "Marlin", "Barracuda", "Mackerel", "Carp", "Cod"
            };

            mafiaTitlesBuffer = new string[]
            {
                "The Boss", "Big Fin", "The Don", "Little Scale", "Gold Gill", "Silent Stream", "The Reef", "The Harpoon", "Deep Diver", "The Kraken"
            };

            adjectivesBuffer = new string[]
            {
                "Slimy", "Scaly", "Dangerous", "Vicious", "Silver", "Dark", "Deadly", "Fast", "Sharp", "Stealthy"
            };

            epithetsBuffer = new string[]
            {
                "of the Abyss", "of the Coral Mafia", "from the Deep", "of the Ocean Lords", "of the Underwater Syndicate", 
                "of the Reef Gang", "of the Hidden Current", "from the Dark Depths"
            };

            countryBuffer = new string[]
            {
                "France", "Canada", "Japan", "Brazil", "Australia", "Germany", "India", "South Korea",
                "United States", "South Africa", "Argentina", "Sweden", "Mexico", "Italy", "China",
                "Norway", "Egypt", "New Zealand", "United Kingdom", "Russia"
            };

            mafiaBuffer = new string[]
            {
                "Sharko", "Narvalo", "Delpho", "Orcato"
            };

            rankBuffer = new string[]
            {
                "Boss",
                "Underboss",
                "Caporegime",
                "Associate",
                "Recruit"
            };
        }
        
        private string GenerateMafiaFishName()
        {
            string fishName = fishNamesBuffer[Random.Range(0, fishNamesBuffer.Length)];
            string mafiaTitle = mafiaTitlesBuffer[Random.Range(0, mafiaTitlesBuffer.Length)];
            string adjective = adjectivesBuffer[Random.Range(0, adjectivesBuffer.Length)];
            string epithet = epithetsBuffer[Random.Range(0, epithetsBuffer.Length)];

            return $"{adjective} {fishName}";
        }
        
        public Fish GenerateFish()
        {
            Fish fish = new Fish();
            fish.ID = GetHashCode();
            fish.Name = GenerateMafiaFishName();
            fish.IDCard = new IDCard
            {
                ID = fish.ID,
                Age = Random.Range(17, 38),
                Country = countryBuffer[Random.Range(0, countryBuffer.Length)],
                Mafia = mafiaBuffer[Random.Range(0, mafiaBuffer.Length)],
                Rank = rankBuffer[Random.Range(0, rankBuffer.Length)],
                ExpiryDate = $"{Random.Range(1, 30)}/{Random.Range(1, 12)}/{Random.Range(2020, 2028)}",
                
            };
            return fish;
        }
        
        public Fish GenerateFish(string mafia)
        {
            Fish fish = new Fish();
            fish.ID = GetHashCode();
            fish.Name = GenerateMafiaFishName();
            fish.IDCard = new IDCard
            {
                ID = fish.ID,
                Age = Random.Range(17, 38),
                Country = countryBuffer[Random.Range(0, countryBuffer.Length)],
                Mafia = mafia,
                Rank = rankBuffer[Random.Range(0, rankBuffer.Length)],
                ExpiryDate = $"{Random.Range(1, 30)}/{Random.Range(1, 12)}/{Random.Range(2020, 2028)}",
                
            };
            return fish;
        }
    }
}