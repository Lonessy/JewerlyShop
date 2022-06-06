using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using JewerlyShop.ModelBase;
using Microsoft.Win32;
using System;

namespace JewerlyShop.AppData.Tools
{
    public class MyPdfWriter
    {
        public static void GetTicket(SalesView sale)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files | *.pdf";
            if (sfd.ShowDialog() == false) return;

            PdfWriter writer = new PdfWriter(sfd.FileName);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            pdf.SetDefaultPageSize(PageSize.A5);

            PdfFont font = PdfFontFactory.CreateFont("C:\\Windows\\Fonts\\Arial.ttf");

            iText.Layout.Element.Image img = new iText.Layout.Element.Image(ImageDataFactory.Create(@"..\..\Resources\logo.png"))
                .SetHeight(250)
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);
            document.Add(img);

            Paragraph header = new Paragraph("Магазин «JewerlyShop»")
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFontSize(20)
            .SetFont(font);

            document.Add(header);

            Paragraph check = new Paragraph("ЧЕК")
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFontSize(20)
            .SetFont(font);
            document.Add(check);

            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            Table table = new Table(2, false);
            table.SetMarginTop(10);
            table.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

            Cell header1 = new Cell(1, 1)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(font)
            .Add(new Paragraph(""));
            table.AddCell(header1);

            Cell header2 = new Cell(1, 2)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(""))
            .SetFont(font);
            table.AddCell(header2);

            Cell left1 = new Cell(1, 1)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Товар"))
            .SetFont(font);
            table.AddCell(left1);

            Cell right1 = new Cell(1, 2)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(sale.Product))
            .SetFont(font);
            table.AddCell(right1);

            Cell left2 = new Cell(2, 1)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Цена"))
            .SetFont(font);
            table.AddCell(left2);

            Cell right2 = new Cell(2, 2)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(sale.Price.ToString()))
            .SetFont(font);
            table.AddCell(right2);

            Cell left3 = new Cell(3, 1)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Количество"))
            .SetFont(font);
            table.AddCell(left3);

            Cell right3 = new Cell(3, 2)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph(sale.Count.ToString()))
            .SetFont(font);
            table.AddCell(right3);

            Cell left4 = new Cell(4, 1)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Итоговая цена"))
            .SetFont(font);
            table.AddCell(left4);

            Cell right4 = new Cell(4, 2)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph((sale.Price * sale.Count).ToString()))
            .SetFont(font);
            table.AddCell(right4);

            table.SetWidth(UnitValue.CreatePercentValue(100));
            document.Add(table);

            Paragraph date = new Paragraph($"Дата выдачи чека: {DateTime.Now.ToString("dd/MM/yyyy")}")
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
            .SetFontSize(12)
            .SetFont(font);
            document.Add(date);

            document.Close();

            System.Windows.MessageBox.Show("Чек сохранен в формате PDF", "Выполнено");
        }
    }
}
