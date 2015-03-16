using Opc.Da;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OPC_DA_APSNET_client
{
    /// <summary>
    /// Read-only OPC client
    /// </summary>
    public class OPCServerClient
    {
        private OPCServer _server;

        public OPCServerClient(OPCServer server)
        {
            if (server == null)
                throw new Exception("Server is null");

            _server = server;
        }

        /// <summary>
        /// Read value from an OPC tag. 
        /// </summary>
        /// <returns>Tag value.</returns>
        public object ReadTagVal(string tagName)
        {
            if (String.IsNullOrEmpty(tagName))
                throw new Exception(String.Format("OPC tag name '{0}' is not valid", tagName));

            object tagValue = String.Empty;

            if (!_server.IsConnected)
                throw new Exception("Not connected to OPC server");

            Item[] itemCollection = new Item[1];
            itemCollection[0] = new Item { ItemName = tagName, MaxAge = -1 };

            ItemValueResult[] results = _server.Read(itemCollection);
            if (results.Length > 0)
                tagValue = results[0].Value;

            return tagValue;
        }
    }
}