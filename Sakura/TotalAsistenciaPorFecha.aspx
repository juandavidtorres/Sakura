<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="TotalAsistenciaPorFecha.aspx.vb" Inherits="Sakura.TotalAsistenciaPorFecha" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <asp:ToolkitScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ToolkitScriptManager>

</asp:Content>
<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            function ConfigurarFormato(Finicio, FFin) {
                $('#' + '<%=txtFechaServicioInicial.ClientID%>').datepicker({
                    dateFormat: 'MM/dd/yy'

                });

                $('#' + '<%=txtFechaServicioFinal.ClientID%>').datepicker({
                    dateFormat: 'MM/dd/yy'

                });


                document.getElementById('<%=txtFechaServicioInicial.ClientID%>').className = 'datepicker form-control';  // this adds the error class
                document.getElementById('<%=txtFechaServicioFinal.ClientID%>').className = 'datepicker form-control';  // this adds the error class

            }
            ConfigurarFormato();

        });
    </script>

    <asp:HiddenField ID="txtFormatoFecha" runat="server" />
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-search2"></i>Asistencia total servicios domincales</h6>
        </div>
        <div class="panel-body">
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Fecha Inicial:</label>
                    <asp:TextBox ID="txtFechaServicioInicial" CssClass="form-control" runat="server" placeholder="Eliga la fecha..." ClientIDMode="Static" ValidationGroup="Fecha"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="ValidadorFechaIncial" Display="Dynamic"
                        runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtFechaServicioInicial" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Fecha Final:</label>
                    <asp:TextBox ID="txtFechaServicioFinal" CssClass="form-control" placeholder="Eliga la fecha..." runat="server" ClientIDMode="Static" ValidationGroup="Fecha"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="ValidadorFechaFinal" Display="Static"
                        runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtFechaServicioFinal" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Tipo Asistente:</label>
                    <asp:DropDownList ID="txtTipoPersona" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                </div>
            </div>
              <div class="col-sm-6">
                <div class="form-group">
                    <label>Exportar a:</label>
                    <asp:DropDownList ID="txtformato" runat="server" CssClass="form-control" ClientIDMode="Static">
                        <asp:ListItem>Excel</asp:ListItem>
                        <asp:ListItem>PDF</asp:ListItem>
                        <asp:ListItem>Word</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-6">
                <asp:UpdatePanel ID="updpanelreporte" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <asp:LinkButton ID="btnbuscar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Fecha"><i class="icon-search3"></i>Buscar</asp:LinkButton>
                            <asp:LinkButton ID="btncancelar" runat="server" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-cancel"></i>Cancelar</asp:LinkButton>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnbuscar" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
