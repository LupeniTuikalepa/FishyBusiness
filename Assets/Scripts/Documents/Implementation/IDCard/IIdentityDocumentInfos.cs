using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{
    public interface IIdentityDocumentInfos
    {
        string Name { get; }
        int BirthYear { get; }
        BirthPlace BirthPlace { get; }


        Mafia Mafia { get; }
        MafiaRank MafiaRank { get; }

        Country Country { get; }
    }
}