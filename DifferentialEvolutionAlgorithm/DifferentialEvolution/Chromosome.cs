using DEForUrbanTransitRoutingProblem.DE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEvolution.DE
{
    public class Chromosome
    {
        public double Fitness { get; set; }
        public int NoGenes { get; set; }
        public List<double> Genes;
        public double[] MinValues { get; set; } // valorile minime posibile ale genelor
        public double[] MaxValues { get; set; } // valorile maxime posibile ale genelor
        private static Random _rand = new Random();


        public Chromosome()
        {
            Genes = new List<double>();
        }

        public Chromosome(int noGenes, double[] minValues, double[] maxValues)
        {
            NoGenes = noGenes;
            Genes = new List<double>(NoGenes);
            MinValues = new double[noGenes];
            MaxValues = new double[noGenes];

            for (int i = 0; i < noGenes; i++)
            {
                MinValues[i] = minValues[i];
                MaxValues[i] = maxValues[i];

                Genes[i] = minValues[i] + _rand.NextDouble() * (maxValues[i] - minValues[i]); // initializare aleatorie a genelor
            }
        }

        public void Evaluate(IOptimizationProblem problem)
        {
            problem.ComputeFitness(this);
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in Genes)
            {
                s.Append(Math.Round(item, 4) + ", ");
            }
            s.Remove(s.Length - 2, 2);
            return s.ToString();
        }
    }
}
