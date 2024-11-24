using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness
{
    public class GameDatabase
    {
        public static GameDatabase Global = new GameDatabase();
        public Country[] Countries { get; private set; }
        public Mafia[] Mafias { get; private set; }
        public MafiaRank[] MafiaRanks { get; private set; }
        public Sprite[] FishKeyArts { get; private set; }

        public GameDatabase()
        {
            Countries = Resources.LoadAll<Country>("Countries");
            Mafias = Resources.LoadAll<Mafia>("Mafias");
            MafiaRanks = Resources.LoadAll<MafiaRank>("Mafias/Ranks");
            FishKeyArts = Resources.LoadAll<Sprite>("Fishes");
        }
    }
}