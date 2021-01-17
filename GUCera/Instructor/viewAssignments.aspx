<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewAssignments.aspx.cs" Inherits="GUCera.Instructor.viewAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Course ID<br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <br />
    </form>
</body>
</html>
