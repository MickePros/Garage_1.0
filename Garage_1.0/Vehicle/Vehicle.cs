using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Vehicle : IVehicle
    {
        public string License { get; internal set; }
        public string Color { get; internal set; }
        public uint Wheels { get; internal set; }

        public Vehicle()
        {
            
        }
        public virtual string Honk()
        {
            return "Honk honk!";
        }

        public override string ToString()
        {
            return $"{License} a {GetType().Name} in {Color} with {Wheels} wheels";
        }
    }
}
