using ConsoleItemManagement.Classes;
using System;

namespace ConsoleItemManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            stockManager.setstockItemsfile(".\\StockItems.json");
            stockManager.setstocklocationsfile(".\\StockLocations.json");
            stockManager.loadData();
            KeyPressEventAction UserKeyPress = new KeyPressEventAction();
            do
            {
                UserKeyPress.showBanner();
                UserKeyPress.action = UserKeyPress.onKeyPress();
                switch(UserKeyPress.action)
                {
                    case UserAction.noAction:
                        break;
                    case UserAction.showBannerAdd:
                        UserKeyPress.banner = Banner.addMenu;
                        break;
                    case UserAction.showBannerList:
                        UserKeyPress.banner = Banner.listMenu;
                        break;
                    case UserAction.showBannerTake:
                        UserKeyPress.banner = Banner.takeMenu;
                        break;
                    case UserAction.returnTomainMenu:
                        UserKeyPress.banner = Banner.mainMenu; 
                        break;
                    case UserAction.showBannerMain:
                        UserKeyPress.banner = Banner.mainMenu;
                        break;
                    case UserAction.addToStock:
                        stockManager.addToStock();
                        break;
                    case UserAction.newStockItem:
                        stockManager.newStockItem(); 
                        break;
                    case UserAction.newStockLocation:
                        stockManager.newStockLocation();
                        break;
                    case UserAction.listStockLocations:
                        stockManager.listStockLocations();
                        break;
                    case UserAction.takeFromStock:
                        stockManager.takeFromStock();
                        break;
                    case UserAction.listAllStock:
                        stockManager.listAllStock();
                        break;
                    case UserAction.listStockItems:
                        stockManager.listStockItems();
                        break;
                    case UserAction.quitApplication:
                        break;
                    default:
                        break;
                }
            } while (UserKeyPress.action != UserAction.quitApplication);
            stockManager.saveData();
        }
    }
}
