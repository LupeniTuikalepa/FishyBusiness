using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public readonly struct IdentityDocument : IDocument
    {
        public DocumentType DocumentType => DocumentType.IDCard;

        public readonly string name;
        public readonly int birthYear;
        public readonly BirthPlace birthPlace;

        public readonly Mafia mafia;
        public readonly MafiaRank mafiaRank;

        public readonly Country country;

        public IdentityDocument(IIdentityDocumentInfos infos)
        {
            name = infos.Name;
            birthYear = infos.BirthYear;
            birthPlace = infos.BirthPlace;

            mafia = infos.Mafia;
            mafiaRank = infos.MafiaRank;

            country = infos.Country;
        }

    }
}