using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBar : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRectTransform;
    private Vector2 offset;

    private void Start()
    {
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.parent.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out offset
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentRectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint
            ))
        {
            parentRectTransform.anchoredPosition += (Vector2)eventData.delta;
        }
    }
}