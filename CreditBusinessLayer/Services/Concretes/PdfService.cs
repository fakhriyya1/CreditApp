using CreditEntityLayer.Entities;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using CreditBusinessLayer.Services.Abstractions;
using Syncfusion.Drawing;
using System.IO;

public class PdfService : IPdfService
{
    public MemoryStream GenerateLoanPdf(LoanCalculationResult loanResult)
    {
        PdfDocument document = new PdfDocument();
        PdfPage page = document.Pages.Add();

        PdfGraphics graphics = page.Graphics;

        float pageWidth = page.Size.Width;
        float tableWidth = 5 * 80f; 
        float startX = (pageWidth - tableWidth) / 3;
        float startY = 50;
        float columnWidth = 80f;
        float rowHeight = 20f;

        graphics.DrawString("Amortization Schedule", new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold), PdfBrushes.Black, new PointF(startX, startY));

        graphics.DrawRectangle(PdfPens.Black, new RectangleF(startX, startY + rowHeight, tableWidth, rowHeight));
        graphics.DrawString("Month", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Black, new RectangleF(startX, startY + rowHeight, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
        graphics.DrawString("Payment", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Black, new RectangleF(startX + columnWidth, startY + rowHeight, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
        graphics.DrawString("Principal", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Black, new RectangleF(startX + 2 * columnWidth, startY + rowHeight, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
        graphics.DrawString("Interest", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Black, new RectangleF(startX + 3 * columnWidth, startY + rowHeight, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
        graphics.DrawString("Balance", new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold), PdfBrushes.Black, new RectangleF(startX + 4 * columnWidth, startY + rowHeight, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

        startY += 2 * rowHeight;

        foreach (var entry in loanResult.Schedule)
        {
            graphics.DrawRectangle(PdfPens.Black, new RectangleF(startX, startY, tableWidth, rowHeight));
            graphics.DrawString(entry.Month.ToString(), new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(startX, startY, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
            graphics.DrawString(entry.Payment.ToString("C"), new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(startX + columnWidth, startY, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
            graphics.DrawString(entry.Principal.ToString("C"), new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(startX + 2 * columnWidth, startY, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
            graphics.DrawString(entry.Interest.ToString("C"), new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(startX + 3 * columnWidth, startY, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));
            graphics.DrawString(entry.Balance.ToString("C"), new PdfStandardFont(PdfFontFamily.Helvetica, 10), PdfBrushes.Black, new RectangleF(startX + 4 * columnWidth, startY, columnWidth, rowHeight), new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle));

            startY += rowHeight;
        }

        MemoryStream stream = new MemoryStream();
        document.Save(stream);
        document.Close(true);

        stream.Position = 0;
        return stream;
    }
}
