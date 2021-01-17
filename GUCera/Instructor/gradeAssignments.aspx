<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gradeAssignments.aspx.cs" Inherits="GUCera.Instructor.gradeAssignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Student ID<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            Course ID<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Assignment Number<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Type<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Grade<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Confirm" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        </div>
    </form>
</body>
</html>
