using System;
using FishyBusiness.Documents.Data;
using UnityEngine;

namespace FishyBusiness.Documents
{

    public interface IDocument
    {
        DocumentData Data { get; }
    }
}