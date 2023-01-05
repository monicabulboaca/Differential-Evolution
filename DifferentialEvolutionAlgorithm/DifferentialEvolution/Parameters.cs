using System;

namespace DifferentialEvolution.DE
{
    public class Parameters
    {
        /// <summary>
        /// Amplification Factor (0...2) 
        /// </summary>
        public double F { get; set; }

        /// <summary>
        /// Crossover Probability (0...1)
        /// </summary>
        public double CR { get; set; }

        /// <summary>
        /// Number of chromosomes
        /// </summary>
        public int ChromosomesCount { get; set; }

        /// <summary>
        /// Number of iterations to perform
        /// </summary>
        public int Iterations { get; set; }

        /// <summary>
        /// Number of variables for each chromosome
        /// </summary>
        public int Dimensions { get; set; }

        /// <summary>
        /// Domain of a function
        /// </summary>
        public Tuple<double, double> Domain { get; set; }

        /// <summary>
        /// Default parameters
        /// </summary>
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
