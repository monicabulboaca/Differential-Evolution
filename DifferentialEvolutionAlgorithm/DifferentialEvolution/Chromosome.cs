using DEForUrbanTransitRoutingProblem.DE;
using System;
using System.Collections.Generic;
using System.Text;

namespace DifferentialEvolution.DE
{
    public class Chromosome
    {
        public int NoGenes { get; set; } // numarul de gene ale individului
        public double Fitness { get; set; }
        public double[] Genes { get; set; } // valorile genelor
        public double[] MinValues { get; set; } // valorile minime posibile ale genelor
        public double[] MaxValues { get; set; } // valorile maxime posibile ale genelor

        private static Random _rand = new Random();


        public Chromosome(Chromosome c) // constructor de copiere
        {
            NoGenes = c.NoGenes;
            Fitness = c.Fitness;

            Genes = new double[c.NoGenes];
            MinValues = new double[c.NoGenes];
            MaxValues = new double[c.NoGenes];

            for (int i = 0; i < c.Genes.Length; i++)
            {
                Genes[i] = c.Genes[i];
                MinValues[i] = c.MinValues[i];
                MaxValues[i] = c.MaxValues[i];
            }
        }

        public Chromosome(int noGenes, double[] minValues, double[] maxValues)
        {
            NoGenes = noGenes;
            Genes = new double[noGenes];
            MinValues = new double[noGenes];
            MaxValues = new double[noGenes];

            for (int i = 0; i < noGenes-1; i++)
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
