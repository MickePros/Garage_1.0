using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Boat : Vehicle
    {
        private double length { get; set; }

        public override string Honk()
        {
            return "BWAAAA!";
        }
    }
}
