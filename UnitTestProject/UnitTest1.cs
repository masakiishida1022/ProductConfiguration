using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using ProductConfiguration;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var poeList = new List<PoeComponent>();
            var cameraList = new List<CameraComponent>();
            var lightList = new List<LightComponent>();
            var lightUnitList = new List<LightControlUnitComponent>();

            PoeComponent poe1 = new PoeComponent(
                new ComponentSpecifier(ComponentType.Poe, 0), 
                new EtherCableModel(),
                new List<ProductItemModel>());
            PoeComponent poe2 = new PoeComponent(
                new ComponentSpecifier(ComponentType.Poe, 1), 
                new EtherCableModel(),
                new List<ProductItemModel>());

            poeList.Add(poe1);
            poeList.Add(poe2);

            CameraComponent cam1 = new CameraComponent(
                new ComponentSpecifier(ComponentType.Camera, 0),
                
                new EtherCableModel(),
                PowerSupplyType.Poe,
                new ComponentSpecifier(ComponentType.Poe, 0),
                null,
                null
                );
            CameraComponent cam2 = new CameraComponent(
                new ComponentSpecifier(ComponentType.Camera, 1),
                
                new EtherCableModel(),
                PowerSupplyType.Poe,
                new ComponentSpecifier(ComponentType.Poe, 0),
                null,
                null
            );

            cameraList.Add(cam1);
            cameraList.Add(cam2);

            LightComponent light1 = new LightComponent(
                new ComponentSpecifier(ComponentType.Light, 0), 
                new ComponentSpecifier(ComponentType.Camera, 1),
                new ComponentSpecifier(ComponentType.LightControlUnit, 0),
                null
                );
            LightComponent light2 = new LightComponent(
                new ComponentSpecifier(ComponentType.Light, 1),
                new ComponentSpecifier(ComponentType.Camera, 1),
                new ComponentSpecifier(ComponentType.LightControlUnit, 1),
                null
            );

            LightComponent light3 = new LightComponent(
                new ComponentSpecifier(ComponentType.Light, 2),
                new ComponentSpecifier(ComponentType.Camera, 1),
                null,
                null
            );

            lightList.Add(light1);
            lightList.Add(light2);
            lightList.Add(light3);

            LightControlUnitComponent lightUnit1 = new LightControlUnitComponent(
                new ComponentSpecifier(ComponentType.LightControlUnit, 0),
                new EtherCableModel(),
                null
                );
            LightControlUnitComponent lightUnit2 = new LightControlUnitComponent(
                new ComponentSpecifier(ComponentType.LightControlUnit, 1),
                new EtherCableModel(),
                null
            );



            lightUnitList.Add(lightUnit1);
            lightUnitList.Add(lightUnit2);

            var productConfig =
                new ProductConfiguration.ProductConfiguration(poeList, cameraList, lightList, lightUnitList, new List<DisplayUnitComponent>());
            var cameras = productConfig.GetCamerasByConfigOrder();

            var cameraLists = cameras.ToList();
            var products = productConfig.GetProductItems();
            var list = products.ToList();

            var lights = productConfig.GetLightsByConfigOrder(1);
            var lightTmpList = lights.ToList();
            var lightUnits = productConfig.GetLightControlUnitsByConfigOrder(1);
            var tmplist = lightUnits.ToList();
        }
    }
}
