using System;

namespace DifferentialEvolution.DE
{
    public class Parameters
    {
        public double F { get; set; }
        public double CR { get; set; }
        public int ChromosomesCount { get; set; }
        public int Iterations { get; set; }
        public int Dimensions { get; set; }

        public Tuple<double, double> Domain { get; set; }
        public Parameters()
        {
            F = 0.8;
            CR = 0.9;
            ChromosomesCount = 20;
            Iterations = 100;
        }

        public void Show()
        {
            Console.WriteLine("F: " + F);
            Console.WriteLine("CR: " + CR);
            Console.WriteLine("Population Count: " + ChromosomesCount);
            Console.WriteLine("Iterations: " + Iterations);
            Console.WriteLine("NoGenes: " + Dimensions);
        }
    }
}
