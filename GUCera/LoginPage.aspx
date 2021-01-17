<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="GUCera.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Please Log In</p>
        <p>
            Username:</p>
        <asp:TextBox ID="username" runat="server"></asp:TextBox>
        <br />
        password:<br />
        <asp:TextBox ID="password" runat="server" TextMode ="Password" BackColor="White" BorderColor="Black" BorderStyle="Outset"></asp:TextBox>
        <br />
        <asp:Label ID="message" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        <br />
        <asp:Button ID="login" runat="server" Text="log in" OnClick="login_Click" />
        <br />
       
        <br />
        New here?
        <br />
        Register as <asp:LinkButton ID="StudentRej" runat="server" OnClick="StudentRej_Click">Student</asp:LinkButton>
        <br />
        Register as <asp:LinkButton ID="InstructorRej" runat="server" OnClick="InstructorRej_Click">Instructor</asp:LinkButton>
        <br />
        <br />
    </form>
</body>
</html>
