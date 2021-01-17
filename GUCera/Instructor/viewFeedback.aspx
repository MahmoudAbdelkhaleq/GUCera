<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewFeedback.aspx.cs" Inherits="GUCera.Instructor.viewFeedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Course ID<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
