# BankPortfolio

Pseudo Código:

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

###########
INTERFACE:
###########
public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        ICategory GetCategory();
    }

########
CLASSES:
########
namespace Project.Domain
{
    public class Portfolio
    {
        private List<ITrade> _tradeList = new List<ITrade>();

        public Portfolio(List<ITrade> tradeList)
        {this._tradeList = tradeList;}

        public void AddTrade(double value, string clientSector)
        {_tradeList.Add(new Trade { Value = value, ClientSector = clientSector});}

        public List<string> GetCategoryList()
        {
            List<string> categoryList = new List<string>();
            foreach (var trade in _tradeList)
                categoryList.Add(trade.GetCategory());
            return categoryList;
        }
    }
}
_________________________________________________________________________________________________________________________________________
namespace Project.Domain
{
    public class Trade : ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }

        public string GetCategory()
        {
            CategoryRule lowRiskRule = new LowRiskCategoryRule();
            CategoryRule mediumRiskRule = new MediumRiskCategoryRule();
            CategoryRule highRiskRule = new HighRiskCategoryRule();

            lowRiskRule.SetSuccessor(mediumRiskRule);
            mediumRiskRule.SetSuccessor(highRiskRule);

            return lowRiskRule.CalculateRisk(this.Value, this.ClientSector);
        }
    }
}
_________________________________________________________________________________________________________________________________________
namespace Project.Domain
{
    public abstract class CategoryRule
    {
        private CategoryRule nextLink;
        public void SetSuccessor(CategoryRule next)
        {nextLink = next;}

        public virtual string CalculateRisk(double value, string clienteSector)
        {
            if (nextLink != null)
            {return nextLink.CalculateRisk(value, clienteSector);}
            return string.Empty;
        }
    }
}
_________________________________________________________________________________________________________________________________________
namespace Project.Domain
{
    public class LowRiskCategoryRule : CategoryRule
    {
        public override string CalculateRisk(double value, string clientSector)
        {
            if (value < 1000000 && clientSector == "Public")
            {return "LOWRISK";}
            return base.CalculateRisk(value, clientSector);
        }
    }
}
_________________________________________________________________________________________________________________________________________
namespace Project.Domain
{
    public class MediumRiskCategoryRule : CategoryRule
    {
        public override string CalculateRisk(double value, string clientSector)
        {
            if (value > 1000000 && clientSector == "Public")
            {return "MEDIUMRISK";}
            return base.CalculateRisk(value, clientSector);
        }
    }
}
_________________________________________________________________________________________________________________________________________
namespace Project.Domain
{
    public class HighRiskCategoryRule : CategoryRule
    {
        public override string CalculateRisk(double value, string clientSector)
        {
            if (value > 1000000 && clientSector == "Private")
            {return "HIGHRISK";}
            return base.CalculateRisk(value, clientSector);
        }
    }
}
