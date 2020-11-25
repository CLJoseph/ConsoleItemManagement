using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleItemManagement.Classes
{
    public enum Action { noAction, showBannerAdd, showBannerList, showBannerTake, returnTomainMenu, addToStock, newStockItem, listStockLocations, takeFromStock, listAllStock, listStockItems };
    public enum Banner { mainMenu, addMenu, takeMenu, listMenu };
}
