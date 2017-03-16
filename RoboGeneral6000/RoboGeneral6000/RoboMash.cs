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
            try
            {
                population.Sort(new FitnessComparator());
                List<NeuralNet> newPop;
                newPop = KillHalf(population);

                newPop = ReproducePop(newPop);

                return newPop;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return population;
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

            List<double> board = GenBoard(toReproduce);

            Random randGen = new Random((int)DateTime.Now.Ticks);
            //Random randGen = new Random(100);
            int numRuns = toReproduce.Count;
            double firstRand = 0;
            double secondRand = 0;

            Debug.WriteLine("Board Size: " + board.Count.ToString());
            Debug.WriteLine("To Reproduce Size: " + toReproduce.Count.ToString());

            //First, select two members and recombine the member genes if needed
            for (int round = 0; round < numRuns; round++)
            {
                //Debug.WriteLine()
                first = null;
                second = null;
                firstRand = randGen.NextDouble();
                secondRand = randGen.NextDouble();

                Debug.WriteLine("Rooouuunnnndddd: " + round.ToString());
                

                for (int itr = 0; itr < board.Count; itr++)
                {
                    Debug.WriteLine("Iteration: " + itr.ToString());
                    
                    if (board[itr] < firstRand && firstRand < board[itr + 1])
                    {
                        first = toReproduce[itr];
                    }
                    if(board[itr] < secondRand && secondRand < board[itr + 1])
                    {
                        second = toReproduce[itr];
                    }
                    Debug.WriteLine("Do I make it here?");
                    if(first != null && second != null)
                    {
                        break;
                    }
                    Debug.WriteLine("How about here?");
                }
                
                if (randGen.NextDouble() < recombineProbability)
                {
                    Debug.WriteLine("Entering reproduce");
                    RecombineMembers(first, second, newPop, randGen);
                }
                else
                {
                    Debug.WriteLine("Adding memebers after no recombo");
                    newPop.Add(new NeuralNet(first));
                    newPop.Add(new NeuralNet(second));
                }

            }

            return newPop;
        }

        private static void RecombineMembers(NeuralNet first, NeuralNet second, List<NeuralNet> newPop, Random randGen)
        {
            Debug.WriteLine("In the butt");
            NeuralNet clone1 = new NeuralNet(first);
            NeuralNet clone2 = new NeuralNet(second);

            //This only works because we're guarenteed that both nets will be the same size
            int numEdges = first.EdgeCount();

            int crossIndex = randGen.Next(0, numEdges);
            double tempWeight = 0;

            Debug.WriteLine("Cross Index Value: " + crossIndex.ToString());
            clone1.PrintNet();
            clone2.PrintNet();

            for(int index = crossIndex; index < numEdges; index++)
            {
                tempWeight = clone1.getEdge(index);
                clone1.UpdateEdge(index, clone2.getEdge(index));
                clone2.UpdateEdge(index, tempWeight);
            }

            clone1.PrintNet();
            clone2.PrintNet();

            newPop.Add(clone1);
            newPop.Add(clone2);
        }




        //Helper Functions

        private static List<double> GenBoard(List<NeuralNet> population)
        {
            List<double> board = new List<double>();
            int sum = 0;
            double otherSum = 0;

            for(int i = 0; i < population.Count; i++)
            {
                sum += population[i].fitness;
            }

            Debug.WriteLine("Sum: "+sum.ToString());
            board.Add(0);
            for (int i = 0; i < population.Count; i++)
            {
                otherSum += (double)population[i].fitness / sum;
                board.Add(otherSum);
                Debug.Write(board[i].ToString() + " ");
            }

            Debug.Write(board[board.Count-1].ToString() + " ");
            Debug.WriteLine("");
            Debug.WriteLine(board.Count.ToString());

            return board;
        }


        //For debugging
        public static List<NeuralNet> GenNeural()
        {
            List<NeuralNet> sample = new List<NeuralNet>();

            int num = 10;

            for(int i = 0; i < num; i++)
            {
                sample.Add(new NeuralNet(2,5,3,3,.75));
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
