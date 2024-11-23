using System;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness
{
    public partial class Player : MonoBehaviour
    {
        public DocumentsHolder DocumentsHolder { get; private set; }

        private void Awake()
        {
            DocumentsHolder = new DocumentsHolder();

        }
    }
}