
using DifferentialEvolution.DE;

namespace DifferentialEvolution
{
    class Program
    {
        public static Tuple<double, double> MichalewiczDomain = new Tuple<double, double>(0, Math.PI);

        static void Main()
        {
            Parameters parameters = new Parameters
            {
                Dimensions = 2,
                F = 0.5,
                CR = 0.9,
                Domain = MichalewiczDomain,
                ChromosomesCount = 20,
                Iterations = 100
            };

            DifferentialEvolutionAlgorithm de = new DifferentialEvolutionAlgorithm(parameters);

            de.Solve(new MichalewiczFunction(2), parameters.Iterations, parameters.CR, parameters.F, parameters.ChromosomesCount);

        }
    }

    /// <summary>
    /// minimul e la f(2.20, 1.57) = -1.8013
    /// </summary>
    public class MichalewiczFunction : IOptimizationProblem
    {
        public int dimensions;

        public MichalewiczFunction(int dim)
        {
            dimensions = dim;
        }
        public Chromosome MakeChromosome()
        {
            // un cromozom are doua gene (x si y) care pot lua valori in intervalul (0, PI)
            return new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        }
        public void ComputeFitness(Chromosome cr)
        {
            double sum = 0;
            double m = 10;

            for (int i = 0; i < dimensions; i++)
            {
                sum += Math.Sin(cr.Genes[i]) * Math.Pow(Math.Sin(((i + 1) * Math.Pow(cr.Genes[i], 2))/ Math.PI), 2 * m);
            }

            cr.Fitness = -1 * sum;
        }
    }
    
}
