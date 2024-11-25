using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public readonly struct IdentityDocument : IDocument
    {
        public DocumentType DocumentType => DocumentType.IDCard;

        public readonly string name;
        public readonly int birthYear;
        public readonly int expireDate;

        public readonly Mafia mafia;
        public readonly MafiaRank mafiaRank;

        public readonly Country birthCountry;

        public IdentityDocument(IIdentityDocumentInfos infos)
        {
            name = infos.Name;
            birthYear = infos.BirthYear;
            expireDate = infos.ExpireDate;

            birthCountry = infos.BirthCountry;

            mafia = infos.Mafia;
            mafiaRank = infos.MafiaRank;
        }

    }
}