using System.Globalization;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Path = System.IO.Path;

// Create PDF file:
var pdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Store", "example.pdf");

// Add background image:
var certPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Assets", "certificate.jpg");

var pdfDoc = new PdfDocument(new PdfWriter(pdfFilePath));
var pageSize = PageSize.A4;
var doc = new Document(pdfDoc, pageSize);

var canvas = new PdfCanvas(pdfDoc.AddNewPage());
canvas.AddImageFittedIntoRectangle(ImageDataFactory.Create(certPath), pageSize, false);

// Add header section:
var compName = "WERONICA.LIFE";
var text1 = new Paragraph(new Text(compName).SetBold().SetFontSize(20))
	.SetTextAlignment(TextAlignment.CENTER)
	.SetRelativePosition(0, 200, 0, 0);

var fontPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Fonts", "arial.ttf");
var font = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);

// Add middle section:
var name = "Chugaev Artem Victorovich";
var date1 = new DateOnly(2023, 09, 28);
var date2 = new DateOnly(2024, 09, 28);
var date3 = new DateOnly(2023, 02, 16);

var middleTextFirstRow = $"Настоящим сертификатом подтверждается, что владельцем домена ";
var middleTextFirstRowParam1 = $"{compName}\n";
var middleTextSecondRow = "является ";
var middleTextSecondRowParam1 = $"{name}\n\n\n";
var middleTextThirdRow = $"Дата первичной регистрации домена {date1.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}\n";
var middleTextFourthRow = $"Дата окончания срока регистрации домена {date2.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}\n\n";
var middleTextFifthRow = $"Дата выдачи сертификата {date3.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}";

var text2 = new Paragraph()
	.Add(middleTextFirstRow)
	.Add(new Text(middleTextFirstRowParam1).SetBold().SetFontSize(8))
	.Add(middleTextSecondRow)
	.Add(new Text(middleTextSecondRowParam1).SetBold())
	.Add(middleTextThirdRow)
	.Add(middleTextFourthRow)
	.Add(new Text(middleTextFifthRow).SetBold())
	.SetFont(font)
	.SetFontSize(12)
	.SetRelativePosition(0, 300, 0, 0);


// Set stamp section:
var stampPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Assets", "stamp.jpg");
var stamp = new iText.Layout.Element.Image(ImageDataFactory.Create(stampPath))
	.SetHeight(120)
	.SetFixedPosition(100, 50);

doc.Add(text1);
doc.Add(text2);
doc.Add(stamp);

doc.Close();
