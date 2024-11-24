using System.Collections.Generic;
using FishyBusiness.MenuSystem.MenuData;
using LTX.Singletons;
using UnityEngine;

namespace FishyBusiness.MenuSystem
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        [SerializeField] private BaseMenu[] menus;
        private readonly Dictionary<string, BaseMenu> menusDict = new Dictionary<string, BaseMenu>();
        private BaseMenu currentMenu;
        
        protected override void Awake()
        {
            base.Awake();
            
            foreach (BaseMenu menu in menus)
            {
                if (menu)
                {
                    menusDict[menu.MenuID] = menu;
                }
            }
        }

        public void OpenMenu(string menuName)
        {
            if (menusDict.TryGetValue(menuName, out BaseMenu menu))
            {
                if (menu == currentMenu)
                {
                    CloseCurrentMenu();
                    return;
                }
                
                menu.Open();
                currentMenu = menu;
                return;
            }
            
            Debug.LogError("Menu not found.");
        }

        public bool TryGetMenu(string menuName, out BaseMenu returnedMenu)
        {
            if (menusDict.TryGetValue(menuName, out returnedMenu))
            {
                return true;
            }

            Debug.LogError("Menu not found.");
            return default;
        }

        public void CloseCurrentMenu()
        {
            currentMenu?.Close();
            currentMenu = default;
        }
        
        public void ChangeScene(int sceneIndex)
        {
            GameController.SceneController.LoadScene(sceneIndex);
        }
    }
}