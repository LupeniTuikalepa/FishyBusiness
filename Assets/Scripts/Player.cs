using System;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness.Core
{
    public class Player : MonoBehaviour
    {
        public Desk Desk { get; private set; }

        private void Awake()
        {
            Desk = new Desk();
        }
    }
}