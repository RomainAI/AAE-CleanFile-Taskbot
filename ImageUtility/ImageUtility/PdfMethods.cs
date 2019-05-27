using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace ImageUtility
{
    public class PdfMethods
    {

        /// <summary>
        /// Convert a image file to a PDF file
        /// </summary>
        /// <param name="imageFilePath">Image file path</param>
        /// <param name="pdfFilePath">PDF file path</param>
        public static string convertImageToPDF(string imageFilePath, string pdfFilePath)
        {
            string returnResult = "OK";

            try
            {
                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imageFilePath);
                using (FileStream fs = new FileStream(pdfFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (Document doc = new Document(image))
                    {
                        using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                        {
                            doc.Open();
                            image.SetAbsolutePosition(0, 0);
                            writer.DirectContent.AddImage(image);
                            doc.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = ex.Message;
            }

            return returnResult;
            
        }

    }
}
