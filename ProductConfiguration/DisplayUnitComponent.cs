using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class DisplayUnitComponent : ComponentBase
    {
        DisplayUnitComponent(ComponentSpecifier specfier, EtherCableModel cable, List<ProductItemModel> options) : base(specfier, cable, options)
        {
        }

        override protected IEnumerable<ProductItemModel> OnGetProductItemModels()
        {
            yield break;
        }
    }
}
