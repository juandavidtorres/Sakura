<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="EditarUsuarios.aspx.vb" Inherits="Sakura.EditarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ScriptManager>
    <!-- Basic inputs -->
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-user-plus3"></i>Editar Usuario</h6>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpVista" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GrillaUsuarios" runat="server"
                        CssClass="table table-striped table-bordered" GridLines="None"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" Visible="True" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="FechaCreacion" HeaderText="FechaCreacion" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("Usuario")%>' runat="server" CommandName="Editar" ToolTip="Cambiar contraseña" Text="Editar" ImageUrl="~/images/CambioClave.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnActivar" CommandArgument='<%#Eval("Usuario")%>' runat="server" CommandName="Desbloquear" ToolTip="Desbloquear" Text="Desbloquear" ImageUrl="~/images/desbloquear.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="cursor-pointer" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btncancelarEdicion" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdateVista" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:MultiView ID="Contenedor" runat="server" ActiveViewIndex="-1">
                <asp:View ID="ViewDetalle" runat="server">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h6 class="panel-title"><i class="icon-checkmark3"></i>Servicios Almacenados</h6>
                        </div>
                        <div class="panel-body">
                            <div class="row invoice-header">
                                <div class="col-sm-6">
                                    <h3>Cambio de contraseña</h3>
                                    <span>Ingrese la nueva contraseña</span>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Usuario:</label>
                                    <asp:TextBox ID="Txtusuario" CssClass="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Contraseña:</label>
                                    <asp:TextBox ID="txtclave" CssClass="form-control" placeholder="Clave" runat="server" ClientIDMode="Static" ValidationGroup="Clave"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ValidadorFecha" Display="Dynamic" runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtclave" ValidationGroup="Clave" ClientIDMode="Static"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Confirmar Contraseña:</label>
                                    <asp:TextBox ID="txtclaveconfirmar" CssClass="form-control" placeholder="Confirme clave" runat="server" ClientIDMode="Static" ValidationGroup="Clave"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"
                                        runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtclaveconfirmar" ValidationGroup="Clave" ClientIDMode="Static"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="Comparador" runat="server" Display="Static" ErrorMessage="*Contraseñas no coinciden" ControlToCompare="txtclave" ControlToValidate="txtclaveconfirmar" CssClass="label label-block label-danger" ValidationGroup="Clave"
                                        Operator="Equal" Type="String" />
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
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

