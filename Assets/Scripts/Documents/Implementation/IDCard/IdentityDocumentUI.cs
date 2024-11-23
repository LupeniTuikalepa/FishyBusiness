using FishyBusiness.Documents.UI;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace FishyBusiness
{
    public class IdentityDocumentUI : DocumentUI<IdentityDocument>
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
            birthPlaceTmp.text = document.birthPlace.ToString();

            nationalityTmp.text = document.country.Nationality;
            mafiaSignature.texture = document.country.Signature;

            mafiaRankTmp.text = document.mafiaRank.name;
            mafiaNameTmp.text = document.mafia.name;
            countrySignature.texture = document.mafia.Signature;

        }

        protected override void Unbind(IdentityDocument document)
        {
            base.Unbind(document);
        }
    }
}