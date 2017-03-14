using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboGeneral6000._NeuralNet;


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
        //The is the publically available function to take a population
        //Of members and create the next generation
        public static List<NeuralNet> Mash(List<NeuralNet> population)
        {
            List<NeuralNet> newPop;
            newPop = KillHalf(population);


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

            int mem = 0;

            while (saved < numToSave)
            {
                if (mem + randGen.Next(0, oldPop.Count) > oldPop.Count)
                {
                    if (!indexesSaved.Exists(x => x == mem))
                    {
                        survivors.Add(oldPop[mem]);
                        indexesSaved.Add(mem);
                        mem++;
                        saved++;
                        if (mem == oldPop.Count)
                        {
                            mem = 0;
                        }
                    }
                }
            }

            return survivors;
        }

        //For debugging
        public static List<NeuralNet> GenNeural()
        {
            List<NeuralNet> sample = new List<NeuralNet>();

            int num = 100;

            for(int i = 0; i < num; i++)
            {
                sample.Add(new NeuralNet());
                sample[i].fitness = i;
            }

            return sample;

        }

    }

    
}
