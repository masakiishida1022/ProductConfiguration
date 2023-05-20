using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class ErrorCheck
    {
        public void CheckError(ProductConfiguration config)
        {
            //照明コントローラにつながる照明を調べる
            //複数照明が直結
            List<int> existCameraIndex = new List<int>();
            foreach (var light in config.Lights)
            {
                if (light.GetRelatedComponent(ComponentType.LightControlUnit).Count == 0)
                {
                    var cameraSpecifier = light.GetRelatedComponent(ComponentType.Camera).FirstOrDefault();
                    Debug.Assert(cameraSpecifier != null);
                    if (existCameraIndex.Exists(i => i == cameraSpecifier.Index))
                    {
                        //
                    }
                    else
                    {
                        existCameraIndex.Add(cameraSpecifier.Index);
                    }
                }

            }

            foreach (var lightUnit in config.LightControlUnits)
            {
                var lights = ComponentBase.GetRelatedComponents(config.Lights, ComponentType.LightControlUnit,
                    lightUnit.Specifier.Index);
                foreach (var light in lights)
                {

                }
            }

            foreach (var camera in config.Cameras)
            {
                if (camera.PowerType == PowerSupplyType.Poe)
                {
                    var light = ComponentBase.GetRelatedComponents(config.Lights, ComponentType.Camera,
                        camera.Specifier.Index);
                }
            }
        }
    }
}
