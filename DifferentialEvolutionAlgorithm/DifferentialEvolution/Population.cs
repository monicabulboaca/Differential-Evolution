using DEForUrbanTransitRoutingProblem.DE;
using System.Collections.Generic;
using System.Linq;

namespace DifferentialEvolution.DE
{
    public class Population
    {
        public List<Chromosome> Solutions { get; set; }
        public double AverageFitness { get { return Solutions.Average(x => x.Fitness); } }
        public double MaximumFitness { get { return Solutions.Max(x => x.Fitness); } }
        public double MinimumFitness { get { return Solutions.Min(x => x.Fitness); } }
        public double TotalSumFitness { get { return Solutions.Sum(x => x.Fitness); } }

        public Population(List<Chromosome> individuals)
        {
            Solutions = individuals;
        }

        public Chromosome GetBest()
        {
            return Solutions.OrderBy(x => x.Fitness).FirstOrDefault();
        }

        public void Evaluate(IOptimizationProblem problem)
        {
            foreach (var item in Solutions)
            {
                item.Evaluate(problem);
            }
        }
    }
}
