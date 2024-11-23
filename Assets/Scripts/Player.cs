using System;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness
{
    public partial class Player : MonoBehaviour
    {
        public Desk Desk { get; private set; }

        private void Awake()
        {
            Desk = new Desk();
        }
    }
}