<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptCourses.aspx.cs" Inherits="GUCera.Admin.AcceptCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Fill The Following Fields to Accept A Course:</p>
        <p>
            &nbsp;</p>
        <p>
            Course ID:
        </p>
        <p>
            <asp:DropDownList ID="CoursesDropDownList" runat="server" Width="100"  >
            </asp:DropDownList>
        </p>
        <asp:Label ID="courseMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        <br />
        <p>
            &nbsp;</p>
        <p>
            Admin Id:</p>
        <p>
            <asp:TextBox ID="adminId" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="message" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        <br />
        <asp:Button ID="accept" runat="server" Text="Accept" OnClick="Accept_click" />
        <br />
    </form>
</body>
</html>
