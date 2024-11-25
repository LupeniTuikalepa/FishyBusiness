using System;
using UnityEngine;

namespace FishyBusiness.Documents.Visuals.Holders
{
    public class Hand : DocumentsHolderVisual<IHandDocument>
    {
        private void OnEnable()
        {
            Bind(Player.Instance.Hand);
        }

        private void OnDisable()
        {
            Bind(Player.Instance.Hand);
        }
    }
}