using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class ErrorCheck
    {
        public void CheckError(ProductConfiguration config)
        {
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
            //照明コントローラにつながる照明を調べる
            foreach (var lightUnit in config.LightControlUnits)
            {
                
                var cameraIndexList = new List<int>();
                int totalCh = 0;
                
                var lights = ComponentBase.GetRelatedComponents(config.Lights, ComponentType.LightControlUnit,
                    lightUnit.Specifier.Index);
                
                foreach (var light in lights)
                {

                    var camSpecifier = light.GetRelatedComponent(ComponentType.Camera).FirstOrDefault(); ;
                    Debug.Assert(camSpecifier != null);                      
                    existCameraIndex.Add(camSpecifier.Index);
                    totalCh += 2;
                }

                if (4 < totalCh)
                {

                }

                if (1 < cameraIndexList.Distinct().Count())
                {
                    //異なるカメラの照明が接続されている
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
