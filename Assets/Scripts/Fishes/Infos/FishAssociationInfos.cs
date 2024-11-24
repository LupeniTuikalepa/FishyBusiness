using UnityEngine;

namespace FishyBusiness.Fishes
{
    [System.Serializable]
    public struct FishAssociationInfos
    {
        [field: SerializeField]
        public FishType FishType { get; private set; }
        [field: SerializeField]
        public FishFood FishFood { get; private set; }

        [field: SerializeField, Range(0, 200)]
        public int QuotaInfluence { get; private set; }

        [field: SerializeField, Range(0, 3)]
        public int LifeInfluence { get; private set; }

        [field: SerializeField, Range(0, 200)]
        public int MoneyInfluence { get; private set; }
    }
}