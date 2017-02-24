using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;

//The websocket I'm using is from the following source:
//https://github.com/sta/websocket-sharp

namespace RoboGeneral6000
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String url = "ws://npcompete.io/wsjoin?game=GAMENAME";
            String devkey = "AustinsLoudlyMagnificentRamen";

            var socket = new WebSocket(url);

            socket.OnMessage += (sender, e) =>
                Console.WriteLine("Data: " + e.Data);

            socket.Connect();
            socket.Send(devkey);

            Console.ReadLine();

            socket.Close();



        }
    }
}
