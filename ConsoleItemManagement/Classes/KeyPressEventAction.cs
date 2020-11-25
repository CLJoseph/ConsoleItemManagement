using System;
using System.Collections.Generic;
using System.Text;
using MockUserInput;

namespace ConsoleItemManagement.Classes
{
    public class KeyPressEventAction
    {
        private IUserKeyboardInput _keyin;

        public Action action;
        public Banner banner;

        public KeyPressEventAction()
        {
            _keyin = new ActualKeyboardInput();
            action = Action.noAction;
            banner = Banner.mainMenu;
        }
        public KeyPressEventAction(IUserKeyboardInput keyin)
        {
            _keyin = keyin;
            action = Action.noAction;
            banner = Banner.mainMenu;
        }

        public Action onKeyPress()
        {
            char keyPressed = _keyin.readKey();
            switch (banner)
            {
                case Banner.mainMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return Action.showBannerAdd;
                        case 'b':
                        case 'B': return Action.showBannerList;
                        case 'c':
                        case 'C': return Action.showBannerTake;
                        case 'q':
                        case 'Q': return Action.returnTomainMenu;
                        default: return Action.noAction;
                    }
                case Banner.addMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return Action.addToStock;
                        case 'b':
                        case 'B': return Action.newStockItem;
                        case 'c':
                        case 'C': return Action.listStockLocations;
                        case 'q':
                        case 'Q': return Action.returnTomainMenu;
                        default: return Action.noAction;
                    }
                case Banner.takeMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return Action.takeFromStock;
                        case 'q':
                        case 'Q': return Action.returnTomainMenu;
                        default: return Action.noAction;
                    }
                case Banner.listMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return Action.listAllStock;
                        case 'b':
                        case 'B': return Action.listStockItems;
                        case 'c':
                        case 'C': return Action.listStockLocations;
                        case 'q':
                        case 'Q': return Action.returnTomainMenu;
                        default: return Action.noAction;
                    }
                default:
                    return Action.noAction;
            }
        }
    }
}
