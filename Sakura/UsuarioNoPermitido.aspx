<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPageErrores.master" CodeBehind="UsuarioNoPermitido.aspx.vb" Inherits="Sakura.UsuarioNoPermitido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" Runat="Server">
    <div class="row">
		        <div class="col-md-6">		            
                     <asp:LinkButton ID="btnlogin" runat="server" CssClass="btn btn-danger btn-block" ClientIDMode="Static"><i class="icon-database"></i>Autenticacion de usuarios</asp:LinkButton>
                                          
	            </div>
	            <div class="col-md-6">
		            <asp:LinkButton ID="btnInicio" runat="server" CssClass="btn btn-danger btn-block" ClientIDMode="Static"><i class="icon-database"></i>Pagina de inicio</asp:LinkButton>
	            </div>
        </div>
</asp:Content>