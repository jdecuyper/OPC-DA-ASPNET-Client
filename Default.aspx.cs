using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OPC_DA_APSNET_client;

public partial class _Default : System.Web.UI.Page
{
    protected void btReadTag_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbServerName.Text) || String.IsNullOrEmpty(tbTagName.Text))
        {
            liResult.Text = "OPC Server or tag name is invalid";
            return;
        }

        OPCServer srv = new OPCServer(tbServerName.Text);

        if (!srv.IsConnected)
        {
            liResult.Text = "Could not establish connection to OPC Server";
            return;
        }

        OPCServerClient opcClient = new OPCServerClient(srv);

        liResult.Text = String.Format("{0}: {1}", tbTagName.Text, opcClient.ReadTagVal(tbTagName.Text).ToString());

        // Do not use in production code, it is only a demo.
        // The connection to the OPC server should not be open and closed on each HTTP request
        // It should only be opened once and kept in the user's session
        // Disconnecting from the OPC must be handled inside the Session_End event 
        srv.Disconnect();
    }
}