using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0.Garage
{
    internal class Garage<T>
    {
        private Vehicle.Vehicle[] vehicle;
        private int capacity;

        public int Capacity { get; set; }

        public Garage(int size)
        {
            Capacity = size;
            vehicle = new Vehicle.Vehicle[capacity];
        }
    }
}
