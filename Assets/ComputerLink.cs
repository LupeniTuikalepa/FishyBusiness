using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerLink : MonoBehaviour, IPointerClickHandler
{
    public string screenName;
    public GameObject pfbScreenToLoad;
    private GameObject loadedScreen;
    public int ID;

    public Image icon;
    
    public ComputerManager computerManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (loadedScreen != null)
        {
            loadedScreen.GetComponent<ScreenController>().ToggleVisibility();
            return;
        }

        GameObject newScreen = Instantiate(pfbScreenToLoad, transform.parent);
        newScreen.name = screenName;
        newScreen.GetComponent<ScreenController>().Initialize(screenName, ID, computerManager);
        loadedScreen = newScreen;
        
        computerManager.AddIconToBar(icon.sprite, loadedScreen, ID);
    }
}
