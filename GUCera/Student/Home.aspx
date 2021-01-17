<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GUCera.StudentHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left:73px">
    <form id="form1" runat="server" >
        <div>
            <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large">Welcome,</asp:Label>
            <asp:Label ID="StudentName" runat="server" Text=" " Font-Bold="true" Font-Size="XX-Large" ></asp:Label>
            <br />
            <br />
            <br />
        </div>
        <asp:Button ID="StudentProfile" runat="server" OnClick="StudentProfile_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text ="View my profile" Width="600"/>
        <br />
        <br />
        <asp:Button ID="ViewCourses" runat="server" OnClick="ViewCourses_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text ="available courses" Width="600"/>
        <br />
        <br />
        <asp:Button ID="CreditCard" runat="server" OnClick="CreditCard_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text ="add Credit Card" Width="600"/>
        <br />
        <br />
        <asp:Button ID="PromoCodes" runat="server" OnClick="PromoCodes_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text ="View my promo codes" Width="600"/>
        <br />
        <br />
        <asp:Button ID="ViewAssignments" runat="server" OnClick="ViewAssignments_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text="View my assignments" Width="600"/>
        <br />
        <br />
        <asp:Button ID="SubmitAssignment" runat="server" OnClick="SubmitAssignment_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text="Submit assignment" Width="600"/>
        <br />
        <br />
        <asp:Button ID="ViewGrades" runat="server" OnClick="ViewGrades_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text="View grades" Width="600"/>
        <br />
        <br />
        <asp:Button ID="AddFeedback" runat="server" OnClick="AddFeedback_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text="Add feedback" Width="600"/>
        <br />
        <br />
        <asp:Button ID="ViewCertificates" runat="server" OnClick="ViewCertificates_Click" Font-Bold="true" Font-Size="XX-Large" style="margin-left: 280px" Text="View my certificates" Width="600"/>
        <br />
    </form>
</body>
</html>
