using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;
using RoboGeneral6000._NeuralNet;

//The websocket I'm using is from the following source:
//https://github.com/sta/websocket-sharp

namespace RoboGeneral6000
{
    class RoboSystem
    {
        private static string url = "ws://npcompete.io/wsjoin?game=PenTest";
        private static string devkey = "AustinsLoudlyMagnificentRamen";
        private static List<NeuralNet> currentPop;

        //for creating the first population
        private static int numMems = 50;
        private static int inputSize = 40;
        private static int numLayers = 5;
        private static int layerSize = 50;
        private static int numOutputs = 3;
        private static double activation = .8;



        /***********************************************************
         * 
         * Progression of this program
         * 1. Load a population of neural nets, if applicable
         * 2. Run the neural nets against one another
         * 3. Save the population of neural nets
         * 4. Send the neural nets into RoboMash to reproduce
         * 5. Save this new batch of Neural nets
         * 6. Repeat
         * 7. Profit
         * 
         * 
         **********************************************************/
        static void Main(string[] args)
        {
            try
            {
                LoadPop();


                RoboGame curGame = new RoboGame(url, devkey, new NeuralNet());
                curGame.RunGame();

            }catch(Exception e)
            {
                Debug.WriteLine("DEBUG: " + e.Message);
            }
        }

        //helper functions
        private static void LoadPop()
        {
            if (!Directory.Exists("gens"))
            {
                Directory.CreateDirectory("gens");
                GenFirstPop();
            }
            
        }

        private static void GenFirstPop()
        {

            currentPop = new List<NeuralNet>();

            for(int mem = 0; mem < numMems; mem++)
            {
                currentPop[mem] = new NeuralNet(numLayers, layerSize, inputSize, numOutputs, activation);
            }



        }




    }
}
