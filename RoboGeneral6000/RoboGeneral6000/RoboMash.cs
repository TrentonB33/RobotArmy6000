using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboGeneral6000._NeuralNet;
using System.Diagnostics;



/***************************************
 * STEPS TO REPRODUCTION
 * -Sort the population from highest to lowest fitness
 * -Kill half the population, favoring members with high fitness
 * -Using a roullete method, choose 2 members and do the following
 *      - Decide if they will recombine
 *      - if so, decide where
 *      - Recombine
 *      - Go through and randomly mutate "genes" (in this case, edge weights)
 * -Repeat until there are N members of the new pop
 * 
 * ************************************/

namespace RoboGeneral6000
{
    static class RoboMash
    {
        //Class variables
        private static double recombineProbability = 0.73;


        //The is the publically available function to take a population
        //Of members and create the next generation
        public static List<NeuralNet> Mash(List<NeuralNet> population)
        {
            population.Sort(new FitnessComparator());
            List<NeuralNet> newPop;
            newPop = KillHalf(population);

            newPop = ReproducePop(newPop);

            
            return newPop;
        }


        //I expect oldPop to be sorted from least fit to Most fit
        private static List<NeuralNet> KillHalf(List<NeuralNet> oldPop)
        {
            List<NeuralNet> survivors = new List<NeuralNet>();
            List<int> indexesSaved = new List<int>();

            Random randGen = new Random((int)DateTime.Now.Ticks);

            int numToSave = oldPop.Count / 2;
            int maxVal = oldPop.Count * 2;
            int saved = 0;

            int temp = 0;

            int mem = 0;

            while (saved < numToSave)
            {
                temp = (mem + randGen.Next(0, oldPop.Count));
                Debug.WriteLine(saved.ToString() + " " + temp.ToString());

                if (temp > oldPop.Count)
                {
                    if (!indexesSaved.Exists(x => x == mem))
                    {
                        survivors.Add(oldPop[mem]);
                        indexesSaved.Add(mem);
                        saved++;
                    }
                }

                if (++mem == oldPop.Count)
                {
                    mem = 0;
                }
            }

            return survivors;
        }

        //Take the new reduced list and use it to create the next population
        private static List<NeuralNet> ReproducePop(List<NeuralNet> toReproduce)
        {
            List<NeuralNet> newPop = new List<NeuralNet>();
            NeuralNet first = null;
            NeuralNet second = null;

            List<int> board = GenBoard(toReproduce);

            Random randGen = new Random((int)DateTime.Now.Ticks);
            int numRuns = toReproduce.Count;
            double firstRand = 0;
            double secondRand = 0;

            //First, select two members and recombine the member genes if needed
            for(int round = 0; round < numRuns; round++)
            {
                first = null;
                second = null;
                firstRand = randGen.NextDouble();
                secondRand = randGen.NextDouble();

                for (int itr = 0; itr < board.Count; itr++)
                {
                    if (board[itr] < firstRand)
                    {
                        first = toReproduce[itr];
                    }
                    if(board[itr] < secondRand)
                    {
                        second = toReproduce[itr];
                    }
                    if(first != null && second != null)
                    {
                        break;
                    }
                }
                if (randGen.NextDouble() > recombineProbability)
                {
                    RecombineMembers(first, second, newPop, randGen);
                }
                else
                {
                    newPop.Add(new NeuralNet(first));
                    newPop.Add(new NeuralNet(second));
                }

            }


            return newPop;
        }

        private static void RecombineMembers(NeuralNet first, NeuralNet second, List<NeuralNet> newPop, Random randGen)
        {
            NeuralNet clone1 = new NeuralNet(first);
            NeuralNet clone2 = new NeuralNet(second);

            //This only works because we're guarenteed that both nets will be the same size
            int numEdges = first.EdgeCount();

            int crossIndex = randGen.Next(0, numEdges);
            double tempWeight = 0;

            for(int index = crossIndex; index < numEdges; index++)
            {
                tempWeight = clone1.GetEdge(index);
                clone1.UpdateEdge(index, clone2.GetEdge(index));
                clone2.UpdateEdge(index, tempWeight);
            }

            newPop.Add(clone1);
            newPop.Add(clone2);
        }




        //Helper Functions

        private static List<int> GenBoard(List<NeuralNet> population)
        {
            List<int> board = new List<int>();
            int sum = 0;

            for(int i = 0; i < population.Count; i++)
            {
                sum += population[i].fitness;
            }
            for (int i = 0; i < population.Count; i++)
            {
                board.Add(population[i].fitness / sum);
            }

            Debug.WriteLine(board.Count.ToString());

            return board;
        }

        












        //For debugging
        public static List<NeuralNet> GenNeural()
        {
            List<NeuralNet> sample = new List<NeuralNet>();

            int num = 50;

            for(int i = 0; i < num; i++)
            {
                sample.Add(new NeuralNet());
                sample[i].fitness = i;
            }

            return sample;

        }

    }

    //Comparator for neural nets based on fitness
    public class FitnessComparator : Comparer<NeuralNet>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(NeuralNet x, NeuralNet y)
        {
            if(x.fitness < y.fitness)
            {
                return -1;
            } else if( y.fitness < x.fitness)
            {
                return 1;
            }else
            {
                return 0;
            }
        }

    }



}
