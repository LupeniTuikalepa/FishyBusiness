using System.Linq;
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

        public static MafiaRank GetDiffMafiaRank(string mafiaRank)
        {
            var availableRanks = GameDatabase.Global.MafiaRanks
                .Where(rank => rank.name != mafiaRank)
                .ToArray();
            
            return availableRanks[Random.Range(0, availableRanks.Length)];
        }
        
        public static Mafia GetMafia(string mafiaName)
        {
            return Global.Mafias.First(mafia => mafia.name == mafiaName);
        }

        public static MafiaRank GetRank(string rankName)
        {
            return Global.MafiaRanks.First(rank => rank.name == rankName);
        }
    }
}