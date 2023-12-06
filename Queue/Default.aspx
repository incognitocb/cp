<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebRole1.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Mail ID:
            <asp:TextBox ID="txtmail" runat="server"></asp:TextBox><br />
            Mail Subject:
            <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox><br />
            Mail Body:
            <asp:TextBox ID="txtmailbody" runat="server" Height="154px" Width="146px"></asp:TextBox><br />
            <asp:Button ID="cmdsubmit" runat="server" Text="submit" OnClick="cmdsubmit_click" />
        </div>
    </form>
</body>
</html>
