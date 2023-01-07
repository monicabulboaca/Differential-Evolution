﻿using DEForUrbanTransitRoutingProblem.DE;

namespace DifferentialEvolution.DE
{
    public class DifferentialEvolutionAlgorithm
    {
        public Parameters Parameters { get; set; }
        private static Random _rand = new Random();

        public DifferentialEvolutionAlgorithm(Parameters parameters)
        {
            Parameters = parameters;
        }

        public void Solve(IOptimizationProblem problem, int maxGenerations, double CR, double F, int populationSize)
        {
            //initializare populatie
            Chromosome[] population = new Chromosome[populationSize];//vector de indivizi
            for (int i = 0; i < population.Length; i++)
            {
                //initializez cromozom, in functie de genele necesare problemei pe care o rezolv
                population[i] = problem.MakeChromosome();//initializez pe rand fiecare cromozom
                problem.ComputeFitness(population[i]);
            }

            for (int generation = 0; generation < maxGenerations; generation++)
            {
                List<Chromosome> newGeneration = new List<Chromosome>();

                foreach (var child in population.ToList())
                {
                    Random random = new Random();
                    //creez o lista cu numere random distincte
                    List<int> randomValuesList = new List<int>();
                    //generez lista de valori random cu valori intre 0 si nr. de indivizi din populatie 
                    while (randomValuesList.Count < 3)
                    {
                        int index = random.Next(0, population.Length - 1);
                        if (!randomValuesList.Contains(index))
                            randomValuesList.Add(index);
                    }
                    int i1 = randomValuesList[0];
                    int i2 = randomValuesList[1];
                    int i3 = randomValuesList[2];

                    // initializez cromozomii folositi pt. mutatie cu indivizii selectati random de mai sus
                    Chromosome cr1 = population[i1];
                    Chromosome cr2 = population[i2];
                    Chromosome cr3 = population[i3];

                    Chromosome mutantChild = new Chromosome(cr1);

                    //creare copil mutant
                    for (int i = 0; i < mutantChild.NoGenes; i++)
                    {
                        mutantChild.Genes[i] = cr1.Genes[i] + F * (cr2.Genes[i] - cr3.Genes[i]);
                    }

                    Chromosome resultCrossover = new Chromosome(mutantChild);

                    //generare valoare random cuprinsa intre 1 si nr. de indivizi din populatie
                    int delta = _rand.Next(1, population.Length-1);

                    for(int gene = 0; gene < child.NoGenes; gene++)
                    {
                        double k = _rand.NextDouble();
                        if (k < CR || gene == delta)
                        { 
                            // incrucisare
                            if (gene > Parameters.Domain.Item1 && gene < Parameters.Domain.Item2)
                            {
                                for (int i = 0; i < mutantChild.NoGenes; i++)
                                {
                                    resultCrossover.Genes[i] = mutantChild.Genes[i];
                                }
                            }
                            else
                            {
                                for (int i = 0; i < child.NoGenes; i++)
                                {
                                    resultCrossover.Genes[i] = child.Genes[i];
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < child.NoGenes; i++)
                            {
                                resultCrossover.Genes[i] = child.Genes[i];
                            }
                        }
                    }        
                    // selectie
                    resultCrossover.Evaluate(problem);
                    child.Evaluate(problem);
                    if (resultCrossover.Fitness < child.Fitness) // < deoarece aavem de a face cu o problema de minimizare
                        newGeneration.Add(resultCrossover);
                    else
                        newGeneration.Add(child);
                    }

                // actualizeaza populatie
                population = newGeneration.ToArray();
                Chromosome best = GetBest(population);

                Console.Write("Pentru generatia {0} valoarea fitness este {1} cu cromozomul [{2}", generation, Math.Round(best.Fitness, 3), best.ToString());
                Console.WriteLine(']');
            }
        }

        public static Chromosome GetBest(Chromosome[] population)
        {
            //pp. ca elementul maxim este primul din populatie
            double max = population[0].Fitness;
            //obiect nou, copie a celui mai bun individ
            Chromosome chromWithMaxFitness = new Chromosome(population[0]);

            //Returnează individul din populație cu funcția de adaptare maximă SAU MINIMA????????????????????
            for (int i = 1; i < population.Length; i++)
            {
                if (population[i].Fitness > max)
                {
                    max = population[i].Fitness;
                    chromWithMaxFitness = new Chromosome(population[i]);
                }
            }

            return chromWithMaxFitness;
        }
    }
}
