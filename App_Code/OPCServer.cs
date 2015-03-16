using Opc.Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace OPC_DA_APSNET_client
{
    /// <summary>
    /// Summary description for OPCServer
    /// </summary>
    public class OPCServer
    {
        private static Opc.Da.Server _server;
        private string _serverName = String.Empty;
        private StringBuilder _error = new StringBuilder();

        /// <summary>
        /// Creates an instance of OPC server and tries to connect to it.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        public OPCServer(string serverName)
        {
            if (String.IsNullOrEmpty(serverName))
                throw new Exception(String.Format("Server name '{0}' is not valid", _serverName));

            _serverName = serverName;

            Connect();
        }

        /// <summary>
        /// Tries to connect to the server.
        /// </summary>
        private void Connect()
        {
            Opc.URL url = new Opc.URL("opcda://localhost/" + _serverName);
            OpcCom.Factory fact = new OpcCom.Factory();
            _server = new Opc.Da.Server(fact, null);

            try
            {
                _server.Connect(url, new Opc.ConnectData(new System.Net.NetworkCredential()));
            }
            catch (Exception ex)
            {
                _error.Append(ex.ToString());
                if (ex.InnerException != null)
                    _error.Append(ex.InnerException.ToString());
            }
        }

        /// <summary>
        /// Validates if the connection to the OPC server is still alive.
        /// </summary>
        /// <returns>Boolean flag.</returns>
        public bool IsConnected
        {
            get
            {
                return _server == null ? false : _server.IsConnected;
            }
        }

        /// <summary>
        /// Read values from OPC tags specified in 'itemCollection' array. 
        /// </summary>
        /// <returns>Array containing the current values of the OPC tags</returns>
        public ItemValueResult[] Read(Item[] itemCollection)
        {
            if (itemCollection == null)
                return null;

            if (!_server.IsConnected)
                throw new Exception("Not connected to OPC server");

            return _server.Read(itemCollection);
        }

        /// <summary>
        /// Disconnect from server.
        /// </summary>
        /// <returns>Boolean flag.</returns>
        public void Disconnect()
        {
            if (IsConnected)
                _server.Disconnect();
        }

        /// <summary>
        /// Last error message.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _error.ToString();
            }
        }
    }
}