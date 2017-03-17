﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics;

//The websocket I'm using is from the following source:
//https://github.com/sta/websocket-sharp

namespace RoboGeneral6000
{
    class RoboSystem
    {
        private static readonly object syncLock = new object();
        private static bool deciding = false;
        public static RoboData currentState = new RoboData();
        private static int counter = 0;

        static void Main(string[] args)
        {
            try
            {

                String url = "ws://npcompete.io/wsjoin?game=PenTest";
                String devkey = "AustinsLoudlyMagnificentRamen";

                FileStream output = File.Create("testText.txt");

                //int maxLines = 100;
            
                var socket = new WebSocket(url);

                Debug.WriteLine("Hello world!");

                

                /************************************************************************
                 * Event handler for listening for a message
                 * *********************************************************************/
                socket.OnMessage += (sender, e) =>
                {
                    onMessage(e);
                };

                //The actual running of the code

                List<_NeuralNet.NeuralNet> result = RoboMash.Mash(RoboMash.GenNeural());
                Debug.WriteLine(result.Count.ToString());
                for(int i = 0; i < result.Count; i++)
                {
                    Debug.Write(result[i].fitness.ToString() + " ");
                }

                socket.Connect();
                socket.Send(devkey);

                Console.ReadLine();

                output.Close();

                socket.Close();
            }

            catch (Exception e)
            {
                Debug.WriteLine("DEBUG: " + e.Message);
            }
        }

        static void onMessage(MessageEventArgs e)
        {
            String gameState;

            lock (syncLock)
            {
                if (deciding)
                {
                    return;
                }

                deciding = true;
            }
            gameState = e.Data;

            //TODO: Make a class to handle the first message sent, containing the player number
            try
            {
                Debug.WriteLine("STATE " + counter + ": " + gameState);
                currentState = JsonConvert.DeserializeObject<RoboData>(gameState);
                if (currentState != null)
                {

                    if (counter % 30 == 0)
                    {
                        Debug.WriteLine("CURSTATE: \n" + currentState.PrintData());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Data);
                Debug.WriteLine(ex.Message);
            }
            finally
            {

                counter++;
            }


            MakeDecision();

            lock (syncLock)
            {

                deciding = false;
            }
        }

        static void MakeDecision()
        {

        }




    }
}
