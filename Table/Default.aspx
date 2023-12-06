<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableRole.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tbladdrecord" runat="server" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>Name:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtname" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Contact Number:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtcn" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Contact Type:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtct" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                   <asp:TableCell>Email:</asp:TableCell>
                   <asp:TableCell><asp:TextBox ID="txtemail" runat="server"></asp:TextBox></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2"><asp:Button ID="cmdInsert" Text="Insert" runat="server" OnClick="cmdInsert_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <hr />
            <asp:GridView ID="ContactGrid" runat="server" HorizontalAlign="Center" AutoGenerateColumns="false" OnRowCommand="ContactGrid_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email ID" />
                    <asp:BoundField DataField="PartitionKey" HeaderText="Contact Type" />
                    <asp:BoundField DataField="RowKey" HeaderText="Contact Number" />
                    <asp:ButtonField ButtonType="Link" HeaderText="Edit/Delete" Text="Edit/Delete" />
                </Columns>
            </asp:GridView>
            <hr />
            <asp:Table runat="server" ID="tbleditrecord" Visible="false" HorizontalAlign="Center">
                <asp:TableRow>
                    <asp:TableCell>Name:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtedname" runat="server"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Contact Number:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtedcn" runat="server" Enabled="false"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Contact Type:</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="txtedct" runat="server" Enabled="false"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                   <asp:TableCell>Email:</asp:TableCell>
                   <asp:TableCell><asp:TextBox ID="txtedemail" runat="server"></asp:TextBox></asp:TableCell>
               </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button ID="cmdEdit" Text="Update" runat="server" OnClick="cmdEdit_Click" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="cmdDelete" Text="Delete" runat="server" OnClick="cmdDelete_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            
        </div>
    </form>
</body>
</html>
