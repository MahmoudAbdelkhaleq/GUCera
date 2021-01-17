<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="GUCera.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 342px">
            <asp:LinkButton ID="ViewAllCourses" runat="server" OnClick="ViewAllCourses_Click" >View All Courses In The System</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="UnacceptedCourses" runat="server" OnClick="UnacceptedCourses_Click" >View All Courses Not Accepted</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="AcceptCourses" runat="server" OnClick="AcceptCourses_Click" >Accept Requested Courses</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="NewPromo" runat="server" OnClick="NewPromo_Click" >Create New Promo Codes</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="IssuePromo" runat="server" OnClick="IssuePromo_Click" >Issue Promo Codes</asp:LinkButton>
            <br />
           
        </div>
    </form>
</body>
</html>
