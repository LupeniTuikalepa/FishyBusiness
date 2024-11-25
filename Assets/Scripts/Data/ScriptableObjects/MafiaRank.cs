using System.Collections.Generic;
using UnityEngine;

namespace FishyBusiness.Data
{
    [CreateAssetMenu(fileName = "Country", menuName = "FishyBusiness/Data/MafiaRank")]
    public class MafiaRank : ScriptableObject
    {
        public int maxSlot;
        public int actualSlot;
        public Dictionary<string, List<Sprite>> sprites = new Dictionary<string, List<Sprite>>();
    }
}