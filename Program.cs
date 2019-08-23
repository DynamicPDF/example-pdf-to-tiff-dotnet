using ceTe.DynamicPDF.Rasterizer;
using System;
using System.Text.RegularExpressions;

namespace example_pdf_to_tiff_dotnet
{
    // This example shows how to convert a PDF document to TIFF.
    // It references the ceTe.DynamicPDF.Rasterizer.NET NuGet package.
    class Program
    {
        static void Main(string[] args)
        {
            // Create each page as one TIFF image
            IndividualTiffPage();

            // Creates a multipage TIFF with all the PDF pages
            MultiPageTiffFile();
        }

        // Convert a PDF document to 4 TIFF files (one for each page).
        // Use the ceTe.DynamicPDF.Rasterizer namespace for the PdfRasterizer class.
        private static void IndividualTiffPage()
        {
            // Create a PdfRasterizer object using the source PDF to be converted to TIFF image
            PdfRasterizer rasterizer = new PdfRasterizer(GetResourcePath("doc-a.pdf"));

            // Call the Draw method with output image name, image format and the DPI
            rasterizer.Draw("EachPage.tiff", ImageFormat.TiffWithLzw, ImageSize.Dpi150);
        }

        // Convert a PDF document to a multipage TIFF file.
        // Use the ceTe.DynamicPDF.Rasterizer namespace for the PdfRasterizer class.
        private static void MultiPageTiffFile()
        {
            // Create a PdfRasterizer object using the source PDF to be converted to multipage TIFF image
            PdfRasterizer rasterizer = new PdfRasterizer(GetResourcePath("doc-a.pdf"));

            // Call the DrawToMultiPageTiff method with output image name, image format and the DPI
            rasterizer.DrawToMultiPageTiff("MultiPage.tiff", ImageFormat.TiffWithCcitGroup4, ImageSize.Dpi150);
        }

        // This is a helper function to get the full path to a file in the Resources folder.
        public static string GetResourcePath(string inputFileName)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, "Resources", inputFileName);
        }
    }
}
