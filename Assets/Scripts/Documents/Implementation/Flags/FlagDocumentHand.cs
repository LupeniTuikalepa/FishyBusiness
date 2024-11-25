using FishyBusiness.Data;
using LTX;
using UnityEngine;
using UnityEngine.UI;

namespace FishyBusiness.Documents.Flags
{
    public class FlagDocumentHand : MovableDocumentUI<FlagDocument>
    {
        [SerializeField]
        private FlagUI flagUIPrefab;

        [SerializeField]
        private Transform root;

        protected override void Bind(FlagDocument document)
        {
            base.Bind(document);
            root.ClearChildren();

            for (int i = 0; i < document.countries.Length; i++)
            {
                Country country = document.countries[i];
                FlagUI flagUI = Instantiate(flagUIPrefab, root);

                flagUI.SetInfos(country.name, country.Signature);
            }
        }
    }
}