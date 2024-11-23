using UnityEngine;
using UnityEngine.EventSystems;

public class ContentWindow : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) => transform.parent.SetAsLastSibling();
    
}
