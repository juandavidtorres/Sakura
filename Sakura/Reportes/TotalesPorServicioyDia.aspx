<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePopUp.master" CodeBehind="TotalesPorServicioyDia.aspx.vb" Inherits="Sakura.TotalesPorServicioyDia" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ToolkitScriptManager>
    <rsweb:ReportViewer ID="Visor" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1000px" Height="665px">
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" 
         OldValuesParameterFormatString="original_{0}" 
        TypeName="Sakura.DataSetAsistenteTableAdapters.RecuperarAsistenciaTotalDominicalTableAdapter">
        <SelectParameters>
            <asp:Parameter Name="FechaInicio" Type="DateTime" />
            <asp:Parameter Name="FechaFin" Type="DateTime" />
            <asp:Parameter Name="IdTipoServicio" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>