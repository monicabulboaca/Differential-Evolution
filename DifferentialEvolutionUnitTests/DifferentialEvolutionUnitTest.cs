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

        Assert.NotNull(best);
    }

    [Fact]
    public void Given_Mutation_Then_ShouldReturn_MutantChildNotNull()
    {
        Chromosome[] population = new Chromosome[4];
        Chromosome chr1 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        Chromosome chr2 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        Chromosome chr3 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        Chromosome chr4 = new Chromosome(2, new double[] { 0 }, new double[] { Math.PI });
        population[0] = chr1;
        population[1] = chr2;
        population[2] = chr3;
        population[3] = chr4;

        DifferentialEvolutionAlgorithm ev = new DifferentialEvolutionAlgorithm(new Parameters());
        Chromosome mutant = ev.Mutation(population, ev.Parameters.F);

        Assert.NotNull(mutant);
    }
}