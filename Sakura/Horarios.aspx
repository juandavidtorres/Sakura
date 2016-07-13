<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="Horarios.aspx.vb" Inherits="Sakura.Horarios" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="Server">
    <script type="text/javascript">
        function ConfigurarFecha() {

            $("#HoraInicial").datepicker({ dateFormat: '<%=Fabrica.Utilidades.DevolverFormatoFecha()%>' }).val();
            $("#HoraFinal").datepicker({ dateFormat: '<%=Fabrica.Utilidades.DevolverFormatoFecha()%>' }).val();

        }
        function ConfigurarCss() {
            document.getElementById('HoraInicial').className = 'datepicker form-control';  // this adds the error class
            $('#HoraInicial').datepicker({
                dateFormat: 'mm/dd/yy',
                defaultDate: '20/03/2014'
            });

            document.getElementById('HoraFinal').className = 'datepicker form-control';  // this adds the error class
            $("#HoraFinal").timespinner();
            $("#HoraInicial").timespinner();

        }

        function SetValue(FInicio, FFin) {
            $("#HoraFinal").val(FInicio);
            $("#HoraInicial").val(FFin);
        }
    </script>
    <h5>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        Horarios</h5>
    <p>Esta opcion permite que crear los horarios que manejaran cada uno de los servicios que se manejaran</p>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="tabbable page-tabs">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#inside_panel" data-toggle="tab"><i class="icon-table2"></i>Crear Horario</a></li>
            <li><a href="#outside_panel" data-toggle="tab"><i class="icon-checkbox-partial"></i>Editar Horario</a></li>
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
                            <div class="col-md-6">
                                <label class="col-sm-6 control-label">Hora Inicial: <span class="mandatory">*</span></label>
                                <input type="text" class="form-control" id="HoraInicial" name="HoraInicial" placeholder="08:30 PM">
                                <script>
                                    $(function () {
                                        $("#HoraInicial").timespinner();
                                    });
                                </script>
                            </div>
                            <div class="col-md-6">
                                <label class="col-sm-6 control-label">Hora Final: <span class="mandatory">*</span></label>
                                <input type="text" class="form-control" id="HoraFinal" name="HoraFinal" placeholder="08:30 PM">
                                <script>
                                    $(function () {
                                        $("#HoraFinal").timespinner();
                                    });
                                </script>
                            </div>
                        </div>
                        <div class="form-actions text-right">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanelCrearHorario" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnEnviar" runat="server" CssClass="btn btn-info" ClientIDMode="Static" ValidationGroup="Fecha"><i class="icon-database"></i>Guardar</asp:LinkButton>
                                            <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-cancel"></i>Cancelar</asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

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
                                <asp:GridView ID="GrillaHorario" runat="server"
                                    CssClass="table table-striped table-bordered" GridLines="None"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicial" Visible="True" />
                                        <asp:BoundField DataField="HoraFin" HeaderText="Hora Final " />
                                        <asp:BoundField DataField="IdHorario" HeaderText="ID" Visible="false" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEditar" CommandArgument='<%#Eval("IdHorario")%>' runat="server" CommandName="Editar" ToolTip="Editar" Text="Editar" ImageUrl="~/images/EditarGrilla.png" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnborrar" CommandArgument='<%#Eval("IdHorario")%>' CommandName="Eliminar" runat="server" ToolTip="Borrar" Text="Borrar" ImageUrl="~/images/deleteGrilla.png" />
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="form_modal" class="modal fade" tabindex="-1" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><i class="icon-paragraph-justify2"></i>Horario</h4>
                        </div>

                        <!-- Form inside modal -->
                        <div class="modal-body with-padding">
                            <div class="block-inner text-danger">
                                <h6 class="heading-hr">Actualizacion de horario<small class="display-block">Por favor introduzca el nuevo horario</small></h6>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <label class="control-label">Hora Inicio</label>
                                        <asp:TextBox ID="HoraIncioAct" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-12">
                                        <label class="control-label">Hora Final</label>
                                        <asp:TextBox ID="HoraFinalAct" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="HiddenIdHorario" runat="server" />
                        <div class="modal-footer">
                            <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnActualizar_Click" UseSubmitBehavior="false" data-dismiss="modal" />
                            <button class="btn btn-warning" data-dismiss="modal" aria-hidden="true">Cancelar</button>
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
                            <h4 class="modal-title"><i class="icon-paragraph-justify2"></i>Horario</h4>
                        </div>
                        <!-- Form inside modal -->
                        <div class="modal-body with-padding">
                            <div class="block-inner text-info">
                                <h5>Eliminacion de horario:</h5>
                                <asp:Label ID="lblHorasaBorrar" CssClass="control-label" runat="server" Text=""></asp:Label>
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
