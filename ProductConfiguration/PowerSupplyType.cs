using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfiguration
{
    public class PowerSupplyType
    {
        static public PowerSupplyType Poe = new PowerSupplyType();
        static public PowerSupplyType PowerUnit = new PowerSupplyType();
        static public PowerSupplyType LightControlUnit = new PowerSupplyType();

        public PowerSupplyType()
        {
        }
    }
}
