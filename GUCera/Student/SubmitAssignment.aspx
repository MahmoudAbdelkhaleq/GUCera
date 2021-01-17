<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitAssignment.aspx.cs" Inherits="GUCera.Student.SubmitAssignment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Fill in the following fields to submit the assignment:</p>
        <p>
           <asp:Label ID="CourseMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        </p>
        <p>
            Course ID:
        </p>
        <p>
            <asp:DropDownList ID="CoursesDropDownList" runat="server" Width="100"  >
            </asp:DropDownList>
        </p>
        <p>
            
            <asp:Label ID="AssignmentTypeMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            
           </p>
        <p>
            Assignment type:</p>
        <p>
            <asp:DropDownList ID="AssignmentTypeDropDownList" Width="100" runat="server"  >
            </asp:DropDownList>
        </p>
        <p>
            <asp:Label ID="AssignmentNumberMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        </p>
        <p>
            Assignment number:</p>
        <asp:DropDownList ID="AssignmentNumberDropDownList" runat="server" Width="100">
        </asp:DropDownList>
        <br />
        <asp:Label ID="SubmitMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
        <br />
        <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        <br />
    </form>
</body>
</html>
