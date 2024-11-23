using System;
using UnityEngine;

namespace FishyBusiness.Data
{
    [CreateAssetMenu(fileName = "Document", menuName = "FishyBusiness/Document")]
    public class DocumentData : ScriptableObject
    {
        [field: SerializeField]
        public GameObject UIPrefab { get; private set; }
    }
}