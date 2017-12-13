<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="INTROSE_JGC.Admin.UserManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="Username" />
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlRoles" runat="server">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" Text="Update" runat="server" CommandArgument='<%# Eval("EMPLOYEE_ID") %>'
                        OnClick="UpdateRole" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label runat="server" ID="lblState"></asp:Label>
    </div>
    </form>
</body>
</html>
