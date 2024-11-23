using FishyBusiness.Documents.UI;

namespace FishyBusiness.Documents.DeskSprite
{
    public class DocumentSprite<T> : DocumentVisual<T> where T : IDocument
    {
        protected override void OnSelected()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnUnselected()
        {
            throw new System.NotImplementedException();
        }
    }
}