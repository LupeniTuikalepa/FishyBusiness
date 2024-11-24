using UnityEngine;

namespace FishyBusiness.Fishes
{
    [System.Serializable]
    public struct FishPair
    {
        [field: SerializeField]
        public FishType FishType { get; private set; }
        [field: SerializeField]
        public FishFood FishFood { get; private set; }
    }
}