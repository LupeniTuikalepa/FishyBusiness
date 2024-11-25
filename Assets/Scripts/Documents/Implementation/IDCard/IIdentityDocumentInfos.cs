using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public interface IIdentityDocumentInfos
    {
        string Name { get; }
        int BirthYear { get; }
        Country BirthCountry { get; }

        Sprite Photo { get; }

        Mafia Mafia { get; }
        MafiaRank MafiaRank { get; }

        int ExpireDate { get; }
    }
}