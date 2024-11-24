using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using Random = UnityEngine.Random;

namespace FishyBusiness.Helpers
{
    public static class FishGeneration
    {
        private static readonly string[] FishNamesBuffer = new string[]
        {
            "Guppy",
            "Salmon",
            "Tuna",
            "Trout",
            "Shark",
            "Marlin",
            "Barracuda",
            "Mackerel",
            "Carp",
            "Cod"
        };
        private static readonly string[] MafiaTitlesBuffer = new string[]
        {
            "The Boss",
            "Big Fin",
            "The Don",
            "Little Scale",
            "Gold Gill",
            "Silent Stream",
            "The Reef",
            "The Harpoon",
            "Deep Diver",
            "The Kraken"
        };

        private static readonly string[] AdjectivesBuffer = new string[]
        {
            "Slimy",
            "Scaly",
            "Dangerous",
            "Vicious",
            "Silver",
            "Dark",
            "Deadly",
            "Fast",
            "Sharp",
            "Stealthy"
        };

        private static readonly string[] EpithetsBuffer = new string[]
        {
            "of the Abyss",
            "of the Coral Mafia",
            "from the Deep",
            "of the Ocean Lords",
            "of the Underwater Syndicate",
            "of the Reef Gang",
            "of the Hidden Current",
            "from the Dark Depths"
        };


        private static string GenerateMafiaFishName()
        {
            string fishName = FishNamesBuffer[Random.Range(0, FishNamesBuffer.Length)];
            string mafiaTitle = MafiaTitlesBuffer[Random.Range(0, MafiaTitlesBuffer.Length)];
            string adjective = AdjectivesBuffer[Random.Range(0, AdjectivesBuffer.Length)];
            string epithet = EpithetsBuffer[Random.Range(0, EpithetsBuffer.Length)];

            return $"{adjective} {fishName}, {mafiaTitle} {epithet}";
        }

        public static Fish GenerateFish()
        {
            GameMetrics gameMetrics = GameMetrics.Global;
            GameDatabase gameDatabase = GameController.GameDatabase;

            Fish fish = new Fish()
            {
                id = Guid.NewGuid().ToString(),
                name = GenerateMafiaFishName(),
                image = gameDatabase.FishKeyArts[Random.Range(0, gameDatabase.FishKeyArts.Length)],

                birthYear = Random.Range(gameMetrics.Year - gameMetrics.MaxFishAge, gameMetrics.Year),
                expiryDate = Random.Range(gameMetrics.ExpirationDateRange.x, gameMetrics.ExpirationDateRange.y),

                birthCountry = gameDatabase.Countries[Random.Range(0, gameDatabase.Countries.Length)],
                nationality = gameDatabase.Countries[Random.Range(0, gameDatabase.Countries.Length)],
                mafia = gameDatabase.Mafias[Random.Range(0, gameDatabase.Mafias.Length)],
                rank = gameDatabase.MafiaRanks[Random.Range(0, gameDatabase.MafiaRanks.Length)],
            };
            return fish;
        }
        
        public static Data.Fish GenerateFish(string mafiaName)
        {
            GameMetrics gameMetrics = GameMetrics.Global;
            GameDatabase gameDatabase = GameController.GameDatabase;

            Data.Fish fish = new Data.Fish()
            {
                id = Guid.NewGuid().ToString(),
                name = GenerateMafiaFishName(),
                birthYear = Random.Range(gameMetrics.Year - gameMetrics.MaxFishAge, gameMetrics.Year),
                expiryDate = Random.Range(gameMetrics.ExpirationDateRange.x, gameMetrics.ExpirationDateRange.y),

                birthCountry = gameDatabase.Countries[Random.Range(0, gameDatabase.Countries.Length)],
                nationality = gameDatabase.Countries[Random.Range(0, gameDatabase.Countries.Length)],
                mafia = gameDatabase.Mafias[Random.Range(0, gameDatabase.Mafias.Length)],
                rank = gameDatabase.MafiaRanks[Random.Range(0, gameDatabase.MafiaRanks.Length)],
            };
            return fish;
        }
    }
}