using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Bus : Vehicle
    {
        public uint Seats { get; }

        public Bus(string license, string color, uint wheels, uint seats)
        {
            License = license;
            Color = color;
            Wheels = wheels;
            Seats = seats;
        }

        public override string ToString()
        {
            return $"{License} a {GetType().Name} in {Color} with {Wheels} wheels and {Seats} seats.";
        }

        public override string Honk()
        {
            return "HOOONK!";
        }
    }
}
