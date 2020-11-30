using System;
using System.Collections.Generic;
using System.Text;
using MockUserInput;

namespace ConsoleItemManagement.Classes
{
    public class KeyPressEventAction
    {
        private IUserKeyboardInput _keyin;
        public UserAction action;
        public Banner banner;
        private string bannermainMenu = "";
        private string banneraddMenu = "";
        private string bannertakeMenu = "";
        private string bannerlistMenu = "";
        public KeyPressEventAction()
        {
            _keyin = new ActualKeyboardInput();
            action = UserAction.showBannerMain;
            ConstructBanners();
            banner = Banner.mainMenu;
        }
        public KeyPressEventAction(IUserKeyboardInput keyin)
        {
            _keyin = keyin;
            action = UserAction.noAction;
            ConstructBanners();
        }
        private void ConstructBanners()
        {
            banner = Banner.mainMenu;
            bannermainMenu += " Main menu \n";
            bannermainMenu += " ========= \n";
            bannermainMenu += " press key to select menu  \n";
            bannermainMenu += " A - Add    L - List  T - Take   Q - Quit application   \n";
            bannermainMenu += " ----------------------------------------------------   \n";

            banneraddMenu += " Add menu \n";
            banneraddMenu += " ======== \n";
            banneraddMenu += " press key to select action  \n";
            banneraddMenu += " A - Add item to stock        L - add new stock location     \n";
            banneraddMenu += " I - Add new stock item       R - return to main menu   \n";
            banneraddMenu += " ------------------------------------------------------ \n";

            bannertakeMenu += " Take menu \n";
            bannertakeMenu += " ======== \n";
            bannertakeMenu += " press key to select action  \n";
            bannertakeMenu += " T - take item from stock    R - return to main menu\n";
            bannertakeMenu += " ---------------------------------------------------\n";

            bannerlistMenu += " List menu \n";
            bannerlistMenu += " ======== \n";
            bannerlistMenu += " press key to select action                                \n";
            bannerlistMenu += " A - List all items in stock                               \n";
            bannerlistMenu += " I - List stock Items            L - list stock locations  \n";
            bannerlistMenu += " R - return to main menu                                   \n";
            bannerlistMenu += " --------------------------------------------------------  \n";
        }
        public UserAction onKeyPress()
        {
            char keyPressed = _keyin.readKey();
            switch (banner)
            {
                case Banner.mainMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return UserAction.showBannerAdd;
                        case 'l':
                        case 'L': return UserAction.showBannerList;
                        case 't':
                        case 'T': return UserAction.showBannerTake;
                        case 'q':
                        case 'Q': return UserAction.quitApplication;
                        default: return UserAction.noAction;
                    }
                case Banner.addMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return UserAction.addToStock;
                        case 'i':
                        case 'I': return UserAction.newStockItem;
                        case 'l':
                        case 'L': return UserAction.newStockLocation;
                        case 'r':
                        case 'R': return UserAction.returnTomainMenu;
                        default: return UserAction.noAction;
                    }
                case Banner.takeMenu:
                    switch (keyPressed)
                    {
                        case 't':
                        case 'T': return UserAction.takeFromStock;
                        case 'r':
                        case 'R': return UserAction.returnTomainMenu;
                        default: return UserAction.noAction;
                    }
                case Banner.listMenu:
                    switch (keyPressed)
                    {
                        case 'a':
                        case 'A': return UserAction.listAllStock;
                        case 'i':
                        case 'I': return UserAction.listStockItems;
                        case 'l':
                        case 'L': return UserAction.listStockLocations;
                        case 'r':
                        case 'R': return UserAction.returnTomainMenu;
                        default: return UserAction.noAction;
                    }
                default:
                    return UserAction.noAction;
            }
        }
        public void showBanner() 
        {
            if (action == UserAction.noAction) { return; }
            switch (banner)
            {
                case Banner.mainMenu:
                    Console.WriteLine(bannermainMenu);
                    break;
                case Banner.addMenu:
                    Console.WriteLine(banneraddMenu);
                    break;
                case Banner.takeMenu:
                    Console.WriteLine(bannertakeMenu);
                    break;
                case Banner.listMenu:
                    Console.WriteLine(bannerlistMenu);
                    break;
                default:
                    break;
            }
        }
    }
}
