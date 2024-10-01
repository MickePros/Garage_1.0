using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Vehicle
{
    internal class Bus : Vehicle
    {
        private uint seats { get; set; }

        public override string Honk()
        {
            return "HOOONK!";
        }
    }
}
