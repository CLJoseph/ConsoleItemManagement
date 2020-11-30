using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleItemManagement.Classes
{
    public enum UserAction { noAction, showBannerAdd, showBannerList, showBannerTake, returnTomainMenu, addToStock, newStockItem, listStockLocations, takeFromStock, listAllStock, listStockItems, quitApplication, newStockLocation, showBannerMain };
    public enum Banner { mainMenu, addMenu, takeMenu, listMenu };
}
