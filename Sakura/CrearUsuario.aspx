<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="CrearUsuario.aspx.vb" Inherits="Sakura.CrearUsuario" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <asp:ScriptManager ID="ScriptManagerUsuarios" runat="server"></asp:ScriptManager>

    <h5>Crear usuario</h5>
    <p>Esta opcion permite crear los usuarios y asignarlos a su respectivo rol </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-user-plus"></i></h6>
        </div>

        <div class="panel-body">
            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Informacion</h3>
                    <span>Datos de inicio de sesion del usuario</span>
                </div>
            </div>
            <asp:UpdatePanel ID="UdpUsuario" runat="server">
                <ContentTemplate>
                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Usuario:</label>
                            <asp:TextBox ID="txtusuario" CssClass="form-control" placeholder="Descripcion del servicio.." runat="server" ClientIDMode="Static" ValidationGroup="Servicio"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidadorAsistente" Display="Static" runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtusuario" ValidationGroup="Asistente" ClientIDMode="Static"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Clave:</label>
                            <asp:TextBox ID="txtClave" CssClass="form-control" placeholder="Contraseña" runat="server" ClientIDMode="Static" ValidationGroup="Servicio" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidadorClave" Display="Static" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtClave" ValidationGroup="Asistente" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="Comparador" runat="server" Display="Static" ErrorMessage="*Contraseñas no coinciden" ControlToCompare="txtClave" ControlToValidate="txtclaveconfirmacion" CssClass="label label-block label-danger" ValidationGroup="Asistente" Operator="Equal" Type="String" />
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Confirmar Clave:</label>
                            <asp:TextBox ID="txtclaveconfirmacion" CssClass="form-control" placeholder="Confirmar contraseña" runat="server" ClientIDMode="Static" ValidationGroup="Servicio" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidadorClaveConfirmar" Display="Static" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtclaveconfirmacion" ValidationGroup="Asistente" ClientIDMode="Static"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>E-Mail:</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="E-mail" runat="server" ClientIDMode="Static" ValidationGroup="Servicio"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="ValidadorCorreo" Display="Static" runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtEmail" ValidationGroup="Asistente" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="ExpresionValidadorCorreo" CssClass="label label-block label-danger" Text="*Correo invalido" ControlToValidate="txtEmail" ClientIDMode="Static" runat="server" Display="Static" ValidationGroup="Asistente" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" ErrorMessage="*Correo Invalido"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Rol</label>
                            <asp:DropDownList ID="txtrol" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <label>Estado</label>
                            <asp:DropDownList ID="txtestado" runat="server" CssClass="form-control" ClientIDMode="Static">
                                <asp:ListItem Value="True">Activo</asp:ListItem>
                                <asp:ListItem Value="False">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-6">
                            <asp:LinkButton ID="btnguardar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Asistente"><i class="icon-database"></i>Registrar Usuario</asp:LinkButton>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnguardar" />
                </Triggers>
            </asp:UpdatePanel>

        </div>

    </div>

</asp:Content>

