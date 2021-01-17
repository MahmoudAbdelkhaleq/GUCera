<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssuePromo.aspx.cs" Inherits="GUCera.Admin.IssuePromo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 230px">
            Choose From The Following Fields:<br />
            <br />
            Choose Student ID:<br />
            <asp:DropDownList ID="Students" runat="server" Height="23px" Width="232px">
            </asp:DropDownList>
            <br />
            <br />
            The Code:<br />
            <asp:TextBox ID="Code" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="message" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="Submit" runat="server" Text="Issue The Code" OnClick="submit_click" Width="165px" />
        </div>
    </form>
</body>
</html>
