<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Connect OPC Server using OpcNetApi.dll</h3>

        <div style="margin-left:30px;">
            <p>OPC Server name:  <asp:TextBox ID="tbServerName" runat="server" Width="200"></asp:TextBox></p>
        </div>
        <div style="margin-left:30px;">
        <p>OPC Tag: <asp:TextBox ID="tbTagName" runat="server" Width="200"></asp:TextBox></p>
        <asp:Button ID="btReadTag" runat="server" Text="Get OPC tag value" OnClick="btReadTag_Click" />
        <p><code><asp:Literal ID="liResult" runat="server"></asp:Literal></code></p>
            </div>
    </div>
    </form>
</body>
</html>