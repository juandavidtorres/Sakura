<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="UsuarioSucursal.aspx.vb" Inherits="Sakura.UsuarioSucursal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="server">
    <h4>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        Tipos de asistentes</h4>
    <p>Esta opcion permite que asociar a los usuarios a su respectiva iglesia</p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h4 class="panel-title"><i class="icon-search2"></i>Iglesias</h4>
        </div>
        <div class="panel-body">

            <div class="col-sm-4">
                <div class="form-group">
                    <div class="row">
                        <label>Pastor:</label>
                        <asp:DropDownList ID="txtusuario" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="row">
                    <div class="form-group">
                        <label>Ciudad:</label>
                        <asp:DropDownList ID="txtentidad" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="col-sm-4">
                <div class="form-group">
                    <asp:LinkButton ID="btnguardar" runat="server" ValidationGroup="Entidad" CausesValidation="true" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-database2" ></i>Guardar</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
