using UnityEngine;

namespace FishyBusiness.MenuSystem.MenuData
{
    public class BaseMenu : MonoBehaviour
    {
        public string MenuID => name;
        public bool IsOpen { get; private set; }
        
        public void Open()
        {
            gameObject.SetActive(true);
            IsOpen = true;
        }

        public void Close()
        {
            gameObject.SetActive(false);
            IsOpen = false;
        }
    }
}