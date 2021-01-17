<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="GUCera.Student.Assignments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your assignments are:</div>
        <asp:Label ID="AssignmentMessage" runat="server" Text=" " ForeColor="Red"></asp:Label>
        <br />
        <asp:Table ID="AssignmentsTable" runat="server" Visible="false">
            <asp:TableHeaderRow 
                runat="server" 
                ForeColor="Snow"
                BackColor="OliveDrab"
                Font-Bold="true"
                >
                <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>cid</asp:TableHeaderCell>
                <asp:TableHeaderCell>assignment #</asp:TableHeaderCell>
                <asp:TableHeaderCell>type</asp:TableHeaderCell>
                <asp:TableHeaderCell>full grade</asp:TableHeaderCell>
                <asp:TableHeaderCell>weight</asp:TableHeaderCell>
                <asp:TableHeaderCell>deadline</asp:TableHeaderCell>
                <asp:TableHeaderCell>content</asp:TableHeaderCell>

            </asp:TableHeaderRow>
        </asp:Table>
        <br />
    </form>
</body>
</html>
