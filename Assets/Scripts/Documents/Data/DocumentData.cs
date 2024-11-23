using System;
using UnityEngine;

namespace FishyBusiness.Documents.Data
{
    [CreateAssetMenu(fileName = "Document", menuName = "FishyBusiness/Document")]
    public class DocumentData : ScriptableObject
    {
        [field: SerializeField]
        public GameObject VisualPrefab { get; private set; }
    }
}