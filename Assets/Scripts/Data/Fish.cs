using System;
using UnityEngine;

namespace FishyBusiness.Data
{
    public struct Fish
    {
        public int ID;
        public string Name;
        public IDCard IDCard;
    }

    public struct IDCard
    {
        public int ID;
        public Sprite Pic;
        public int Age;
        public string Country;
        public string Mafia;
        public string Rank;
        public string ExpiryDate;
        public Sprite CountrySignature;
        public Sprite MafiaSignature;
    }
}