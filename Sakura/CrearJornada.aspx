<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterBancoAlimentos.master" CodeBehind="CrearJornada.aspx.vb" Inherits="Sakura.CrearJornada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="server">
    <asp:ScriptManager ID="ScriptManagerJornada" runat="server">
    </asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-search2"></i>Crear jornada</h6>
        </div>
        <div class="panel-body">
            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Datos generales</h3>
                    <span>Esta informacion corresponde a fechas en que se realizo la campaña</span>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Descripcion:</label>
                        <asp:TextBox ID="txtdescripcion" CssClass="form-control" placeholder="Digite el numero de personas que asistieron..." runat="server" ClientIDMode="Static" ValidationGroup="DatosBasicos"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidadorAsistente" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtdescripcion" ValidationGroup="DatosBasicos" ClientIDMode="Static"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Fecha de inicio:</label>
                        <asp:TextBox ID="txtFechaInicio" CssClass="datepicker form-control" placeholder="Eliga la fecha..." runat="server" ClientIDMode="Static" ValidationGroup="Fecha"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic"
                            runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtFechaInicio" ValidationGroup="DatosBasicos" ClientIDMode="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidadorExpresionFecha" CssClass="label label-block label-danger" Text="*Fecha Invalida" ControlToValidate="txtFechaInicio" ClientIDMode="Static" runat="server" Display="Dynamic" ValidationGroup="DatosBasicos" ValidationExpression="^(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d\d$" ErrorMessage="*Fecha Invalida"></asp:RegularExpressionValidator>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <label>Fecha de Finalizacion:</label>
                        <asp:TextBox ID="txtfechafinal" CssClass="datepicker form-control" placeholder="Eliga la fecha..." runat="server" ClientIDMode="Static" ValidationGroup="Fecha"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic"
                            runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtfechafinal" ValidationGroup="DatosBasicos" ClientIDMode="Static"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="label label-block label-danger" Text="*Fecha Invalida" ControlToValidate="txtfechafinal" ClientIDMode="Static" runat="server" Display="Dynamic" ValidationGroup="DatosBasicos" ValidationExpression="^(0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])[-/.](19|20)\d\d$" ErrorMessage="*Fecha Invalida"></asp:RegularExpressionValidator>

                    </div>
                </div>

            </div>
            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Cantidades por servicio</h3>
                    <span>En esta seccion se configura la cantidad recogida en cada uno de los servicio del dia</span>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="form-group">
                    <label>Servicio</label>
                    <asp:DropDownList ID="txtServicio" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                </div>

            </div>
            <asp:UpdatePanel ID="UpdateAgregarDetalleAsistente" runat="server">
                <ContentTemplate>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtcantidad" CssClass="form-control" placeholder="Digite el numero de personas que asistieron..." runat="server" ClientIDMode="Static" ValidationGroup="Valores"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtcantidad" ValidationGroup="Valores" ClientIDMode="Static"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <div class="search-line">
                        <div class="form-group">
                            <asp:LinkButton ID="btnguardarCantidad" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Valores"><i class="icon-plus"></i>Guardar</asp:LinkButton>
                        </div>
                        <div class="col-lg-5">
                            <div class="form-group">
                                <div class="row">
                                    <asp:GridView ID="GrillaDetalleAsistente" runat="server"
                                        CssClass="table table-striped table-bordered" GridLines="None"
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="IdServicio" HeaderText="IdServicio" Visible="False" />
                                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="True" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("IdServicio")%>' runat="server" CommandName="Eliminar" ToolTip="Editar" Text="Editar" ImageUrl="~/images/deleteGrilla.png" CausesValidation="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="cursor-pointer" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </div>
                    </div>


                    <div class="form-actions text-right">
                        <div class="row">

                            <div class="form-group">
                                <asp:LinkButton ID="btnguardar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="DatosBasicos"><i class="icon-database"></i>Guardar</asp:LinkButton>
                            </div>

                        </div>
                    </div>


                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnguardarCantidad" />
                    <asp:AsyncPostBackTrigger ControlID="btnguardar" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
