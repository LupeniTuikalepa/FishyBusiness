using UnityEngine;

namespace FishyBusiness.Data
{
    [CreateAssetMenu(fileName = "Mafia", menuName = "FishyBusiness/Data/Mafia")]
    public class Mafia : ScriptableObject
    {
        [field: SerializeField]
        public Texture Signature { get; private set; }
    }
}