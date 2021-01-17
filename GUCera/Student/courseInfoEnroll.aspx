<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseInfoEnroll.aspx.cs" Inherits="GUCera.Student.courseInfoEnroll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 531px">
            <asp:Label ID="Label1" runat="server" Text="Details"></asp:Label>
        </div>
        <asp:Table ID="Table1" runat="server" style="margin-left: 698px">
        </asp:Table>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 687px" Text="Button" />
        <br />
        <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
    </form>
</body>
</html>
