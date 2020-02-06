using System;
using System.Net;
using System.Net.Sockets;

namespace EmployeeManagement.Core.Helpers
{
    public static class IpAddressHelper
    {
        public static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Nie znaleziono żadnych kart sieciowych na urządzeniu!");
        }
    }
}