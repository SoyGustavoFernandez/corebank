<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="frmPreSolicitud.aspx.cs" Inherits="SolIntEls.Web.CRE.frmPreSolicitud" %>

<%@ Register Assembly="GEN.ControlesBaseWeb" Namespace="GEN.ControlesBaseWeb" TagPrefix="SolIntELS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-pe">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Core Bank Versión Web Responsivo" />
    <meta name="author" content="Soluciones Integrales ELS" />
    <link rel="icon" href="ico/solintels.ico" />
    <title>..::Core Bank Web::..</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/navbar.css" rel="stylesheet" />
    <link href="../css/cssControles.css" rel="stylesheet" />
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/solintels_Scripts.js"></script>
</head>

<body>
    <form id="form1" runat="server" role="form" data-toggle="validator">

        <div class="container">

            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">
                            <span class="label label-default">
                                <asp:Label ID="lblUsuario" runat="server" Text="Label" Font-Size="Small" />
                            </span>
                        </a>
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" 
                                data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server" onserverclick="click_Logo">Core Bank</a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li><a href="../frmMenu.aspx">Menu</a></li>
                            <li><a href="../frmAcerca.aspx">Acerca</a></li>
                            <li><a href="../frmSoporte.aspx">Soporte</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active">
                                <a runat="server" id="lnkSalir" onserverclick="lnkSalir_ServerClick">
                                Salir<span class="sr-only">(current)</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <hgroup class="title">
                <h3>Registro de Pre Solicitud</h3>
            </hgroup>
            <asp:Panel ID="pnlMensaje" runat="server" Visible="false" >
                <div class="row">
                    <div class="col-sm-12 text-center">
                        <asp:Panel ID="pnlInnerMsje" runat="server" CssClass="alert alert-success">
                            <strong>Mensaje:</strong>
                            <asp:Label ID="lblMensaje" runat="server" Text="Los datos se guardaron correctamente" />
                        </asp:Panel>
                        <div>
                            <SolIntELS:btnNuevo ID="BtnNuevo1" runat="server" OnClick="BtnNuevo1_Click" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <SolIntELS:pnlBase ID="pnlConsulta" runat="server">
                <div class="panel-heading">
                    <h3 class="panel-title">Datos busqueda</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-4 col-xs-12 margin-row">
                            <div class="form-group">
                                <label class="control-label">Tipo documento:</label>
                                <asp:RadioButtonList ID="rblTipoDocumento" runat="server"
                                    RepeatLayout="Flow"
                                    RepeatDirection="Horizontal"
                                    CssClass="radio"
                                    OnSelectedIndexChanged="rblTipoDocumento_SelectedIndexChanged"
                                    AutoPostBack="true">
                                    <asp:ListItem Text="DNI  " Selected="True" Value="1" />
                                    <asp:ListItem Value="4" Text="RUC" />
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-sm-4 col-xs-12 margin-row">
                            <div class="form-group">
                                <label class="control-label">Nro. Documento:</label>
                                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"
                                    data-error="Ingrese el número de document46617104o de identificación"
                                    onkeypress="return AcceptNum(event);"
                                    MaxLength="8" onFocus="this.select()" placeholder="Documento" required="">
                                </asp:TextBox>
                                <div class="help-block with-errors"></div>
                            </div>
                        </div>
                    </div>
                    <div class="row text-center">
                        <div class="col-sm-12 margin-row">
                            <SolIntELS:btnConsultar ID="BtnConsultar1" runat="server" OnClick="BtnConsultar1_Click" />
                        </div>
                    </div>
                </div>
            </SolIntELS:pnlBase>
            <asp:Panel ID="pnlPresolicitud" runat="server" Visible="false" style="margin-bottom: 0px">
                <SolIntELS:pnlBase ID="pnlDatPersonales" runat="server">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datos busqueda</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-12 margin-row" runat="server" id="divCalificacion" visible="false">
                                <label class="control-label">Calificación:</label>
                                <h4><span class="label label-primary">
                                    <asp:Label ID="lblCalificaInterna" runat="server" Text="Califica" />
                                </span></h4>
                            </div>
                        </div>
                        <asp:Panel ID="pnlPJ" runat="server">
                            <div class="row" visible="false">
                                <div class="col-sm-12 margin-row">
                                    <label class="control-label">Razón Social:</label>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="form-control"
                                        placeholder="Razón Social" required MaxLength="350" />
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlPN" runat="server">
                            <div class="row">
                                <div class="col-sm-6 col-lg-4 margin-row" runat="server" id="divApePaterno">
                                    <div class="form-group">
                                        <label class="control-label">Ap. Paterno:</label>
                                        <asp:TextBox ID="txtApePaterno" runat="server" CssClass="form-control"
                                            placeholder="Apellido Paterno" required MaxLength="50" />
                                    </div>
                                </div>
                                <div class="col-sm-6 col-lg-4 margin-row" runat="server" id="divApeMaterno">
                                    <label class="control-label">Ap. Materno:</label>
                                    <asp:TextBox ID="txtApeMaterno" runat="server" CssClass="form-control"
                                        placeholder="Apellido Materno" required MaxLength="50" />
                                </div>
                                <div class="col-sm-12 col-lg-4 margin-row" runat="server" id="divNombres">
                                    <label class="control-label">Nombres:</label>
                                    <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"
                                        placeholder="Nombres" required MaxLength="50" />
                                </div>
                            </div>
                        </asp:Panel>                        
                        <div class="row">
                            <div class="col-sm-6 margin-row">
                                <label class="control-label">Teléfono:</label>
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"
                                    placeholder="Teléfono" onkeypress="return AcceptNum(event);" />
                            </div>
                            <div class="col-sm-6 margin-row">
                                <label class="control-label">Celular:</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"
                                    placeholder="Celular" required MaxLength="10" onkeypress="return AcceptNum(event);" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 margin-row">
                                <label class="control-label">Departamento:</label>
                                <asp:DropDownList ID="cboDepartamento" runat="server" CssClass="form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="cboDepartamento_SelectedIndexChanged" />
                            </div>
                            <div class="col-sm-6 margin-row">
                                <div class="form-group">
                                    <label class="control-label">Provincia:</label>
                                    <asp:DropDownList ID="cboProvincia" runat="server" CssClass="form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="cboProvincia_SelectedIndexChanged" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6 margin-row">
                                <label class="control-label">Distrito:</label>
                                <asp:DropDownList ID="cboDistrito" runat="server" CssClass="form-control"
                                    AutoPostBack="true" OnSelectedIndexChanged="cboDistrito_SelectedIndexChanged" />
                            </div>
                            <div class="col-sm-6 margin-row">
                                <label class="control-label">Comunidad:</label>
                                <asp:DropDownList ID="cboComunidad" required runat="server"
                                    CssClass="form-control" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 margin-row">
                                <label class="control-label">Dirección:</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"
                                    placeholder="Dirección" required MaxLength="150" />
                            </div>
                        </div>
                    </div>
                </SolIntELS:pnlBase>                
                <SolIntELS:pnlBase ID="pnlDatPreSol" runat="server">
                    <div class="panel-heading">
                        <h3 class="panel-title">Datos de la pre solicitud</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-4 margin-row">
                                <label class="control-label">Monto:</label>
                                <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control"
                                    placeholder="0.00" required MaxLength="10" onkeyup="validateDecimal(this);" />
                            </div>
                            <div class="col-sm-4 margin-row">
                                <label class="control-label">Nro. de Cuotas:</label>
                                <asp:TextBox ID="txtNumcuotas" TextMode="Number" CssClass="form-control" runat="server"
                                    min="0" max="100" step="1" required MaxLength="3" onkeypress="return AcceptNum(event);" />
                            </div>
                            <div class="col-sm-4 margin-row">
                                <label class="control-label">Moneda:</label>
                                <asp:RadioButtonList ID="rblMoneda" runat="server"
                                    RepeatLayout="Flow"
                                    RepeatDirection="Horizontal"
                                    CssClass="radio">
                                    <asp:ListItem Text="Soles" Selected="True" Value="1" />
                                    <asp:ListItem Value="2" Text="Dólares" />
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4 col-xs-12 margin-row">
                                <label class="control-label">Periodo:</label>
                                <asp:RadioButtonList ID="rblPeriodo" runat="server"
                                    RepeatLayout="Flow"
                                    RepeatDirection="Horizontal"
                                    CssClass="radio">
                                    <asp:ListItem Text="Fecha Fija" Selected="True" Value="1" />
                                    <asp:ListItem Value="2" Text="Periodo fijo" /> 
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-sm-4 col-xs-12 margin-row">
                                <label class="control-label">Día/Periodo:</label>
                                <asp:TextBox ID="txtPeriodo" TextMode="Number" runat="server" min="0" max="100" step="1"
                                    required MaxLength="3" CssClass="form-control" onkeypress="return AcceptNum(event);" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 margin-row">
                                <label class="control-label">Comentarios:</label>
                                <asp:TextBox ID="txtComentarios" runat="server" CssClass="form-control txtMultiline"
                                    placeholder="Comentarios" required MaxLength="150" TextMode="MultiLine" />
                            </div>
                        </div>
                    </div>
                </SolIntELS:pnlBase>
                <asp:Panel ID="pnlReglas" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="text-center">
                                <div class="alert alert-warning" runat="server">
                                    <asp:Label ID="lblReglas" runat="server" />
                                </div>
                                <SolIntELS:btnAceptar ID="btnReglas" runat="server" OnClick="btnReglas_Click" />
                                <SolIntELS:btnCancelar ID="btnCancelar" runat="server" OnClick="btnCancelar_OnClick"/>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="row">
                    <div class="col-sm-12 margin-row">
                        <div class="text-center">
                            <SolIntELS:btnAceptar ID="BtnGrabar1" runat="server" OnClick="BtnGrabar1_Click" />
                            <SolIntELS:btnAtras ID="BtnAtras1" OnClick="BtnAtras1_Click"  OnClientClick="history.back()"  runat="server"/>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:HiddenField ID="hdfIdCli" runat="server" Value="0" />
            <asp:HiddenField ID="hdfIdPresolciitud" runat="server" Value="0" />
        </div>

        <footer>
            <div class="container">
                <div class="text-center">
                    <p>&copy; <%: DateTime.Now.Year %> - SolIntEls</p>
                </div>
            </div>
        </footer>

        <!-- Bootstrap core JavaScript
    ================================================== -->
        <!-- Se colo al final para que la página cargue mas rápido -->
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/ie10-viewport-bug-workaround.js"></script>


    </form>
</body>
</html>
