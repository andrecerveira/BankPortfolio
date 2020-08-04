using Project.Domain;
using Project.Interfaces;
using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Portfolio portifolio = new Portfolio(new List<ITrade>());
            portifolio.AddTrade(2000000, "Private");
            portifolio.AddTrade(400000, "Public");
            portifolio.AddTrade(500000, "Public");
            portifolio.AddTrade(3000000, "Public");
            
            List<string> tradeCategories = portifolio.GetCategoryList();
            
            foreach (string tradeCategory in tradeCategories)
                Console.WriteLine(tradeCategory);
            
            Console.ReadKey();
        }
    }
}
