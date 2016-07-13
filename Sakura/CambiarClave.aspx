<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="CambiarClave.aspx.vb" Inherits="Sakura.CambiarClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ScriptManager>
    <!-- Basic inputs -->
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-checkmark3"></i>Cambio de credenciales</h6>
        </div>
        <div class="panel-body">
            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Cambio de password</h3>
                    <span>Ingrese el nuevo password</span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Usuario:</label>
                    <asp:TextBox ID="Txtusuario" CssClass="form-control" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                </div>
            </div>           
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Nuevo Password:</label>
                    <asp:TextBox ID="txtclaveconfirmar" CssClass="form-control" placeholder="Digite la clave" runat="server" ClientIDMode="Static" ValidationGroup="Clave" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"
                        runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtclaveconfirmar" ValidationGroup="Clave" ClientIDMode="Static"></asp:RequiredFieldValidator>
                   
                </div>
            </div>
            <div class="form-actions text-right">
                <div class="row">
                    <div class="form-group">
                        <asp:LinkButton ID="btnguardar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Fecha"><i class="icon-database"></i>Guardar</asp:LinkButton>
                        <asp:LinkButton ID="btncancelarEdicion" runat="server" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-cancel"></i>Cancelar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
