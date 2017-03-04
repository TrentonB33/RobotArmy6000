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
        static void Main(string[] args)
        {
            
            String url = "ws://npcompete.io/wsjoin?game=PenTest";
            String devkey = "AustinsLoudlyMagnificentRamen";

            String gameState;

            FileStream output = File.Create("testText.txt");

            RoboData currentState;

            int counter = 0;
            int maxLines = 100;
            
            /*****************************************************************
            //TODO: Go and look at the json to csharp website and also get the
            //Game to send me more inormation on units and towers so i can make a better
            //json file to give it
            /****************************************************************/

            var socket = new WebSocket(url);

            socket.OnMessage += (sender, e) =>
            {
                gameState = e.Data;
                ITraceWriter traceWriter = new MemoryTraceWriter();
                try
                {
                    Debug.WriteLine("STATE " + counter +": " + gameState);
                    currentState = JsonConvert.DeserializeObject<RoboData>(gameState);
                    Debug.WriteLine("DATA" + currentState.p2.mainCore.owner);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine("TRACE"+traceWriter+"\n");
                }
                finally
                {

                    if (counter++ > maxLines)
                    {
                        Environment.Exit(0);
                    }
                }
            };

            socket.Connect();
            socket.Send(devkey);

            Console.ReadLine();

            //output.Write(Encoding.ASCII.GetBytes(gameState), 0, Encoding.ASCII.GetByteCount(gameState));

            output.Close();

            socket.Close();
        }
    }
}
