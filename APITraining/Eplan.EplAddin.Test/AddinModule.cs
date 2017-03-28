using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Gui;

namespace Eplan.EplAddin.Test
{
    public class AddinModule : IEplAddIn
    {
        public bool OnExit()
        {
            return true;
        }

        public bool OnInit()
        {
            return true;
        }

        public bool OnInitGui()
        {
            Menu menu = new Menu();
            var menuId = menu.AddMainMenu("Test", Menu.MainMenuName.eMainMenuOptions, "Login", "ActionLogin", "Test Login Menu...", 1);
            menuId = menu.AddMenuItem("Checkin", "ActionCheckin", "", menuId, 1, true, true);
            menu.AddMenuItem("Checkout", "ActionCheckout", "", menuId, 2, false, false);

            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }
    }
}
