using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Boat : Vehicle
    {
        public double Length { get; }

        public Boat(string license, string color, uint wheels, double length)
        {
            License = license;
            Color = color;
            Wheels = wheels;
            Length = length;
        }

        public override string ToString()
        {
            return $"{License} a {GetType().Name} in {Color} with {Wheels} wheels and {Length} length.";
        }

        public override string Honk()
        {
            return "BWAAAA!";
        }
    }
}
