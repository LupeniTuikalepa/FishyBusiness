using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerLink : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string screenName;
    [SerializeField] private int ID;

    private GameObject loadedScreen;

    [Header("References")]
    [SerializeField]
    private GameObject pfbScreenToLoad;
    [SerializeField]
        private Image icon;
    [SerializeField]
        private ComputerManager computerManager;

    [SerializeField]
    private Transform windowParent;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (loadedScreen != null)
        {
            loadedScreen.SetActive(true);
            loadedScreen.transform.SetAsLastSibling();
            loadedScreen.transform.localPosition = Vector3.zero;
            return;
        }

        GameObject newScreen = Instantiate(pfbScreenToLoad, windowParent);
        newScreen.name = screenName;
        newScreen.GetComponent<ScreenController>().Initialize(screenName, ID, computerManager);
        loadedScreen = newScreen;

        computerManager.AddIconToBar(icon.sprite, loadedScreen, ID);
    }
}