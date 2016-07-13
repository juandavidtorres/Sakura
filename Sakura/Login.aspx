<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageLogin.master" CodeBehind="Login.aspx.vb" Inherits="Sakura.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLoging" runat="Server">
    <div class="well">
        <div class="form-group has-feedback">
            <label>Username</label>
            <asp:TextBox ID="txtusuario" runat="server" ClientIDMode="Static" CssClass="form-control" PlaceHolder="Usuario"></asp:TextBox>
            <i class="icon-users form-control-feedback"></i>
        </div>

        <div class="form-group has-feedback">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" CssClass="form-control" PlaceHolder="Clave" TextMode="Password"></asp:TextBox>
            <i class="icon-lock form-control-feedback"></i>
        </div>

        <div class="row form-actions">            
            <div class="col-xs-6">
               
                <asp:LinkButton ID="btnIniciar" runat="server" CssClass="btn btn-warning pull-right" ClientIDMode="Static" ValidationGroup="Login"><i class="icon-menu2"></i>Iniciar sesion</asp:LinkButton>
            </div>
        </div>
        <div class="form-group has-feedback">
             <asp:Label ID="txtErrror" runat="server" CssClass="label label-block label-danger">
                </asp:Label>
        </div>
    </div>
</asp:Content>
