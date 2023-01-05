using DifferentialEvolution.DE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEForUrbanTransitRoutingProblem.DE
{
    /// <summary>
    /// Interfata pentru problemele de optimizare
    /// </summary>
    public interface IOptimizationProblem
    {
        void ComputeFitness(Chromosome c);

        Chromosome MakeChromosome();
    }
}
