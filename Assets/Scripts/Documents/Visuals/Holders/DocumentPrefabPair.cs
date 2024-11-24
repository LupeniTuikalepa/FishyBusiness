
using UnityEngine;

namespace FishyBusiness.Documents.Visuals.Holders
{
    [System.Serializable]
    public struct DocumentPrefabPair
    {
        //Valeur
        [field: SerializeField]
        public GameObject Prefab { get; private set; }

        //Clef
        [field: SerializeField]
        public DocumentType DocumentType { get; private set; }
    }
}