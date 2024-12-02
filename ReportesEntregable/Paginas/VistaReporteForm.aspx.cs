using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using ReportesEntregable.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace ReportesEntregable.Paginas
{
    public partial class VistaReporteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new List<Persona>
                {
                    new Persona { ID = 125088975, Nombre = "Javier Diaz", Edad = 32 },
                    new Persona { ID = 236547891, Nombre = "Joshua Andrey", Edad = 30 },
                    new Persona { ID = 345678123, Nombre = "Johel Perez", Edad = 50 },
                    new Persona { ID = 456789234, Nombre = "Lucia Fernandez", Edad = 28 },
                    new Persona { ID = 567890345, Nombre = "Carlos López", Edad = 45 },
                    new Persona { ID = 678901456, Nombre = "Marta García", Edad = 36 },
                    new Persona { ID = 789012567, Nombre = "Antonio Martínez", Edad = 40 },
                    new Persona { ID = 890123678, Nombre = "María Rodríguez", Edad = 29 },
                    new Persona { ID = 901234789, Nombre = "Diego Sánchez", Edad = 38 },
                    new Persona { ID = 123456890, Nombre = "Sandra Torres", Edad = 34 }
                };

                gvData.DataSource = data;
                gvData.DataBind();
            }

        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            // Simulación de datos JSON
            var data = new List<Persona>
                {
                    new Persona { ID = 125088975, Nombre = "Javier Diaz", Edad = 32 },
                    new Persona { ID = 236547891, Nombre = "Joshua Andrey", Edad = 30 },
                    new Persona { ID = 345678123, Nombre = "Johel Perez", Edad = 50 },
                    new Persona { ID = 456789234, Nombre = "Lucia Fernandez", Edad = 28 },
                    new Persona { ID = 567890345, Nombre = "Carlos López", Edad = 45 },
                    new Persona { ID = 678901456, Nombre = "Marta García", Edad = 36 },
                    new Persona { ID = 789012567, Nombre = "Antonio Martínez", Edad = 40 },
                    new Persona { ID = 890123678, Nombre = "María Rodríguez", Edad = 29 },
                    new Persona { ID = 901234789, Nombre = "Diego Sánchez", Edad = 38 },
                    new Persona { ID = 123456890, Nombre = "Sandra Torres", Edad = 34 }
                };

            //lambda
            var listaOrdenada = data.OrderBy(a => a.ID).ToList();


            /// Creacion de donde se va a guardar el reporte
            string filePath = Server.MapPath("~/Reportes/Reporte.pdf");

            string directoryPath = @"C:\Users\Adriana Sequeira\source\repositorio\ReportesEntregable\ReportesEntregable\Reportes";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            //Crear el archivo pdf 
            using (var escribir = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(escribir))
                {
                    var documento = new Document(pdf);

                    var titleFont = iText.Kernel.Font.PdfFontFactory.CreateFont("Helvetica-Bold");
                    var titleColor = new DeviceRgb(26, 115, 232);  // Azul brillante #1a73e8
                    var textColorWhite = new DeviceRgb(255, 255, 255); // Blanco

                    // Título con fondo azul brillante y texto blanco
                    var title = new Paragraph("Reporte de Personas")
                        .SetFont(titleFont)
                        .SetFontSize(24)
                        .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                        .SetFontColor(textColorWhite)
                        .SetBackgroundColor(titleColor)
                        .SetMarginBottom(20);
                    documento.Add(title);


                    // Crear una tabla con 3 columnas (ID, Nombre, Edad)
                    float[] columnWidths = { 1, 4, 3 };  // Ancho de las columnas
                    iText.Layout.Element.Table table = new iText.Layout.Element.Table(columnWidths);

                    // Estilo de los encabezados
                    var headerFont = iText.Kernel.Font.PdfFontFactory.CreateFont("Helvetica-Bold");
                    var headerBackgroundColor = new DeviceRgb(0, 121, 107);  // Verde oscuro #00796b
                    var headerTextColor = textColorWhite;  // Blanco

                    // Agregar los encabezados a la tabla
                    table.AddHeaderCell(new Cell().Add(new Paragraph("ID")
                        .SetFont(headerFont)
                        .SetFontColor(headerTextColor))
                        .SetBackgroundColor(headerBackgroundColor));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre")
                        .SetFont(headerFont)
                        .SetFontColor(headerTextColor))
                        .SetBackgroundColor(headerBackgroundColor));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Edad")
                        .SetFont(headerFont)
                        .SetFontColor(headerTextColor))
                        .SetBackgroundColor(headerBackgroundColor));

                    // Estilo para las celdas de datos
                    var dataFont = iText.Kernel.Font.PdfFontFactory.CreateFont("Helvetica");
                    var dataTextColor = new DeviceRgb(51, 51, 51);  // Gris oscuro #333333
                    var cellBackgroundColor = new DeviceRgb(241, 241, 241); // Gris claro #f1f1f1

                    // Agregar los datos a la tabla
                    foreach (var persona in listaOrdenada)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(persona.ID.ToString())
                            .SetFont(dataFont)
                            .SetFontColor(dataTextColor))
                            .SetBackgroundColor(cellBackgroundColor));
                        table.AddCell(new Cell().Add(new Paragraph(persona.Nombre)
                            .SetFont(dataFont)
                            .SetFontColor(dataTextColor))
                            .SetBackgroundColor(cellBackgroundColor));
                        table.AddCell(new Cell().Add(new Paragraph(persona.Edad.ToString())
                            .SetFont(dataFont)
                            .SetFontColor(dataTextColor))
                            .SetBackgroundColor(cellBackgroundColor));
                    }

                    // Agregar la tabla al documento
                    documento.Add(table);
                }
            }

            // Descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }
    }
}