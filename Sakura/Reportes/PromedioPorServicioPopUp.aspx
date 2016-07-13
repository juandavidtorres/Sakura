<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePopUp.master" CodeBehind="PromedioPorServicioPopUp.aspx.vb" Inherits="Sakura.PromedioPorServicio" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ToolkitScriptManager>
    <rsweb:ReportViewer ID="Visor" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1000px" Height="465px">
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" 
         OldValuesParameterFormatString="original_{0}" 
        TypeName="Sakura.DataSetAsistenteTableAdapters.RecuperarPromedioPorServicioTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="FInicial" Type="DateTime" />
            <asp:Parameter Name="FFinal" Type="DateTime" />
            <asp:Parameter Name="TipoServicio" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

