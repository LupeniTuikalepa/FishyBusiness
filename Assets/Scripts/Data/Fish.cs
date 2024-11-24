using System;
using FishyBusiness.Documents;
using UnityEngine;

namespace FishyBusiness.Data
{
    public struct Fish : IIdentityDocumentInfos
    {
        public Sprite image;

        public int id;
        public string name;

        public int birthYear;
        public int expiryDate;

        public Country birthCountry;
        public Country nationality;

        public Mafia mafia;
        public MafiaRank rank;

        string IIdentityDocumentInfos.Name => name;
        int IIdentityDocumentInfos.BirthYear => birthYear;
        Country IIdentityDocumentInfos.BirthCountry => birthCountry;
        Mafia IIdentityDocumentInfos.Mafia => mafia;
        MafiaRank IIdentityDocumentInfos.MafiaRank => rank;
        Country IIdentityDocumentInfos.Nationality => nationality;
        int IIdentityDocumentInfos.ExpireDate => expiryDate;

        public override string ToString()
        {
            return "Fish : " +
                   $" \n - {nameof(id)}: {id}," +
                   $" \n - {nameof(name)}: {name}," +
                   $" \n - {nameof(birthYear)}: {birthYear}, " +
                   $" \n - {nameof(expiryDate)}: {expiryDate}," +
                   $" \n - {nameof(birthCountry)}: {birthCountry}, " +
                   $" \n - {nameof(nationality)}: {nationality}, " +
                   $" \n - {nameof(mafia)}: {mafia}, {nameof(rank)}: ";
        }
    }
}