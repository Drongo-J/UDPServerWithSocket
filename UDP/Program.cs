﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ip = IPAddress.Any; // anyone can join
            var port = 27001;

            var ep = new IPEndPoint(ip, port);

            var socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            socket.Bind(ep);

            while (true)
            {
                Console.WriteLine("Listening");
                var bytes = new byte[socket.ReceiveBufferSize];
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

                var length = socket.ReceiveFrom(bytes, ref endPoint);
                var msg = Encoding.UTF8.GetString(bytes, 0, length);
                Console.WriteLine(msg);
            }   
        }
    }
}
