using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class CameraComponent : ComponentBase
    {
        public PowerSupplyType PowerType { get; }
        CameraComponent(ComponentSpecifier specfier, EtherCableModel cable, PowerSupplyType powerType, ComponentSpecifier poeSpecifier, ComponentSpecifier displayUnitSpecifier,
            List<ProductItemModel> options) : base(specfier, cable, options)
        {
            this.PowerType = powerType;

            if (poeSpecifier != null)
            {
                this.AddRelatedComponent(poeSpecifier);
            }

            if (displayUnitSpecifier != null)
            {
                this.AddRelatedComponent(displayUnitSpecifier);
            }

        }


        override protected IEnumerable<ProductItemModel> OnGetProductItemModels()
        {
            yield break;
        }
    }
}
