<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllCourses.aspx.cs" Inherits="GUCera.Admin.AllCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 206px">
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="CoursesTable" runat="server" Width="1295px" >
            <asp:TableHeaderRow 
                runat="server" 
                ForeColor="White"
                BackColor="HotPink"
                Font-Bold="true"
                >
                <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Credit Hours</asp:TableHeaderCell>
                <asp:TableHeaderCell>Price </asp:TableHeaderCell>
                <asp:TableHeaderCell>Content</asp:TableHeaderCell>
                <asp:TableHeaderCell>Accepted</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
