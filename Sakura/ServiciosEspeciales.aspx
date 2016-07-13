<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="ServiciosEspeciales.aspx.vb" Inherits="Sakura.ServiciosEspeciales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ScriptManager>--%>
    <asp:ToolkitScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ToolkitScriptManager>
    <h5>Servicios especiales</h5>
    <p>Esta opcion permite ingresar el consolidado de asistentes y vehiculos en los servicios especiales de la iglesia</p>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-info">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-calendar4"></i>Servicios Especiales</h6>
        </div>

        <div class="panel-body">
            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Registro del servicio</h3>
                    <span>Esta informacion corresponde a la fecha y servicio</span>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Descripcion:</label>
                    <asp:TextBox ID="txtDescripcionServicio" CssClass="form-control" placeholder="Descripcion del servicio.." runat="server" ClientIDMode="Static" ValidationGroup="Servicio"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescripcionservicio" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtDescripcionServicio" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>Fecha del servicio:</label>
                    <asp:TextBox ID="txtFechaServicio" CssClass="datepicker form-control" placeholder="Eliga la fecha..." runat="server" ClientIDMode="Static" ValidationGroup="Fecha"></asp:TextBox>
                    <script type="text/javascript">
                        $(function () {
                            $("#txtFechaServicioInicial").datepicker({ dateFormat: '<%=Fabrica.Utilidades.DevolverFormatoFecha()%>' }).val()
                        });
                    </script>
                    <asp:RequiredFieldValidator ID="ValidadorFecha" Display="Dynamic"
                        runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtFechaServicio" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidadorExpresionFecha" CssClass="label label-block label-danger" Text="*Fecha Invalida" ControlToValidate="txtFechaServicio" ClientIDMode="Static" runat="server" Display="Dynamic" ValidationGroup="Fecha" ValidationExpression="^([0]\d|[1][0-2])\/([0-2]\d|[3][0-1])\/([2][01]|[1][6-9])\d{2}(\s([0-1]\d|[2][0-3])(\:[0-5]\d){1,2})?$" ErrorMessage="*Fecha Invalida"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="col-sm-6">
                <div class="form-group">
                    <label>Hora Inicial:</label>
                    <asp:TextBox ID="txthorainicio" CssClass="form-control" placeholder="Descripcion del servicio.." runat="server" ClientIDMode="Static" ValidationGroup="Hora"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txthorainicio" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                </div>
                  <script>
                      $(function () {
                          $("#txthorainicio").timespinner();
                      });
                </script>
            </div>


            <div class="col-sm-6">
                <div class="form-group">
                    <label>Hora Fin:</label>
                    <asp:TextBox ID="txthorafin" CssClass="form-control" placeholder="Descripcion del servicio.." runat="server" ClientIDMode="Static" ValidationGroup="Hora"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txthorainicio" ValidationGroup="Fecha" ClientIDMode="Static"></asp:RequiredFieldValidator>
                </div>
                <script>
                    $(function () {
                        $("#txthorafin").timespinner();
                    });
                </script>
            </div>


            <div class="row invoice-header">
                <div class="col-sm-6">
                    <h3>Registro de asistentes</h3>
                    <span>Esta informacion corresponde al numero de asistentes por servicio</span>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="form-group">
                    <label>Categoria de asistente:</label>
                    <asp:DropDownList ID="txtTipoAsistente" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdateAgregarDetalleAsistente" runat="server">
                <ContentTemplate>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Cantidad:</label>
                            <asp:TextBox ID="txtCantidadAsistente" CssClass="form-control" placeholder="Digite el numero de personas que asistieron..." runat="server" ClientIDMode="Static" ValidationGroup="Asistente"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidadorAsistente" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtCantidadAsistente" ValidationGroup="Asistente" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="ExpresionValidadorSoloNumerosAsistentes" CssClass="label label-block label-danger" Text="*Solo se admiten numeros" ControlToValidate="txtCantidadAsistente" ClientIDMode="Static" runat="server" Display="Dynamic" ValidationGroup="Asistente" ValidationExpression="\d+" ErrorMessage="*Solo se admiten numeros"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="search-line">
                        <div class="form-group">
                            <asp:LinkButton ID="btnAgregarDetalleAsistente" runat="server" CausesValidation="True" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Asistente"><i class="icon-user"></i>Agregar</asp:LinkButton>
                        </div>
                        <asp:GridView ID="GrillaDetalleAsistente" runat="server"
                            CssClass="table table-striped table-bordered" GridLines="None"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IdTipoAsistente" HeaderText="IdTipoAsistente" Visible="False" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="True" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("IdTipoAsistente")%>' runat="server" CommandName="Eliminar" ToolTip="Editar" Text="Editar" ImageUrl="~/images/deleteGrilla.png" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                    <div class="row invoice-header">
                        <div class="col-sm-6">
                            <h3>Registro de vehiculos</h3>
                            <span>Esta informacion corresponde al numero de vehiculos por servicio</span>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Tipo de vehiculo:</label>
                            <asp:DropDownList ID="txtTipodevehiculo" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label>Cantidad:</label>
                            <asp:TextBox ID="txtCantidadVehiculo" CssClass="form-control" placeholder="Digite la cantidad de vehiculos..." runat="server" ClientIDMode="Static" ValidationGroup="Vehiculos"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"
                                runat="server" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtCantidadVehiculo" ValidationGroup="Vehiculos" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="label label-block label-danger" Text="*Solo se admiten numeros" ControlToValidate="txtCantidadVehiculo" ClientIDMode="Static" runat="server" Display="Dynamic" ValidationGroup="Vehiculos" ValidationExpression="\d+" ErrorMessage="*Solo se admiten numeros"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="search-line">
                        <div class="form-group">
                            <asp:LinkButton ID="btnAgregarvehiculos" runat="server" CssClass="btn btn-info" ClientIDMode="Static" CausesValidation="True" ValidationGroup="Vehiculos"><i class="icon-car"></i>Agregar</asp:LinkButton>
                        </div>
                        <asp:GridView ID="GrilladetalleVehiculo" runat="server"
                            CssClass="table table-striped table-bordered" GridLines="None"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IdTipoVehiculo" HeaderText="IdTipoVehiculo" Visible="False" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="True" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("IdTipoVehiculo")%>' runat="server" CommandName="Eliminar" ToolTip="Editar" Text="Editar" ImageUrl="~/images/deleteGrilla.png" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="cursor-pointer" />
                        </asp:GridView>
                    </div>
                    <div class="row invoice-header">
                        <div class="col-sm-6">
                            <h3>Comentarios</h3>
                            <span>Agregar un comentario o anotacion sobre el servicio </span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label>Notas:</label>
                                <asp:TextBox ID="txtComentarioServicio" Rows="5" cols="5" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions text-right">
                        <div class="row">
                            <div class="form-group">
                                <asp:LinkButton ID="btnguardar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Fecha"><i class="icon-database"></i>Guardar</asp:LinkButton>
                                <asp:LinkButton ID="btncancelar" runat="server" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-cancel"></i>Cancelar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAgregarDetalleAsistente" />
                    <asp:AsyncPostBackTrigger ControlID="btnAgregarvehiculos" />
                    <asp:AsyncPostBackTrigger ControlID="btnguardar" />
                    <asp:AsyncPostBackTrigger ControlID="btncancelar" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

