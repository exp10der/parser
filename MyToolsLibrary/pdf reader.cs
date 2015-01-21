using System;
using System.Net;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Pars.MyToolsLibrary
{
    class pdf_reоader
    {
        public static string Pdf(string addres)
        {
            try
            {
                string strText = string.Empty;
                var filePath = (addres);


                var reader = new PdfReader(filePath);

                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);

                    s =
                        Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8,
                            Encoding.Default.GetBytes(s)));
                    strText = strText + s;

                }
                return strText;
            }
            catch (WebException)
            {
                return "-1";
            }
        }
    }
}
