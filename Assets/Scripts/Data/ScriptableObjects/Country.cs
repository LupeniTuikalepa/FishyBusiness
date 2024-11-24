using UnityEngine;

namespace FishyBusiness.Data
{
    [CreateAssetMenu(fileName = "Country", menuName = "FishyBusiness/Data/Country")]
    public class Country : ScriptableObject
    {
        [field: SerializeField]
        public Texture Signature { get; private set; }

        [field: SerializeField]
        public string Nationality { get; private set; }
    }
}