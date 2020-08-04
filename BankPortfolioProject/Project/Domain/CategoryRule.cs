using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain
{
    public abstract class CategoryRule
    {
        private CategoryRule nextLink;

        public void SetSuccessor(CategoryRule next)
        {
            nextLink = next;
        }

        public virtual string CalculateRisk(double value, string clienteSector)
        {
            if (nextLink != null)
            {
                return nextLink.CalculateRisk(value, clienteSector);
            }
            return string.Empty;
        }
    }
}
