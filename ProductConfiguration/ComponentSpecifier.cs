using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class ComponentSpecifier
    {
        public ComponentType Type { get; }
        public int Index { get; }

        public ProductItemModel Model { get; }


        public ComponentSpecifier(ProductItemModel model, int index)
        {
            this.Model = model;
            this.Index = index;
            this.Type = GetType(model);
        }

        public ComponentSpecifier(ComponentType type, int index)
        {
            this.Type = type;
            this.Index = index;
        }

        public static ComponentType GetType(ProductItemModel model)
        {
            if (model is CameraModel)
            {
                return ComponentType.Camera;
            }

            if (model is DisplayModel)
            {
                return ComponentType.DisplayUnit;
            }

            if (model is PoeModel)
            {
                return ComponentType.Poe;
            }

            if (model is LightModel)
            {
                return ComponentType.Light;
            }

            if (model is LightControlModel)
            {
                return ComponentType.LightControlUnit;
            }

            Debug.Assert(false, $"unknown type");
            return ComponentType.None;
        }
    }
}
