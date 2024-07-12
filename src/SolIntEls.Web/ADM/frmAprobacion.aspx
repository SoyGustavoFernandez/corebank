<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="frmAprobacion.aspx.cs" Inherits="SolIntEls.Web.ADM.frmAprobacion" %>

<%@ Register Assembly="GEN.ControlesBaseWeb" Namespace="GEN.ControlesBaseWeb" TagPrefix="SolIntELS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-pe">
<head id="Head1" runat="server">
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
</head>

<body>
    <form id="form1" runat="server" role="form" data-toggle="validator">
        <div class="container">
            <nav class="navbar navbar-default">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">
                            <span class="label label-default">
                                <asp:Label ID="lblUsuario" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                            </span>
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
                            <li><a href="../frmMenu.aspx">Menu</a></li>
                            <li><a href="../frmAcerca.aspx">Acerca</a></li>
                            <li><a href="../frmSoporte.aspx">Soporte</a></li>
                        </ul>
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a runat="server" id="lnkSalir" onserverclick="lnkSalir_ServerClick">Salir<span class="sr-only">(current)</span></a></li>
                        </ul>
                    </div>
                </div>
            </nav>

            <hgroup class="title">
                <h3>
                    <asp:Label ID="lblTitulo" runat="server" Text="Label" CssClass="label label-primary">Aprobaciones</asp:Label>
                </h3>
            </hgroup>

            <SolIntELS:pnlBase ID="pnlSolicitudes" runat="server" Visible="true">
                <div class="row">
                    <div class="col-sm-12 col-lg-12" runat="server" id="div1">
                        <div class="form-group">
                            <div class="alert alert-success" id="divMensaje" runat="server" visible="false">
                                <strong>Información:</strong>
                                <asp:Label ID="lblMensaje" runat="server" Text="Los datos se guardaron correctamente"/>
                            </div>
                            
                            <SolIntELS:dtgBase ID="GRID" runat="server" CssClass="table"
                                AllowPaging="True" AutoGenerateColumns="false" 
                                OnRowCommand="GRID_RowCommand">
                                <Columns>
                                    <%--Region Campos no visibles--%>
                                    <asp:BoundField DataField="cNomCliente" Visible="false" />
                                    <asp:BoundField DataField="cProducto" Visible="false" />
                                    <asp:BoundField DataField="idDocument" Visible="false" />
                                    <asp:BoundField DataField="cMoneda" Visible="false" />
                                    <asp:BoundField DataField="cMotivo" Visible="false" />
                                    <asp:BoundField DataField="dFecSolici" Visible="false" />
                                    <asp:BoundField DataField="cSustento" Visible="false" />
                                    <%--EndRegion Campos no visibles--%>
                                    <asp:BoundField DataField="idSolAproba" HeaderText="Nro.Sol." Visible="true" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="cTipoOperacion" HeaderText="Operación" Visible="true" />
                                    <asp:BoundField DataField="cSimbolo" HeaderText="M" Visible="true" />
                                    <asp:BoundField DataField="nValAproba" HeaderText="Valor" ItemStyle-HorizontalAlign="Right" Visible="true" DataFormatString="{0:0.00}" />
                                    <asp:TemplateField HeaderText="Det.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("idSolAproba") %>'
                                                CommandName="ViewDetail">Ver Detalle</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </SolIntELS:dtgBase>
                        </div>
                    </div>
                </div>
                <br />
                <div class="col-sm-12">
                    <div class="text-center">
                        <SolIntELS:btnAtras ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" /><br />
                    </div>
                </div>
            </SolIntELS:pnlBase>

            <SolIntELS:pnlBase ID="pnlDetalle" runat="server" Visible="false">
                <div class="row">
                    <div class="col-sm-6 col-lg-4" runat="server" id="divCalificacion">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Nro.Solicitud:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtNumSolicitud" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4" runat="server" id="divRazonSocial">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Cliente:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Producto:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Operación:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtOperacion" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Nro.Documento:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtNumDocumento" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Moneda:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMoneda" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Valor:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Motivo:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtMotivo" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Fecha:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtFecSolicita" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Sustento:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtSustento" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label">Opinión:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtOpinion" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="pnlRechazoCred" runat="server" Visible="False">
                        <div class="col-sm-6 col-lg-4">
                            <div class="form-group">
                                <label class="col-md-4 control-label">Motivo de rechazo:</label>
                                <div class="col-md-12">
                                    <SolIntELS:cboBase ID="cboMotivoDenegacion" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <div class="text-center">
                            <SolIntELS:btnAceptar ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" />
                            <SolIntELS:btnRechazar ID="BtnRechazar" runat="server" OnClick="BtnRechazar_Click" />
                            <SolIntELS:btnCancelar ID="btnCancelarApro" runat="server" OnClick="btnCancelarApro_Click" />
                            <SolIntELS:btnAtras ID="btnAtras" value="Regresar" runat="server" OnClick="btnAtras_Click" />
                        </div>
                    </div>
                </div>
            </SolIntELS:pnlBase>
        </div>
        <div>
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
        <!-- Se coloca al final para que la página cargue mas rápido -->
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/ie10-viewport-bug-workaround.js"></script>
    </form>
</body>
</html>
