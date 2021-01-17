<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="GUCera.Student.Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Add your feedback<br />
            please be constructive :)<br />
            <br />
            course:
            <asp:DropDownList ID="CourseDropDownList" runat="server">
            </asp:DropDownList>
            <br />
        </div>
        <asp:TextBox ID="FeedBackTextBox" runat="server" Height="80px" Width="203px" MaxLength ="100" TextMode ="MultiLine" ></asp:TextBox>
        <br />
        <asp:Label ID="SubmitMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
    </form>
</body>
</html>
