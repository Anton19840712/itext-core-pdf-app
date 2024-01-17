using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Path = System.IO.Path;

// Создание файла PDF
var pdfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Store", "example.pdf");
var pdfDoc = new PdfDocument(new PdfWriter(pdfFilePath));
var doc = new Document(pdfDoc);

// Добавление изображения сертификата
var certPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Assets", "certificate.jpg");
var cert = new Image(ImageDataFactory.Create(certPath))

	//.SetMaxHeight(PageSize.A4.GetHeight()-1)
	//.SetMaxWidth(PageSize.A4.GetWidth()-1)
	;

// Добавление текста
var text = "WERONICA.LIFE";
var paragraph = new Paragraph(text)
	.SetTextAlignment(TextAlignment.CENTER)
	.SetRelativePosition(0,0,0, 550)
	.SetFontSize(20);

//var name = "Chugaev Artem Victorovich";
//var date1 = new DateOnly(2023, 09, 28);
//var date2 = new DateOnly(2024, 09, 28);
//var date3 = new DateOnly(2023, 02, 16);

var text2 = "Настоящим сертификатом подтверждается";
//$"что владельцем домена {text}\n является {name}\n\n" +
//$"Дата первичной регистрации домена {date1.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}\n" +
//$"Дата окончания срока регистрации домена {date2.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}\n" +
//$"Дата выдачи сертификата {date3.ToString("dd MMMM yyyy года", new CultureInfo("ru-RU"))}";

var paragraph2 = new Paragraph("Hello");
//	.SetTextAlignment(TextAlignment.CENTER)
//	//.SetPageNumber(1)
//	.SetRelativePosition(0, 0, 0, 350)
//	.SetFontSize(20);


// Добавление изображения штампа
var stampPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Assets", "stamp.jpg");
var stamp = new Image(ImageDataFactory.Create(stampPath))
	.SetHeight(120)
	.SetFixedPosition(1, 120, 100);

// Помещение изображения и текста на страницу
doc.Add(cert);
doc.Add(paragraph);
doc.Add(paragraph2);
doc.Add(stamp);

// Завершение документа и сохранение PDF-файла
doc.Close();