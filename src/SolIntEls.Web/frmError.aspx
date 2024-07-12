<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmError.aspx.cs" Inherits="SolIntEls.Web.frmError" %>

<%@ Register Assembly="GEN.ControlesBaseWeb" Namespace="GEN.ControlesBaseWeb" TagPrefix="SolIntELS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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


            <div class="alert alert-danger" id="divMensaje" runat="server">
                                <strong>Mensaje:</strong><asp:Label ID="lblError" runat="server" Text="error"></asp:Label>
                            </div>

        <div class="text-center">     
                    <p align="center">
                    <SolIntELS:btnAtras ID="BtnAtras1" runat="server" OnClick="BotonAtras1_Click"/></p>
                </div>
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
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/ie10-viewport-bug-workaround.js"></script>

   
    </form>
</body>
</html>
