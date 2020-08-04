using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    public class HighRiskCategoryRule : CategoryRule
    {
        public override string CalculateRisk(double value, string clientSector)
        {
            if (value > 1000000 && clientSector == "Private")
            { return "HIGHRISK"; }
            return base.CalculateRisk(value, clientSector);
        }
    }
}
