using System;
using FishyBusiness.Documents.UI;

namespace FishyBusiness.Documents.Visuals.Holders
{
    public interface IDeskDocument : IDocumentVisual
    {
        event Action<IDeskDocument> OnSelected;
    }
}