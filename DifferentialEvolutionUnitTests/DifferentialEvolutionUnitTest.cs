using DifferentialEvolution.DE;
using DifferentialEvolution;

namespace DifferentialEvolutionUnitTests;

public class DifferentialEvolutionUnitTest
{
    [Fact]
    public void TestMethodCreatePopulation()
    {
        IOptimizationProblem problem = new MichalewiczFunction(2);
        int populationSize = 100;
    }
}