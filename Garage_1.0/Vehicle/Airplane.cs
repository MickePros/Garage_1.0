using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Airplane : Vehicle
    {
        public uint Engines { get; }

        public Airplane(string license, string color, uint wheels, uint engines)
        {
            License = license;
            Color = color;
            Wheels = wheels;
            Engines = engines;
        }

        public override string ToString()
        {
            return $"{License} a {GetType().Name} in {Color} with {Wheels} wheels and {Engines} engines.";
        }
    }
}
