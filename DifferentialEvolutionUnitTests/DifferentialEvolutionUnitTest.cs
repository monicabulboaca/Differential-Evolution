using DifferentialEvolution.DE;
using DifferentialEvolution;

namespace DifferentialEvolutionUnitTests;

public class DifferentialEvolutionUnitTest
{
    [Fact]
    public void Given_CreatePopulation_Then_ShouldReturn_PopulationLengthNotNull()
    {
        IOptimizationProblem problem = new MichalewiczFunction(2);
        int populationSize = 4;

        DifferentialEvolutionAlgorithm ev = new DifferentialEvolutionAlgorithm(new Parameters());
        Chromosome[] population = ev.CreatePopulation(problem, populationSize);

        Assert.True(population.Length == populationSize);
    }

    [Fact]
    public void Given_GetBest_Then_ShouldReturn_BestChromosomeNotNull()
    {
        Chromosome[] population = new Chromosome[3];
        Chromosome chr1 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        Chromosome chr2 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        Chromosome chr3 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        population[0] = chr1;
        population[1] = chr2;
        population[2] = chr3;
        
        Chromosome best = DifferentialEvolutionAlgorithm.GetBest(population);

        Assert.NotEqual(null, best);
    }

}