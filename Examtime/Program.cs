using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examtime
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int Room = 1;
            int Temp = rnd.Next(0, 80);
            int Smoke = 20;
            string Gas = "Normal";
            DateTime currenTime = DateTime.Now;
            
            //Temp = 22 + rnd.Next(0, 80);

            UdpClient udpServer = new UdpClient(0);
            udpServer.EnableBroadcast = true;
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 9999);

            Console.WriteLine("Broadcast started");
            Console.ReadLine();

            while (true)
            {
                Byte[] sendBytes = Encoding.ASCII.GetBytes(" Date Time: " + currenTime + "\r \n " + "Room: " + Room + "\r \n " + "Temp: " + Temp + "\r \n " + "Smoke: " + Smoke + "\r \n " + "Gas: " + Gas);
              //  Byte[] sendRoom = Encoding.ASCII.GetBytes("Room is: " + Room);
                try
                {
                    Temp = rnd.Next(0, 80);
                    currenTime = DateTime.Now;
                    udpServer.Send(sendBytes, sendBytes.Length, endPoint); //, endPoint
                   // udpServer.Send(sendRoom, sendRoom.Length, endPoint);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                //Time;
                //Room++;
                Console.WriteLine(" Date Time: " + currenTime + "\r \n " + "Room: " + Room + "\r \n " + "Temp: " + Temp + "\r \n " + "Smoke: " + Smoke + "\r \n " + "Gas: " + Gas);
                Thread.Sleep(2000);
            }
        }
    }
}
