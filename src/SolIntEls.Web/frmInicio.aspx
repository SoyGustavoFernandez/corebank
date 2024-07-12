<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="SolIntEls.Web.frmInicio" %>

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
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/navbar.css" rel="stylesheet" />
    <link href="css/cssControles.css" rel="stylesheet" />
    <script src="js/ie-emulation-modes-warning.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">

            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="frmInicio.aspx">
                            <img alt="Brand" src="ico/loguito.png" />
                        </a>
                        <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                            <span class="sr-only">Toggle navigation</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <a class="navbar-brand" runat="server" onserverclick="click_Logo">Core Bank</a>
                    </div>
                    <div id="navbar" class="navbar-collapse collapse">
                        <ul class="nav navbar-nav">
                            <li class="active"><a href="frmInicio.aspx">Inicio</a></li>
                            <li><a href="frmAcerca.aspx">Acerca</a></li>
                            <li><a href="frmSoporte.aspx">Soporte</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a runat="server" id="lnkSalir" onserverclick="lnkSalir_ServerClick">Salir<span class="sr-only">(current)</span></a></li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-8">
                        <div class="input-group">
                            <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-user" aria-hidden="true"></span></span>

                            <asp:TextBox ID="txtUsuario" runat="server" class="form-control" placeholder="Usuario">
                            
                            </asp:TextBox>
                        </div>
                        <br />

                        <div class="input-group">
                            <span class="input-group-addon" id="Span1"><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span></span>
                            <asp:TextBox ID="txtClave" TextMode="Password" runat="server" CssClass="form-control" placeholder="Clave"></asp:TextBox>
                        </div>
                        <br />

                        <div class="dropdown">
                            <p align="center">
                                <SolIntELS:cboBase ID="cboPerfiles" runat="server" Width="240px" Visible="false" />
                            </p>
                        </div>
                        <br />
                        <div class="dropdown">
                            <p align="center">
                                <SolIntELS:cboBase ID="cboAgencias" runat="server" Width="240px" Visible="false" />
                            </p>
                        </div>
                        <br />

                        <p align="center">
                            <SolIntELS:btnAceptar ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" />
                            <SolIntELS:btnAceptar ID="btnIngPerfil" runat="server" Visible="false" OnClick="btnIngPerfil_Click" />
                            <SolIntELS:btnCancelar ID="BtnCancelar1" runat="server" Visible="false" OnClick="BtnCancelar1_Click" />
                            <br />
                            <SolIntELS:lblBase ID="lblMensaje" class="label label-danger" ForeColor="red" runat="server" Visible="false">Mensajes</SolIntELS:lblBase>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <footer>
            <div class="container">
                <div class="text-center">
                    <p>&copy; <%: DateTime.Now.Year %>- SolIntEls</p>
                </div>
            </div>
        </footer>

        <!-- Bootstrap core JavaScript
    ================================================== -->
        <!-- Se colo al final para que la página cargue mas rápido -->
        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/ie10-viewport-bug-workaround.js"></script>

    </form>
</body>
</html>
