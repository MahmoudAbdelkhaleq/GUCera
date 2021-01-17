<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Certificates.aspx.cs" Inherits="GUCera.Student.Certificates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Your certificates:<br />
            <asp:Label ID="CertificaesMessage" runat="server" Text=" " ForeColor ="Red"></asp:Label>
            <br />

            <asp:Table ID="CertificatesTable" runat="server" Visible="false">
            <asp:TableHeaderRow 
                runat="server" 
                ForeColor="Snow"
                BackColor="OliveDrab"
                Font-Bold="true"
                >
                <asp:TableHeaderCell>Course Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>cid</asp:TableHeaderCell>
                <asp:TableHeaderCell>issue date </asp:TableHeaderCell>
                
            </asp:TableHeaderRow>
        </asp:Table>
        </div>
    </form>
</body>
</html>
