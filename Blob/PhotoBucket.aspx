<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoBucket.aspx.cs" Inherits="BlobWebRole.PhotoBucket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Choose File: <asp:FileUpload ID="imageSelector" runat="server" />
            <asp:Button ID="cmdUpload" runat="server" Text="Upload" OnClick="cmdUpload_Click" />
            <hr />
            <asp:ListView ID="imageGrid" runat="server">
                <ItemTemplate>
                    <asp:Image ImageUrl="<%#((Microsoft.WindowsAzure.Storage.Blob.IListBlobItem)(Container.DataItem)).Uri%>" Height="200px" Width="200px" runat="server" />
                </ItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
