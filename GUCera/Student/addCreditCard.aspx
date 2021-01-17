<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addCreditCard.aspx.cs" Inherits="GUCera.Student.addCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add CreditCard<br />
            <br />
            Card Number<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text=" "></asp:Label>
            <br />
            CardHolder name<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            expiry date<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;(dd/mm/yyyy)<asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
            <br />
            CVV<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="103px" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>
