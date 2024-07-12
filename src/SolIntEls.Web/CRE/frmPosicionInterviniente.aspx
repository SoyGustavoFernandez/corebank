<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPosicionInterviniente.aspx.cs" Inherits="SolIntEls.Web.CRE.frmPosicionInterviniente" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="GEN.ControlesBaseWeb" Namespace="GEN.ControlesBaseWeb" TagPrefix="SolIntELS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es-pe">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content="Core Bank Versión Web Responsivo"/>
    <meta name="author" content="Soluciones Integrales ELS"/>
    <link rel="icon" href="ico/solintels.ico"/>
    <title>..::Core Bank Web::..</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/navbar.css" rel="stylesheet"/>
    <link href="../css/cssControles.css" rel="stylesheet" />
    <script src="../js/ie-emulation-modes-warning.js"></script>
    <script src="../js/solintels_Scripts.js"></script>
</head>

<body>
    <form id="form1" runat="server" role="form" data-toggle="validator">
    <asp:scriptmanager id="scptManager" runat="server" enablepagemethods="true"/>
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
                    <asp:Label ID="lblTitulo" runat="server" Text="Label" CssClass="label label-primary">Posición de Interviniente</asp:Label></h3>
            </hgroup>


            <SolIntELS:pnlBase ID="pnlConsulta" runat="server">
                <div class="row">
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <label for="txtDocumento" class="col-md-4 control-label">Documento:</label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtDocumento" runat="server" class="form-control" placeholder="Nro. Documento" required MaxLength="11" onFocus="this.select()" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="form-group">
                            <div class="col-md-8">
                                <SolIntELS:btnConsultar ID="BtnConsultar1" runat="server" OnClick="BtnConsultar1_Click" />
                            </div>
                        </div>
                    </div>



                    <div class="col-sm-12">
                        <div class="text-center">
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="1500px" ShowFindControls="False" ShowRefreshButton="False"></rsweb:ReportViewer>
                        </div>
                    </div>
                </div>
            </SolIntELS:pnlBase>         
            
            <SolIntELS:pnlBase ID="pnlMensaje" runat="server" Visible="false">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="text-center">
                            <div class="alert alert-success" id="divMensaje" runat="server">
                                <strong>Mensaje:</strong><asp:Label ID="lblMensaje" runat="server" Text="Los datos se guardaron correctamente"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </SolIntELS:pnlBase>   
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
