<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPagePrincipal.master" CodeBehind="Iglesia.aspx.vb" Inherits="Sakura.Iglesia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderDescripcion" runat="server">
    <h4>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        Tipos de asistentes</h4>
    <p>Esta opcion permite que crear cada una de la iglesias que intervienen en los procesos operativos </p>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updpanelreporte" runat="server">
        <ContentTemplate>
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h4 class="panel-title"><i class="icon-search2"></i>Iglesias</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Nombre:</label>
                                <asp:TextBox ID="txtnombre" CssClass="form-control" placeholder="Nombre" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValidadorAsistente" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtnombre" ValidationGroup="Entidad" ClientIDMode="Static"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label>Direccion:</label>
                                <asp:TextBox ID="txtdireccion" CssClass="form-control" placeholder="Direccion" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txtdireccion" ValidationGroup="Entidad" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-4">
                        <div class="form-group">
                            <div class="row">
                                <label>Pastor:</label>
                                <asp:DropDownList ID="txtPastor" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="row">
                            <div class="form-group">
                                <label>Ciudad:</label>
                                <asp:DropDownList ID="txtciudad" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                <label>Telefono:</label>
                                <asp:TextBox ID="txttelefono" CssClass="form-control" placeholder="Telefono" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" Text="" ErrorMessage="*Campo Obligatorio" CssClass="label label-block label-danger" ControlToValidate="txttelefono" ValidationGroup="Entidad" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4">

                        <div class="form-group">
                            <asp:LinkButton ID="btnguardar" runat="server" ValidationGroup="Entidad" CausesValidation="true" CssClass="btn btn-info" ClientIDMode="Static"><i class="icon-database2" ></i>Guardar</asp:LinkButton>
                            <asp:LinkButton ID="btncancelar" runat="server" CssClass="btn btn-info" CausesValidation="false" ClientIDMode="Static"><i class="icon-cancel"></i>Cancelar</asp:LinkButton>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>

            <asp:AsyncPostBackTrigger ControlID="btnguardar" />
            <asp:AsyncPostBackTrigger ControlID="btncancelar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
