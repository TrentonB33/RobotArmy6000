using System;
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
        public static RoboData currentState;
        static void Main(string[] args)
        {
            try
            {

                String url = "ws://npcompete.io/wsjoin?game=PenTest";
                String devkey = "AustinsLoudlyMagnificentRamen";

                String gameState;

                FileStream output = File.Create("testText.txt");

                int counter = 0;
                //int maxLines = 100;
            
                var socket = new WebSocket(url);

                /************************************************************************
                 * Event handler for listening for a message
                 * *********************************************************************/
                socket.OnMessage += (sender, e) =>
                {
                    gameState = e.Data;
                    try
                    {
                        //Debug.WriteLine("STATE " + counter + ": " + gameState);
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
                    /*finally
                    {

                        if (counter++ > maxLines)
                        {
                            Environment.Exit(0);
                        }
                    }*/


                    MakeDecision();
                        
                };


                //The actual running of the code

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

        static void MakeDecision()
        {

        }
    }
}
