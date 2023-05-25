using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ProyectoPuntoVenta
{
    public class Utility
    {
        public static Document CreatePDF(string ruta)
        {
            PdfWriter writer = new PdfWriter(ruta);

            // Initialize PDF document
            PdfDocument pdf = new PdfDocument(writer);

            // Initialize document
            Document document = new Document(pdf, PageSize.LETTER);

            document.SetMargins(60, 20, 55, 20);

            return document;
        }

        public static Document EncabezadoPDF(Document document, string sistema, string nombrereporte)
        {
            PdfFont fontEncabezado = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            PdfFont fontNormal = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            Paragraph titulo = new Paragraph(sistema).SetFont(fontEncabezado);
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);
            document.Add(titulo);
            titulo = new Paragraph(nombrereporte).SetFont(fontEncabezado);
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);
            document.Add(titulo);

            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            string hora = DateTime.Now.ToString("hh:mm:ss");
            Paragraph fechayhora = new Paragraph("FECHA: " + fecha + "\nHORA: " + hora);
            fechayhora.SetTextAlignment(TextAlignment.RIGHT);
            fechayhora.SetFontSize(10);

            document.Add(fechayhora);
            return document;
        }

        public static Table EncabezadoTabla(string[] columnas)
        {
            PdfFont fontEncabezado = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            Table table = new Table(columnas.Length);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas)
            {
                Paragraph p = new Paragraph(columna).SetFont(fontEncabezado);
                p.SetTextAlignment(TextAlignment.CENTER);
                Cell cell = new Cell().Add(p);
                cell.SetPaddings(5, 5, 5, 5);
                table.AddHeaderCell(cell);
            }

            table.SetAutoLayout();
            return table;
        }
    }
}
