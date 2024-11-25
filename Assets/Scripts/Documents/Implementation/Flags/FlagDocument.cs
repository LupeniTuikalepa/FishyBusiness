using FishyBusiness.Data;

namespace FishyBusiness.Documents.Flags
{
    public struct FlagDocument : IDocument
    {
        public readonly Country[] countries;
        public DocumentType DocumentType => DocumentType.Flags;

        public FlagDocument(Country[] countries)
        {
            this.countries = countries;
        }
    }
}