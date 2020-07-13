using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLauncher.Logic;

namespace ProductLauncher.VM
{
    class ProductItemDesignModel : ProductItemViewModel
    {
        public ProductItemDesignModel()
        {
            Grade = "J26";
            GuidePath = ProductGuideLogic.GetPath(Grade);
            GuideTitle = ProductGuideLogic.GetTitle(GuidePath);
            SearchTerm = "J26RB012AM23";
        }

    }
}
