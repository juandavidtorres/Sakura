<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="TiposdeAsistente.aspx.vb" Inherits="Sakura.TiposdeAsistente" %>

<%@ MasterType VirtualPath="~/MasterPagePrincipal.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <h5>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        Tipos de asistentes</h5>
    <p>Esta opcion permite que crear los tipos de asistentes que manejaran cada uno de los servicios (miembros,servidores y niños) </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="tabbable page-tabs">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#inside_panel" data-toggle="tab"><i class="icon-table2"></i>Crear tipo de asistente</a></li>
            <li><a href="#outside_panel" data-toggle="tab"><i class="icon-checkbox-partial"></i>Editar tipo de asistente</a></li>
        </ul>

        <!-- First tab -->
        <div class="tab-content">
            <div class="tab-pane active fade in" id="inside_panel">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h6 class="panel-title"><i class="icon-pencil3"></i></h6>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Descripcion <span class="mandatory">*</span></label>
                                <div class="col-sm-12">                                    
                                    <input type="text" id="txtNombre" name="txtnombre" Class="form-control" PlaceHolder="Descripcion" />
                                </div>
                            </div>
                        </div>

                        <script type="text/javascript">
                            jQuery(document).ready(function () {
                                $('#btnPrueba').click(function () {
                                    $('#form1').validate();

                                    var nombre = $('#txtNombre').val();

                                    if (nombre && (nombre != ''))
                                        sendDataAjax(nombre);
                                    else
                                        Mensajes('La descripcion es obligatoria', 1);
                                });
                            });

                            function sendDataAjax(nombre) {
                                var actionData = "{'txtDescripcion': '" + nombre + "'}";

                                $.ajax(
                                {
                                    url: "TiposdeAsistente.aspx/ProcesarInformacion",
                                    data: actionData,
                                    dataType: "json",
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    success: function (msg) { Mensajes('Registro creado exitosamente', 0); },
                                    error: function (xhr, status, error) {
                                        var err = eval("(" + xhr.responseText + ")");
                                        Mensajes(err.Message, 1);
                                    }
                                });
                            };

                            function LimpiarFormulario() {
                                $('#txtNombre').val('');

                            }
                        </script>
                            <div class="form-actions text-right">
                               <input type="button" id="btnPrueba" value="Guardar" Class="btn btn-primary" /> 
                               <input type="button" id="btnCancelar" onclick="LimpiarFormulario()" value="Cancelar" Class="btn btn-warning" />                                                                    
                            </div>                        
                    </div>

                </div>
            </div>
            <!-- Second tab -->

            <div class="tab-pane fade" id="outside_panel">
                <div class="row">
                    <div class="col-md-12">
                        <asp:UpdatePanel ID="UpdateGrilla" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GrillaTipoAsistente" runat="server"
                                    CssClass="table table-striped table-bordered" GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>                                     
                                        <asp:BoundField DataField="IdTipoAsistente" HeaderText="ID" Visible="True" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="True" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnEditar" CommandArgument='<%#Eval("IdTipoAsistente")%>' runat="server" CommandName="Editar" CssClass="btn btn-info" ToolTip="Editar" Text="Editar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnborrar" CommandArgument='<%#Eval("IdTipoAsistente")%>' CommandName="Eliminar" runat="server" CssClass="btn btn-danger" ToolTip="Eliminar" Text="Eliminar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="cursor-pointer" />
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- /iconified modal -->
    <!-- Form modal -->
    <asp:UpdatePanel ID="updatemodal" runat="server">
        <ContentTemplate>
            <div id="form_modal" class="modal fade" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><i class="icon-paragraph-justify2"></i>Asistentes</h4>
                        </div>

                        <!-- Form inside modal -->
                        <div class="modal-body with-padding">
                            <div class="block-inner text-danger">
                                <h6 class="heading-hr">Actualizacion de tipos de asistente<small class="display-block">Por favor introduzca la nueva descripcion</small></h6>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="control-label">Descripcion</label>
                                       
                                    </div>
                                    <div class="col-sm-12">
                                        <asp:TextBox ID="txtDescripcionEditar" runat="server" CssClass="form-control" PlaceHolder="Descripcion" ></asp:TextBox>                            
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="HiddenIdTipoPersona" runat="server" />
                        <div class="modal-footer">                                                       
                            <button class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Cancelar</button>                            
                            <asp:Button ID="btnActualizar" runat="server" Text="Guardar" CssClass="btn btn-primary"  UseSubmitBehavior="false" data-dismiss="modal"  />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
            
      

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="form_modalEliminar" class="modal modal" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title"><i class="icon-paragraph-justify2"></i>Tipos de asistentes</h4>
                        </div>
                        <!-- Form inside modal -->
                        <div class="modal-body with-padding">
                            <div class="block-inner text-info">
                                <h5>Eliminacion de tipos de asistente:</h5>
                                <asp:Label ID="lbldescripcion" CssClass="control-label" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div class="modal-footer">
                            <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-primary" Text="Eliminar" OnClick="btnEliminar_Click" UseSubmitBehavior="false" data-dismiss="modal" />
                            <button class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

