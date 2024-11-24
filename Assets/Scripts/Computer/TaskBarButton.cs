using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TaskBarButton : MonoBehaviour,IPointerClickHandler
{
    private GameObject screen;
    private int ID;

    public void Initialize(Sprite icon, GameObject screen, int ID)
    {
        GetComponent<Image>().sprite = icon;
        this.screen = screen;
        this.ID = ID;
    }

    public void OnPointerClick(PointerEventData eventData) =>
        screen.GetComponent<ScreenController>().ToggleVisibility();

    public int GetID()
    {
        return ID;
    }
}
