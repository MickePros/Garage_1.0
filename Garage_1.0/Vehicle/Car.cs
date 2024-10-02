using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Car : Vehicle
    {
        public string FuelType { get; }

        public Car(string license, string color, uint wheels, string fuelType)
        {
            License = license;
            Color = color;
            Wheels = wheels;
            FuelType = fuelType;
        }

        public override string ToString()
        {
            return $"{License} a {GetType().Name} in {Color} with {Wheels} wheels and running on {FuelType}.";
        }
    }
}
