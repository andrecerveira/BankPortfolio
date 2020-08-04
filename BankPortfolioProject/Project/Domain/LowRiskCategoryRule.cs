using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    public class LowRiskCategoryRule : CategoryRule
    {
        public override string CalculateRisk(double value, string clientSector)
        {
            if (value < 1000000 && clientSector == "Public")
            { return "LOWRISK"; }
            return base.CalculateRisk(value, clientSector);
        }
    }
}
