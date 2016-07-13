'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class RegistrarServicioPorFecha

    '''<summary>
    '''Control ScriptManagerCrearServicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ScriptManagerCrearServicio As Global.AjaxControlToolkit.ToolkitScriptManager

    '''<summary>
    '''Control txtServicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtServicio As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control txtServidores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtServidores As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control txtFechaServicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaServicio As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control ValidadorFecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ValidadorFecha As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control ValidadorExpresionFecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ValidadorExpresionFecha As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Control txtTipoAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTipoAsistente As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control UpdateAgregarDetalleAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents UpdateAgregarDetalleAsistente As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control txtCantidadAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCantidadAsistente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control ValidadorAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ValidadorAsistente As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control ExpresionValidadorSoloNumerosAsistentes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ExpresionValidadorSoloNumerosAsistentes As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Control btnAgregarDetalleAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarDetalleAsistente As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control GrillaDetalleAsistente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GrillaDetalleAsistente As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control txtTipodevehiculo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTipodevehiculo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control txtCantidadVehiculo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCantidadVehiculo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control RequiredFieldValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RequiredFieldValidator1 As Global.System.Web.UI.WebControls.RequiredFieldValidator

    '''<summary>
    '''Control RegularExpressionValidator1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RegularExpressionValidator1 As Global.System.Web.UI.WebControls.RegularExpressionValidator

    '''<summary>
    '''Control btnAgregarvehiculos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarvehiculos As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control GrilladetalleVehiculo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents GrilladetalleVehiculo As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control txtComentarioServicio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtComentarioServicio As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnguardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnguardar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control btncancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btncancelar As Global.System.Web.UI.WebControls.LinkButton
End Class
