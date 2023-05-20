using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace ProductConfiguration
{
    public class ProductConfiguration
    {
        public List<PoeComponent> Poes { get; } = new List<PoeComponent>();
        public List<CameraComponent> Cameras { get; } = new List<CameraComponent>();
        public List<LightComponent> Lights { get; } = new List<LightComponent>();
        public List<LightControlUnitComponent> LightControlUnits { get; } = new List<LightControlUnitComponent>();
        public List<DisplayUnitComponent> DisplayUnits { get; } = new List<DisplayUnitComponent>();

        public ProductConfiguration(
            List<PoeComponent> poes,
            List<CameraComponent> cameras,
            List<LightComponent> lights,
            List<LightControlUnitComponent> lightControlUnits,
            List<DisplayUnitComponent> displayUnits)
        {
            this.Poes.AddRange(poes.OrderBy(c => c.Specifier.Index));
            this.Cameras.AddRange(cameras.OrderBy(c => c.Specifier.Index));
            this.Lights.AddRange(lights.OrderBy(c => c.Specifier.Index));
            this.LightControlUnits.AddRange(lightControlUnits.OrderBy(c => c.Specifier.Index));
            this.DisplayUnits.AddRange(displayUnits.OrderBy(c => c.Specifier.Index)) ;
        }

        void GetPoePoweredComponent(int poeIndex)
        {
            var cameras = ProductConfiguration.GetRelatedComponents(this.Cameras, ComponentType.Poe, poeIndex);
            foreach (var cam in cameras)
            {
                if (cam.PowerType == PowerSupplyType.Poe)
                {
                    var lights =
                        ProductConfiguration.GetRelatedComponents(this.Lights, ComponentType.Camera,
                            cam.Specifier.Index);
                }
            }
        }

        public static IEnumerable<T> GetRelatedComponents<T>(List<T> componentList, ComponentType type, int index) where T : ComponentBase 
        {
            foreach (var component in componentList)
            {
                var specifier = component.GetRelatedComponent(type) ?.First();
                if (specifier != null && specifier.Index == index)
                {
                    yield return component;
                }
            }
        }
    }

    
}
