using Project.Interfaces;

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
