using System;
using FishyBusiness.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{

    public interface IDocument
    {
        event Action OnSelected;
        event Action OnUnselected;

        DocumentData Data { get; }
    }
}