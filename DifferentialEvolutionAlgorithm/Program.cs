using DEForUrbanTransitRoutingProblem.DE;
using DifferentialEvolution.DE;
using DifferentialEvolution.Helpers;

namespace DifferentialEvolution
{
    class Program
    {
        public static Tuple<double, double> SphereDomain = new Tuple<double, double>(-5.12, 5.12);

        static void Main()
        {
            Parameters parameters = new Parameters
            {
                Dimensions = 2,
                F = 0.5,
                CR = 0.9,
                Domain = SphereDomain,
                ChromosomesCount = 20,
                Iterations = 100
            };

            Population population = CreatePopulation(parameters);
            DifferentialEvolutionAlgorithm de = new DifferentialEvolutionAlgorithm(population, parameters);

            de.Solve(new Sphere(), parameters.Iterations, parameters.CR, parameters.F);
        }

        public static Population CreatePopulation(Parameters parameters)
        {
            List<Chromosome> individuals = new List<Chromosome>();
            for (int i = 1; i < parameters.ChromosomesCount; i++)
            {
                Chromosome individual = new Chromosome();

                for (int j = 0; j < parameters.Dimensions; j++)
                {
                    double randomNumber = RandomGenerator.GetDoubleRangeRandomNumber(parameters.Domain.Item1, parameters.Domain.Item2);
                    individual.Genes.Add(randomNumber);
                }

                individuals.Add(individual);
            }

            Console.WriteLine("Population: ");
            for(int i = 0; i < individuals.Count; i++)
            {
                Console.WriteLine(individuals[i]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            return new Population(individuals);
        }
    }

    public class Sphere : IOptimizationProblem
    {
        public Chromosome MakeChromosome()
        {
            // un cromozom are doua gene (x si y) care pot lua valori in intervalul (5.12, -5.12)
            return new Chromosome(2, new double[] { -5.12 }, new double[] { 5.12 });
        }

        /// <summary>
        /// min is at f(0,0) = 0
        /// </summary>
        public void ComputeFitness(Chromosome individual)
        {
            double sum = 0;

            foreach (double x in individual.Genes)
            {
                sum += Math.Pow(x, 2);
            }
            individual.Fitness = sum;
        }
    }
}
