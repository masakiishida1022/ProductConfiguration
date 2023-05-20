using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class PowerCalculator
    {
        void Calculate(ProductConfiguration config)
        {
            foreach (var poe in config.Poes)
            {
                var poePoweredCamera = ComponentBase.GetRelatedComponents(config.Cameras, ComponentType.Poe, poe.Specifier.Index).Where(cam => cam.PowerType == PowerSupplyType.Poe);
                foreach (var camera in poePoweredCamera)
                {
                    var relatedLights = ComponentBase
                        .GetRelatedComponents(config.Lights, ComponentType.Camera, camera.Specifier.Index)
                        .Where(light => (light.GetRelatedComponent(ComponentType.LightControlUnit).Count == 0));

                }
            }

            foreach (var camera in config.Cameras)
            {
                if (camera.PowerType != PowerSupplyType.Poe)
                {
                    var relatedLights = ComponentBase
                        .GetRelatedComponents(config.Lights, ComponentType.Camera, camera.Specifier.Index)
                        .Where(light => (light.GetRelatedComponent(ComponentType.LightControlUnit).Count == 0));
                }
            }

            foreach (var lightUnit in config.LightControlUnits)
            {
                var lights = ComponentBase.GetRelatedComponents(config.Lights, ComponentType.LightControlUnit,
                    lightUnit.Specifier.Index);
            }

        }

    }
}
