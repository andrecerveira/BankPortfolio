using Project.Interfaces;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Portfolio
    {
        private List<ITrade> _tradeList = new List<ITrade>();

        public Portfolio(List<ITrade> tradeList)
        { this._tradeList = tradeList; }

        public void AddTrade(double value, string clientSector)
        { _tradeList.Add(new Trade { Value = value, ClientSector = clientSector }); }

        public List<string> GetCategoryList()
        {
            List<string> categoryList = new List<string>();
            foreach (var trade in _tradeList)
                categoryList.Add(trade.GetCategory());
            return categoryList;
        }
    }
}
