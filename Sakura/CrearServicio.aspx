<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="CrearServicio.aspx.vb" Inherits="Sakura.CrearServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
      <h5>        
        Servicios</h5>
    <h6>Esta opcion permite que crear cada uno de los servicios que maneja la iglesia</h6>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManagerCrearServicio" runat="server"></asp:ScriptManager>
    <!-- Basic inputs -->
    <div class="panel panel-default">
        <div class="panel-heading">
            <h6 class="panel-title"><i class="icon-bubble4"></i>Crear Servicio</h6>
            <div class="btn-roup pull-right">
                <button type="button" class="btn btn-info" onclick="MostrarModal(1,'options-modal')"><i class="icon-plus"></i>Agregar Servicio</button>
                <asp:LinkButton ID="SelectButton" runat="server" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-shuffle"></i>Refrescar Consulta</asp:LinkButton>
            </div>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="UpdatePanelGrillaPrincipal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GrillaServicios" runat="server"
                        CssClass="table table-striped table-bordered" GridLines="None"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="IdServicio" HeaderText="Id Servicio" Visible="False" />
                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" />
                            <asp:BoundField DataField="Codigo" HeaderText="CODIGO" />
                            <asp:BoundField DataField="Comentario" HeaderText="COMENTARIO" />
                            <asp:BoundField DataField="Horario" HeaderText="HORARIO" />
                            <asp:BoundField DataField="DescripcionServicio" HeaderText="TIPO" />
                            <asp:BoundField DataField="IdHorario" HeaderText="IDHORARIO" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("IdServicio")%>' runat="server" CommandName="Editar" ToolTip="Editar" Text="Editar" ImageUrl="~/images/EditarGrilla.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnborrar" CommandArgument='<%#Eval("IdServicio")%>' CommandName="Eliminar" runat="server" ToolTip="Borrar" Text="Borrar" ImageUrl="~/images/deleteGrilla.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="cursor-pointer" />
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="SelectButton" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>


    <div id="DivActualizarGrilla" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                </div>
                <div class="modal-body with-padding">
                    <span class="legend text-danger">Informacion del servicio
									Por favor ingresa la siguiente informacion
                    </span>                  

                    <asp:UpdatePanel ID="updateModalActualizar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="HFIdServicio" runat="server" ClientIDMode="Static" />
                            <div class="form-group">
                                <label>Horario:</label>
                                <asp:DropDownList ID="txtHorarioActualizar" runat="server" placeholder="Eliga un horario..." CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>TipoServicio:</label>
                                <asp:DropDownList ID="txtTipoServicioActualizar" runat="server" data-placeholder="Eliga un tipo de servicio..." CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label>Descripcion</label>
                                        <asp:TextBox ID="txtDescripcionActulizar" runat="server" CssClass="form-control" placeholder="Digite una descripcion para servicio" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-6">
                                        <label class="control-label">Codigo</label>
                                        <asp:TextBox ID="txtCodigoActualizar" runat="server" CssClass="form-control" placeholder="Asigne un codigo al servicio" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>                            
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <label>Comentario</label>
                                        <asp:TextBox ID="txtComentarioEditar" runat="server" CssClass="form-control" placeholder="Campo Opcional" ClientIDMode="Static"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
                <div class="modal-footer">
                    <button type="button" id="btncancelar" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="btnActualizar" class="btn btn-primary">Guardar</button>
                </div>
            </div>
        </div>
    </div>

  

    <div id="options-modal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title"><i class="icon-paragraph-justify2"></i>Crear servicio</h4>
                </div>


                <div class="modal-body with-padding">
                    <span class="legend text-danger">Informacion del servicio
									    Por favor ingresa la siguiente informacion
                    </span>

                    <div class="form-group">
                        <label>Horario:</label>
                        <asp:DropDownList ID="txtHorario" runat="server" data-placeholder="Eliga un horario..." CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                    </div>

                    
                    <div class="form-group">
                        <label>Tipo de Servicio:</label>
                        <asp:DropDownList ID="txtTipoServicio" runat="server" data-placeholder="Eliga un Servicio..." CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label>Descripcion</label>
                                <input type="text" id="txtDescripcion" name="txtDescripcion" placeholder="Digite una descripcion para servicio" class="form-control">
                            </div>

                            <div class="col-sm-6">
                                <label class="control-label">Codigo</label>
                                <input type="text" id="txtCodigo" name="txtCodigo" placeholder="Asigne un codigo al servicio" class="form-control">
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-6">
                                <label>Comentario</label>
                                <input type="text" id="txtComentario" name="txtComentario" class="form-control">
                            </div>
                        </div>
                    </div>


                </div>

                <div class="modal-footer">
                    <button type="button" id="btnCerrar" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="btnCrear" class="btn btn-primary" data-dismiss="modal">Guardar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function MostrarModal(mostrar, modal) {
            if (mostrar == 1)
                $('#' + modal).modal('show');
            else
                $('#' + modal).modal('hide');
        }



        jQuery(document).ready(function () {
            $('#btnCrear').click(function () {
                $('#form1').validate();
                var Descripcion = $('#txtDescripcion').val();
                var Comentario = $('#txtComentario').val();
                var Codigo = $('#txtCodigo').val();

                if (Descripcion && (Descripcion != '')) {
                    if (Codigo && (Codigo != '')) {
                        CrearServicio();
                    }
                    else
                        Mensajes('El codigo es obligatorio', 1);
                }
                else
                    Mensajes('La descripcion es obligatoria', 1);
            });

            $('#btnActualizar').click(function () {
                $('#form1').validate();

                var Descripcion = $('#txtDescripcionActulizar').val();
                var Comentario = $('#txtComentarioEditar').val();
                var Codigo = $('#txtCodigoActualizar').val();


                if (Descripcion && (Descripcion != '')) {
                    if (Codigo && (Codigo != '')) {
                        ActualizarServicio();
                    }
                    else
                        Mensajes('El codigo es obligatorio', 1);
                }
                else
                    Mensajes('La descripcion es obligatoria', 1);
            });
        });

        function ActualizarServicio() {

            var Descripcion = $('#txtDescripcionActulizar').val();
            var Comentario = $('#txtComentarioEditar').val();
            var Codigo = $('#txtCodigoActualizar').val();

            var e = document.getElementById("txtHorarioActualizar");//Recupero el Dropdownlist de horarios en el cliente para actualizar el servido
            var Horario = e.options[e.selectedIndex].value;
            e = document.getElementById("txtTipoServicioActualizar");//Recupero el Dropdownlist de tipos de servicio en el cliente para actualizar el servido
            var TipoServicio = e.options[e.selectedIndex].value;
            var IdServicio = $('#HFIdServicio').val();
            var actionData = "{'IdHorario': '" + Horario + "','Descripcion':'" + Descripcion + "','Codigo':'" + Codigo + "','Comentario':'" + Comentario + "'" + ",'IdServicio':'" + IdServicio + "','IdTipoServicio':'" + TipoServicio + "'}";

            $.ajax({
                type: "POST",
                url: "CrearServicio.aspx/ActualizarServicio",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                success: function (resultado) {
                    Mensajes('Registro creado exitosamente', 0);
                    MostrarModal(0, 'DivActualizarGrilla');
                    var objectoHtml = 'SelectButton';
                    var boton = document.getElementById(objectoHtml);
                    LimpiarControles('0');
                    boton.click();

                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    Mensajes(err.Message, 1);
                }
            });
        }

        function CrearServicio() {
            var Descripcion = $('#txtDescripcion').val();
            var Comentario = $('#txtComentario').val();
            var Codigo = $('#txtCodigo').val();

            var e = document.getElementById("txtHorario");
            var Horario = e.options[e.selectedIndex].value; //will give you 3

            e = document.getElementById("txtTipoServicio");
            var TipoServicio = e.options[e.selectedIndex].value; //will give you 4

            var actionData = "{'IdHorario': '" + Horario + "','Descripcion':'" + Descripcion + "','Codigo':'" + Codigo + "','Comentario':'" + Comentario + "','TipoServicio':'" + TipoServicio + "'}";

            $.ajax({
                type: "POST",
                url: "CrearServicio.aspx/CrearServicio",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                data: actionData,
                success: function (resultado) {
                    Mensajes('Registro creado exitosamente', 0);
                    MostrarModal(0, 'options-modal');
                    var objectoHtml = 'SelectButton';
                    var boton = document.getElementById(objectoHtml);
                    LimpiarControles('1');
                    boton.click();

                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    Mensajes(err.Message, 1);
                }
            });
        }

        function LimpiarControles(TipoLimpieza) {
            //Controles de nuevo servicio
            if (TipoLimpieza == '1') {
                $('#txtDescripcion').val('');
                $('#txtComentario').val('');
                $('#txtCodigo').val('');
            }
                //Controles de actualizar servicio
            else {
                $('#txtDescripcionActulizar').val('');
                $('#txtComentarioEditar').val('');
                $('#txtCodigoActualizar').val('');
            }
        }
    </script>

</asp:Content>

