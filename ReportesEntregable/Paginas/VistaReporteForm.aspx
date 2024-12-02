<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaReporteForm.aspx.cs" Inherits="ReportesEntregable.Paginas.VistaReporteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte de Personas</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }
        h1 {
            color: #ffffff;
            background-color: #1a73e8;
            padding: 10px;
            text-align: center;
        }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th {
            background-color: #00796b;
            color: #ffffff;
            padding: 10px;
        }
        td {
            background-color: #f1f1f1;
            color: #333333;
            padding: 10px;
            text-align: center;
        }
        .button {
            padding: 10px 20px;
            background-color: #1a73e8;
            color: white;
            border: none;
            cursor: pointer;
            margin-top: 20px;
        }
        .button:hover {
            background-color: #0c56a1;
        }
    </style>

</head>
<body>
    <h1>Reporte de Personas</h1>
    <form id="form1" runat="server">
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Edad" HeaderText="Edad" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnGeneratePDF" runat="server" Text="Generar PDF" OnClick="btnGeneratePDF_Click" CssClass="button" />
    </form>
</body>
</html>
