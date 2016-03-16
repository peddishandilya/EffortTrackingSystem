<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true"
    CodeBehind="ManageTask.aspx.cs" Inherits="EffortTrackingSystem.ManageTask" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tbleditprofile" runat="server" cellpadding="2" cellspacing="0" 
        
        style="height: 281px;
        width: 412px; margin-left: 1px; margin-top: 0px; border-style: solid; border-width: 2px; font-family: 'Arial Unicode MS'; color: #CCCCCC;">
        <tr>
            <td style="width: 329px">
                <asp:Label ID="lblRegistration" runat="server" Font-Bold="True" Text="Select Department"
                    Font-Size="Small" ForeColor="#FF6600" Font-Names="Arial Unicode MS"></asp:Label>
            </td>
            <td style="width: 209px">
                <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <br />
            </td>
            <td style="width: 11px">
                &nbsp;
            </td>
        </tr>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtage" ErrorMessage="Enter Age"></asp:RequiredFieldValidator>--%>
        <tr>
            <td align="center" style="width: 329px">
                <asp:Label ID="Label1" runat="server" Text="Subject" 
                    Font-Names="Arial Unicode MS"></asp:Label>
                <br />
            </td>
            <td style="width: 209px">
                <asp:DropDownList ID="ddlTask" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlTask_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 11px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTask"
                    ErrorMessage="select Task" InitialValue="--Select--">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 329px; font-family: 'Arial Unicode MS';">
                <asp:Label ID="lblMaxleave" runat="server" Text="TaskName"></asp:Label>
                <br />
            </td>
            <td style="width: 209px">
                <asp:TextBox ID="txtTaskName" runat="server" Enabled="true"></asp:TextBox>
            </td>
            <td style="width: 11px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTaskName"
                    ErrorMessage="Enter Subject">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 329px">
                <asp:Label ID="Label2" runat="server" Text="Status" 
                    Font-Names="Arial Unicode MS"></asp:Label>
                <br />
            </td>
            <td style="width: 209px">
              <asp:DropDownList ID="ddlStatus" runat="server">
              <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
             <asp:ListItem Text="InActive" Value="InActive"></asp:ListItem>
              </asp:DropDownList>
            </td>
            <td style="width: 11px">
               
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Button ID="btnUpdate" runat="server" BackColor="#FF9900" Style="margin-left: 0px"
                    Text="Save" Width="69px" onclick="btnUpdate_Click" 
                    Font-Names="Arial Unicode MS"  />
                <asp:Button ID="btnCancel" runat="server" BackColor="#FF9900" CausesValidation="False"
                    Text="Cancel" Font-Names="Arial Unicode MS" Width="69px" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="font-family: 'Arial Unicode MS'">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" Font-Names="Arial Unicode MS" />
                <asp:Label ID="lblmessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
