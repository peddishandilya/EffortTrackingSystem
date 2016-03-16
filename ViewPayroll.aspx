<%@ Page Title="" Language="C#" MasterPageFile="~/ETS.Master" AutoEventWireup="true" CodeBehind="ViewPayroll.aspx.cs" Inherits="EffortTrackingSystem.ViewPayroll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlMonth_SelectedIndexChanged">
<asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
<asp:ListItem Text="Jan" Value="1"></asp:ListItem>
<asp:ListItem Text="Feb" Value="2"></asp:ListItem>
<asp:ListItem Text="Mar" Value="3"></asp:ListItem>
<asp:ListItem Text="Apr" Value="4"></asp:ListItem>
<asp:ListItem Text="May" Value="5"></asp:ListItem>
<asp:ListItem Text="Jun" Value="6"></asp:ListItem>
<asp:ListItem Text="Jul" Value="7"></asp:ListItem>
<asp:ListItem Text="Aug" Value="8"></asp:ListItem>
<asp:ListItem Text="Sep" Value="9"></asp:ListItem>
<asp:ListItem Text="Oct" Value="10"></asp:ListItem>
<asp:ListItem Text="Nov" Value="11"></asp:ListItem>
<asp:ListItem Text="Dec" Value="12"></asp:ListItem>

</asp:DropDownList>

<asp:Panel ID="pnlSalary" runat="server" BackColor="AliceBlue" BorderStyle="Solid" BorderWidth="2px" Height="250px" Width="350px">
<table><tr><td><asp:Label ID="lblSalDisplay" runat="server" Text=""></asp:Label></td></tr>
<tr><td style="font-family: 'Arial Unicode MS'"><asp:Button ID="btnCancel" 
        runat="server" Text="Cancel" Font-Names="Arial Unicode MS" /></td></tr>
</table>

</asp:Panel>
    <aj1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btndummy"  PopupControlID="pnlSalary" CancelControlID="btnCancel">
    </aj1:ModalPopupExtender>
     <asp:Button ID="btndummy" runat="server" style="display:none" />

</asp:Content>
