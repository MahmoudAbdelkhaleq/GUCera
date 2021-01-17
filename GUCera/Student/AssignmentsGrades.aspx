<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssignmentsGrades.aspx.cs" Inherits="GUCera.Student.AssignmentsGrades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your Assignment grades:<br />
        </div>
       <asp:Label ID="GradesMessage" runat="server" Text=" " ForeColor="Red"></asp:Label>
        <br />
        <asp:Table ID="GradesTable" runat="server" Visible="false">
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
                <asp:TableHeaderCell>Your grade</asp:TableHeaderCell>
              

            </asp:TableHeaderRow>
        </asp:Table>
    </form>
</body>
</html>
