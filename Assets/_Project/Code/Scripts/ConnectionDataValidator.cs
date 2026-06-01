using System.Net;

namespace MultiplayerShooter
{
    public static class ConnectionDataValidator
    {
        private const string _defaultAdress = "127.0.0.1";
        private const ushort _defaultPort = 7777;

        public static bool TryGetValidAddress(string adress, out string validAddress)
        {
            validAddress = _defaultAdress;

            if (adress == string.Empty)
            {
                return true;
            }

            if (IPAddress.TryParse(adress, out IPAddress iPAddress) == true 
                    && iPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                validAddress = adress;
                return true;
            }

            return false;
        }

        public static bool TryGetValidPort(string port, out ushort validPort)
        {
            validPort = _defaultPort;

            if (port == string.Empty)
            {
                return true;
            }

            if (ushort.TryParse(port, out ushort parsedPort) == true)
            {
                validPort = parsedPort;
                return true;
            }

            return false;
        }
    }
}
