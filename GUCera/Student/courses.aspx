<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="GUCera.Student.courses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="XX-Large" Height="75px" style="margin-left: 626px" Text="Available Courses" Width="315px"></asp:Label>
            <div>
            <asp:Table ID="list" runat="server" Height="65px" style="margin-top: 15px" Width="456px">
            </asp:Table>
            </div>
    </form>
</body>
</html>
