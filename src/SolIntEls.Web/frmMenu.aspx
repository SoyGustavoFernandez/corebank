<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMenu.aspx.cs" Inherits="SolIntEls.Web.frmMenu" %>

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
    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="css/navbar.css" rel="stylesheet"/>
    <link href="css/cssControles.css" rel="stylesheet" />
    <script src="js/ie-emulation-modes-warning.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
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
          <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
              <div class="panel panel-default" runat="server" id="menucre" visible="false">
                  <div class="panel-heading" role="tab" id="headingOne">
                      <h4 class="panel-title">
                         <span class="glyphicon glyphicon-usd" aria-hidden="true"></span> 
                          <a role="button"  id="titulocre" runat="server"  data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">CRÉDITOS
                            </a>
                      </h4>
                  </div>
                  <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                      <div class="panel-body">
                          <ul class="list-group" id="listacre" runat="server">
                              <%--<li class="list-group-item" runat="server" id="Menu2"><a href="CRE/frmPreSolicitud.aspx">- Pre solicitud</a></li>--%>
                              <%--<li class="list-group-item" runat="server" id="Menu3"><a href="CRE/frmPosicionInterviniente.aspx">- Posición Interviniente</a></li>--%>
                            </ul>
                      </div>
                  </div>
              </div>
              <div class="panel panel-default" runat="server" id="menuadm" visible="false">
                  <div class="panel-heading" role="tab" id="headingTwo">
                      <h4 class="panel-title">
                          <span class="glyphicon glyphicon-cog" aria-hidden="true"></span> 
                          <a class="collapsed" id="tituloadm" runat="server" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">ADMINISTRACIÓN
                            </a>
                      </h4>
                  </div>
                  <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                      <div class="panel-body">
                        <ul class="list-group" id="listaadm" runat="server">
                             <%--<li class="list-group-item" runat="server" id="Menu5"><a href="ADM/frmAprobacion.aspx">- Aprobaciones de solicitud</a></li>--%>
                            </ul>
                      </div>
                  </div>
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