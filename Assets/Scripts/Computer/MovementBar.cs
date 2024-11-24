using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBar : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.parent.SetAsLastSibling();
    }
}