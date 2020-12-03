using MockUserInput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ConsoleItemManagement.Classes
{
    public class StockManager
    {
        public string stockItemsFile { get; set; }
        public string stockLocationsFile { get; set; }
        IUserKeyboardInput _keyboard;
        List<Item> StockItems = new List<Item>();
        List<Location> StockLocations = new List<Location>();
        public StockManager()
        {
            _keyboard = new ActualKeyboardInput();
        }
        public StockManager(IUserKeyboardInput keyboard)
        {
            _keyboard = keyboard;
        }
        public void setstockItemsfile(string filename)
        {
            stockItemsFile = filename;
        }
        public void setstocklocationsfile(string filename)
        {
            stockLocationsFile = filename;
        }
        /// <summary>
        /// Data is in Json format in a text file
        /// </summary>
        public void loadData()
        {
            LoadStockItems();
            LoadStockLocations();
        }
        public void saveData()
        {
            SaveStockItems();
            SaveStockLocations();
        }
        private void SaveStockItems()
        {
            using (StreamWriter writer = new StreamWriter(stockItemsFile))
            {
                // serialize stockitems into json and write the result to file.
                var Jsonoutput = JsonSerializer.Serialize<List<Item>>(StockItems);
                writer.WriteLine(Jsonoutput);
            }
        }
        public void addToStock()
        {
            var itemCode = GetItemCode();
            var Qty = _keyboard.getIntValue("Enter No of Items :");
            Location location = getLocation();
            location.Quantity += Qty;
        }
        public Location getLocation()
        {
            do
            {
                var code = _keyboard.read("Enter location code :");
                var toReturn = StockLocations.FirstOrDefault(x => x.code == code);
                if (toReturn != null)
                {
                    return toReturn;
                }
                else
                {
                    Console.WriteLine("Invalid Location code, try again.");
                }
            } while (true);
        }
        public void takeFromStock()
        {
            var itemCode = GetItemCode();
            var locations = StockLocations.Where(x => x.ItemCode == itemCode).ToList();
            if (locations.Count > 0)
            {
                foreach (var loc in locations)
                {
                    Console.WriteLine($"Location - {loc.code} has {loc.Quantity} of {loc.ItemCode} ");
                }
                var L = getLocation();
                do
                {
                    var Qty = _keyboard.getIntValue("Enter No of Items :");
                    if (Qty < L.Quantity)
                    {
                        L.Quantity = L.Quantity - Qty;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Quantity Entered. ");
                    }

                } while (true);
            }
        }
        public void listAllStock()
        {
            Console.WriteLine("-----  All Stock  ------");
            Console.WriteLine("Code     Item Code     Quantity     Value");
            foreach (var l in StockLocations)
            {
                var code = l.code.PadRight(8, ' ').Substring(0, 8);
                var itemcode = l.ItemCode.PadRight(8, ' ').Substring(0, 8);
                var Quantity = l.Quantity.ToString("0").PadRight(6, ' ').Substring(0, 6); ;
                var item = StockItems.FirstOrDefault<Item>(x => x.code == l.ItemCode);
                var value = (l.Quantity * item.value).ToString("0.00");
                Console.WriteLine($"{code} {itemcode}       {Quantity}      {value} ");
            }
            Console.WriteLine("--------------------------");
        }
        public void listStockLocations()
        {
            Console.WriteLine("-----   Stock Locations ------");
            Console.WriteLine("Code     Item Code ");
            foreach (var l in StockLocations)
            {
                var code = l.code.PadRight(8, ' ').Substring(0, 8);
                var itemcode = l.ItemCode.PadRight(8, ' ').Substring(0, 8);
                Console.WriteLine($"{code} {itemcode} ");
            }
            Console.WriteLine("--------------------------");
        }
        public void listStockItems()
        {
            Console.WriteLine("-----   Stock Items ------");
            Console.WriteLine("Code     Name                 Description                             Value");
            foreach (var l in StockItems)
            {
                var code = l.code.PadRight(8, ' ').Substring(0, 8);
                var description = l.description.PadRight(30, ' ').Substring(0, 30);
                var nam = l.name.PadRight(20, ' ').Substring(0, 20);
                var value = l.value.ToString("0,00");
                Console.WriteLine($"{code} {nam} {description} {value} ");
            }
            Console.WriteLine("--------------------------");
        }
        private void SaveStockLocations()
        {
            using (StreamWriter writer = new StreamWriter(stockLocationsFile))
            {
                // serialize stockitems into json and write the result to file.
                var Jsonoutput = JsonSerializer.Serialize<List<Location>>(StockLocations);
                writer.WriteLine(Jsonoutput);
            }
        }
        public void newStockLocation()
        {
            Console.WriteLine("Enter new Location details ---------------- ");
            Location location = new Location();
            location.Id = Guid.NewGuid();
            location.code = _keyboard.read("Enter location code   :");
            location.Quantity = 0;
            location.ItemCode = GetItemCode();
            Displaylocation(location);
            if (PromptYesNo("Add this location to stock locations list press  Y(yes) N(no) ") == "Yes")
            {
                StockLocations.Add(location);
                Console.WriteLine("Location added");
            }
            else
            {
                Console.WriteLine("Location discarded");
            }
        }
        private void Displaylocation(Location location)
        {
            Console.WriteLine("Location Details :");
            Console.WriteLine($"Code          :{location.code}");
            Console.WriteLine($"Item Code     :{location.ItemCode}");
            Console.WriteLine($"Item Quantity :{location.Quantity}");
            Console.WriteLine("=======================================");
        }
        private string GetItemCode()
        {
            do
            {
                var result = _keyboard.read("Enter Item code   :");
                // check code entered exists
                if (StockItems.Where(x => x.code == result).ToList().Count > 0)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid code. try again. ");
                }
            } while (true);
        }
        public void newStockItem()
        {
            Console.WriteLine("Enter new Item details ---------------- ");
            Item item = new Item();
            item.name = _keyboard.read("Enter Item name :"); ;
            item.code = _keyboard.read("Enter Item code :"); ;
            item.description = _keyboard.read("Enter Item description :"); ;
            item.value = _keyboard.getDoubleValue("Enter Item value :");
            DisplayItem(item);
            if (PromptYesNo("Add this item to stock Items list ") == "Yes")
            {
                StockItems.Add(item);
                Console.WriteLine("Item added");
            }
            else
            {
                Console.WriteLine("Item discarded");
            }
        }
        private string PromptYesNo(string prompt)
        {
            do
            {
                var result = _keyboard.readKey(prompt);
                switch (result)
                {
                    case 'Y':
                    case 'y':
                        Console.WriteLine();
                        return "Yes";
                    case 'N':
                    case 'n':
                        Console.WriteLine();
                        return "No";
                    default:
                        break;
                }
            } while (true);



        }
        public void DisplayItem(Item item)
        {
            Console.WriteLine("Item Details :");
            Console.WriteLine($"Name        :{item.name}");
            Console.WriteLine($"Code        :{item.code}");
            Console.WriteLine($"Description :{item.description}");
            Console.WriteLine($"Value       :{item.value}");
            Console.WriteLine("=======================================");
        }
        private void LoadStockItems()
        {
            if (File.Exists(stockItemsFile))
            {
                using (StreamReader reader = new StreamReader(stockItemsFile))
                {
                    // deserialize date in stockitems file and loat into stockitems list
                    var input = reader.ReadLine();
                    StockItems = JsonSerializer.Deserialize<List<Item>>(input);
                }
            }
        }
        private void LoadStockLocations()
        {
            if (File.Exists(stockLocationsFile))
            {
                using (StreamReader reader = new StreamReader(stockLocationsFile))
                {
                    // deserialize date in stockitems file and loat into stockitems list
                    var input = reader.ReadLine();
                    StockLocations = JsonSerializer.Deserialize<List<Location>>(input);
                }
            }
        }
    }
}
