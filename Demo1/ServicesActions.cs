using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    public static class ServicesActions
    {
        public static List<Service> Services = new List<Service>();

    }
    public class Service
    {
        public int Id { get; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public string Path { get; set; }
    }
}
