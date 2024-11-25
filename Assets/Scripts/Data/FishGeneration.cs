using System;
using System.Collections.Generic;
using FishyBusiness.Data;
using FishyBusiness.GameSystem.Sample.Tablet;
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

            return $"{adjective} {fishName}";
        }

        public static Fish GenerateFish()
        {
            GameDatabase gameDatabase = GameController.GameDatabase;

            Mafia mafia = gameDatabase.Mafias[Random.Range(0, gameDatabase.Mafias.Length)];
            MafiaRank rank = gameDatabase.MafiaRanks[Random.Range(0, gameDatabase.MafiaRanks.Length)];

            return GenerateFish(mafia, rank);
        }

        public static Fish GenerateFish(Mafia mafia, MafiaRank mafiaRank)
        {
            GameMetrics gameMetrics = GameMetrics.Global;
            GameDatabase gameDatabase = GameController.GameDatabase;

            Fish fish = new Fish()
            {
                id = Guid.NewGuid().ToString(),
                image = gameDatabase.FishKeyArts[Random.Range(0, gameDatabase.FishKeyArts.Length)],
                name = GenerateMafiaFishName(),
                birthYear = Random.Range(gameMetrics.Year - gameMetrics.MaxFishAge, gameMetrics.Year),
                expiryDate = 2024 + Random.Range(1, 7),

                birthCountry = gameDatabase.Countries[Random.Range(0, gameDatabase.Countries.Length)],
                mafia = mafia,
                rank = mafiaRank,
            };
            return fish;
        }

        public static Fish AlterFish(Fish fish)
        {
            int index = Random.Range(1, 4);
            switch (index)
            {
                case 1:
                    fish.expiryDate = 2024 - Random.Range(1, 4);
                    break;
                case 2:
                    fish.birthYear += Random.Range(1, 4);
                    break;
                case 3:
                    fish.rank = GameDatabase.GetDiffMafiaRank(fish.rank.ToString());
                    break;
            }

            return fish;
        }
    }
}