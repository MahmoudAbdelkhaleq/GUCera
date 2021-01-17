<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotAcceptedCourses.aspx.cs" Inherits="GUCera.Admin.NotAcceptedCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="CoursesTable" runat="server" Width="1342px" >
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
            </asp:TableHeaderRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
