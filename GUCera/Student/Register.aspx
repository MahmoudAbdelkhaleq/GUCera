<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GUCera.StudentRej" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Please enter your info:<br />
            <br />

            First name:
            <br />
            <asp:TextBox ID="FirstNameBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="FirstNameMessage" runat="server" Text=" " ForeColor="Red"></asp:Label>
            <br />
            Last name:
            <br />
            <asp:TextBox ID="LastNameBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LastNameMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />
            Password:
            <br />
            <asp:TextBox ID="PasswordBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="PasswordMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />
            Email:
            <br />
            <asp:TextBox ID="EmailBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="EmailMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />

            Gender:<br />
            m<asp:RadioButton ID="Male" runat="server" GroupName ="Gender"/> 
            f<asp:RadioButton ID="Female" runat="server" GroupName ="Gender"/>
            <br />
            <asp:Label ID="GenderMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />
            Address: 
            <br />
            <asp:TextBox ID="AddressBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="AddressMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />
            <asp:Button ID="RegisterStudent" runat="server" Text="Register" OnClick="RegisterStudent_Click" />
            <br />
        </div>
    </form>
</body>
</html>
