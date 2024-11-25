using System;
using FishyBusiness.Documents.UI;
using FishyBusiness.Documents.Visuals.Holders;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace FishyBusiness.Documents
{
    public class IdentityDocumentUI : DocumentVisual<IdentityDocument>, IHandDocument
    {
        [SerializeField]
        private TextMeshProUGUI nameTmp;
        [SerializeField]
        private TextMeshProUGUI birthYearTmp;

        [Space]
        [SerializeField]
        private TextMeshProUGUI birthPlaceTmp;
        [SerializeField]
        private TextMeshProUGUI nationalityTmp;

        [Space]
        [SerializeField]
        private TextMeshProUGUI mafiaNameTmp;
        [SerializeField]
        private TextMeshProUGUI mafiaRankTmp;

        [Space]
        [SerializeField]
        private RawImage mafiaSignature;
        [SerializeField]
        private RawImage countrySignature;

        protected override void Bind(IdentityDocument document)
        {
            base.Bind(document);

            nameTmp.text = document.name;
            birthYearTmp.text = document.birthYear.ToString();
            birthPlaceTmp.text = document.birthCountry.name;

            nationalityTmp.text = document.birthCountry.Nationality;
            mafiaSignature.texture = document.mafia.Signature;

            mafiaRankTmp.text = document.mafiaRank.name;
            mafiaNameTmp.text = document.mafia.name;
            countrySignature.texture = document.mafia.Signature;

        }

        protected override void Unbind(IdentityDocument document)
        {
            base.Unbind(document);
        }

        public void Unselect()
        {
            Player.Instance.Deselect(this);
        }

    }
}