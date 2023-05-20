using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IEnumerable<CameraComponent> GetCamerasByConfigOrder()
        {
            //Poe接続のカメラが優先（POEのindex順）
            foreach (var poe in this.Poes)
            {
                var cameras =
                    ComponentBase.GetRelatedComponents(this.Cameras, ComponentType.Poe, poe.Specifier.Index);
                foreach (var cam in cameras)
                {
                    yield return cam;
                }
            }

            //Poe接続ではないカメラ
            foreach (var cam in this.Cameras)
            {
                if (cam.GetRelatedComponent(ComponentType.Poe).Count == 0)
                {
                    yield return cam;
                }
            }
        }

        public IEnumerable<LightComponent>   GetLightsByConfigOrder(int cameraIndex)
        { 
            var lights = ComponentBase.GetRelatedComponents(this.Lights, ComponentType.Camera, cameraIndex ).ToList();
            lights.Sort((a, b) =>
            {
                var lightUnitA = a.GetRelatedComponent(ComponentType.LightControlUnit).FirstOrDefault();
                var lightUnitB = b.GetRelatedComponent(ComponentType.LightControlUnit).FirstOrDefault();

                if (lightUnitA == null)
                {
                    return -1;
                }

                if (lightUnitB == null)
                {
                    return 1;
                }

                return lightUnitA.Index - lightUnitB.Index;
            });
            foreach (var light in lights)
            {
                yield return light;
            }
        }

        public IEnumerable<LightControlUnitComponent> GetLightControlUnitsByConfigOrder(int cameraIndex)
        {
            var lights = GetLightsByConfigOrder(cameraIndex);
            var lightUnitIndexList = new List<int>();
            foreach (var light in lights)
            {
                var lightUnitSpecifier = light.GetRelatedComponent(ComponentType.LightControlUnit).FirstOrDefault();
                if (lightUnitSpecifier != null && !lightUnitIndexList.Exists(i=>i == lightUnitSpecifier.Index))
                {
                    lightUnitIndexList.Add(lightUnitSpecifier.Index);
                    var lightUnit = this.LightControlUnits.Find(u => u.Specifier.Index == lightUnitSpecifier.Index);
                    Debug.Assert(lightUnit != null);
                    yield return lightUnit;
                }
            }
        }

        public IEnumerable<ProductItemModel> GetProductItems()
        {
            foreach (var poe in this.Poes)
            {
                foreach (var item in poe.GetProductItemModels())
                {
                    yield return item;
                }
            }

            foreach (var camera in this.Cameras)
            {
                foreach (var item in camera.GetProductItemModels())
                {
                    yield return item;
                }
            }

            foreach (var light in this.Lights)
            {
                foreach (var item in light.GetProductItemModels())
                {
                    yield return item;
                }
            }

            foreach (var lightUnit in this.LightControlUnits)
            {
                foreach (var item in lightUnit.GetProductItemModels())
                {
                    yield return item;
                }
            }

            foreach (var displayUnit in this.DisplayUnits)
            {
                foreach (var item in displayUnit.GetProductItemModels())
                {
                    yield return item;
                }
            }
        }
    }

    
}
