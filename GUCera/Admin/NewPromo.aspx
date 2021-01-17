<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewPromo.aspx.cs" Inherits="GUCera.Admin.NewPromoCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Fill The Following Fields:<br />
            <br />
            The Code (6 Characters):<br />
            <asp:TextBox ID="code" runat="server" Width="316px"></asp:TextBox>
            <br />
            <br />


            IssueDate:<br />
            Year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Month:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Day:<br />
            <asp:DropDownList ID="IssueDateYear" AutoPostBack="true" OnSelectedIndexChanged="Year_SelectedIndexChanged" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="IssueDateMonth" AutoPostBack="true" OnSelectedIndexChanged="Month_SelectedIndexChanged" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="IssueDateDay" runat="server">
            </asp:DropDownList>
            <br /> 
            <asp:Label ID="messageIssueDate" runat="server" Text="" ForeColor ="Red"></asp:Label>
            <br />


            ExpiryDate:<br />
            Year:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Month:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Day:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
            <asp:DropDownList ID="ExpiryDateYear" AutoPostBack="true" OnTextChanged ="Year_SelectedIndexChanged" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ExpiryDateMonth" AutoPostBack="true" OnTextChanged="Month_SelectedIndexChanged" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ExpiryDateDay" runat="server">
            </asp:DropDownList> 
            <br /> 
            <asp:Label ID="messageExpiryDate" runat="server" Text="" ForeColor ="Red"></asp:Label>
            <br />


            Discount:<br />
            <asp:TextBox ID="discount" runat="server" Width="306px"></asp:TextBox>
            <br />
            <asp:Label ID="messageDiscount" runat="server" Text="" ForeColor ="Red"></asp:Label>
            <br />


            Admin ID:<br />
            <asp:TextBox ID="adminId" runat="server" Width="306px"></asp:TextBox>
            <br />
            <asp:Label ID="messageAdminId" runat="server" Text="" ForeColor ="Red"></asp:Label>
            <br />
            <asp:Button ID="button" runat="server" Text="Submit Promo Code" OnClick="submit_click" Width="167px" />
            <br />
        </div>
    </form>
</body>
</html>
