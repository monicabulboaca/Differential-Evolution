using DEForUrbanTransitRoutingProblem.DE;
using DifferentialEvolution.Helpers;

namespace DifferentialEvolution.DE
{
    public class DifferentialEvolutionAlgorithm
    {
        public Population Population { get; set; }
        public Parameters Parameters { get; set; }

        public DifferentialEvolutionAlgorithm(Population population, Parameters parameters)
        {
            Population = population;
            Parameters = parameters;
        }

        public void Solve(IOptimizationProblem problem, int maxEvaluations, double CR, double F)
        {
            Population.Evaluate(problem);
            
            while (maxEvaluations > 0)
            {
                List<Chromosome> newGeneration = new List<Chromosome>();

                foreach (var orginal in Population.Solutions)
                {
                    // generate unique random numbers
                    List<int> randomValues = RandomGenerator.GenerateRandom(3, 0, Population.Solutions.Count);
                    int i1 = randomValues[0];
                    int i2 = randomValues[1];
                    int i3 = randomValues[2];

                    // choose random individuals (agents) from population
                    Chromosome individual1 = Population.Solutions[i1];
                    Chromosome individual2 = Population.Solutions[i2];
                    Chromosome individual3 = Population.Solutions[i3];
                    
                    int currentGene = 0;
                    int dividingPoint = RandomGenerator.Instance.Random.Next(Population.Solutions.Count);
                    Chromosome candidate = new Chromosome();
                    foreach (var orginalElement in orginal.Genes)
                    {
                        double ri = RandomGenerator.Instance.Random.NextDouble();
                        if (ri < CR || currentGene == dividingPoint)
                        {
                            // mutation
                            double newElement = individual1.Genes[currentGene] + F * (individual2.Genes[currentGene] - individual3.Genes[currentGene]);

                            // crossover
                            if (CheckIfWithinDomain(newElement))
                                candidate.Genes.Add(newElement);
                            else
                                candidate.Genes.Add(orginalElement);
                        }
                        else
                        {
                            candidate.Genes.Add(orginalElement);
                        }

                        currentGene++;
                    }

                    // selection
                    candidate.Evaluate(problem);
                    orginal.Evaluate(problem);
                    if (candidate.Fitness < orginal.Fitness) // < deoarece aavem de a face cu o problema de minimizare
                        newGeneration.Add(candidate);
                    else
                        newGeneration.Add(orginal);
                }

                // switch populations
                Population.Solutions = newGeneration;
                maxEvaluations--;

                Chromosome best = Population.GetBest();

                Console.Write("Fitness: " + Math.Round(best.Fitness, 4));
                Console.WriteLine(string.Format(" - coordinate: ({0})", best.ToString()));
            }

            Console.WriteLine("Run complete");
        }

        private bool CheckIfWithinDomain(double newElement)
        {
            return newElement > Parameters.Domain.Item1 && newElement < Parameters.Domain.Item2;
        }
    }
}
