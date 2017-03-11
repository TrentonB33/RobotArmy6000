using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static List<object> Mash(List<object> population)
        {
            List<object> newPop;
            newPop = KillHalf(population);


            return newPop;
        }

        private static List<object> KillHalf(List<object> oldPop)
        {
            List<object> survivors = new List<object>();

            return survivors;
        }

    }
}
