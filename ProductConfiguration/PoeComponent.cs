using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class PoeComponent : ComponentBase
    {
        public PoeComponent(ComponentSpecifier specifier, EtherCableModel cable, List<ProductItemModel> options) : base(specifier, cable, options)
        { 
        }

        override protected IEnumerable<ProductItemModel> OnGetProductItemModels()
        {
            yield break;
        }
    }
}
