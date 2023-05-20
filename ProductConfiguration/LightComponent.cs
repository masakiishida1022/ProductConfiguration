using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class LightComponent : ComponentBase
    {
        LightComponent(ComponentSpecifier specfier, ComponentSpecifier targetCameraSpecifier, ComponentSpecifier lightCtrlUnitSpecifier,
            List<ProductItemModel> options) : base(specfier, null, options)
        {
            this.AddRelatedComponent(targetCameraSpecifier);
            if (lightCtrlUnitSpecifier != null)
            {
                this.AddRelatedComponent(lightCtrlUnitSpecifier);
            }
        }

        override protected IEnumerable<ProductItemModel> OnGetProductItemModels()
        {
            yield break;
        }
    }
}
