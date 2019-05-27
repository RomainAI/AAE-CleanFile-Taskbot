using AForge;
using AForge.Imaging.Filters;
using System;
using System.Drawing;

namespace ImageUtility
{
    public class ImageMethods
    {

        private static Bitmap applyFilterMedian(Bitmap img)
        {
            Median filter = new Median();
            return filter.Apply(img);
        }

        private static Bitmap applyFilterAdaptiveSmoothing(Bitmap img)
        {
            AdaptiveSmoothing filter = new AdaptiveSmoothing();
            return filter.Apply(img);
        }

        private static Bitmap applyFilterGrayscale(System.Drawing.Bitmap img)
        {
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            return filter.Apply(img);
        }

        private static Bitmap applyFilterHslLinear(Bitmap img)
        {
            HSLLinear filter = new HSLLinear();
            filter.InLuminance = new Range(0, 0.85f);
            filter.OutSaturation = new Range(0.25f, 1);
            return filter.Apply(img);
        }

        private static Bitmap applyFilterBradleyLocalThresholding(Bitmap image)
        {
            BradleyLocalThresholding filter = new BradleyLocalThresholding();
            return filter.Apply(image);
        }

        /// <summary>
        /// Apply some filters to an image to increase OCR extraction result 
        /// </summary>
        /// <param name="applyHslLinear">1=yes, 0=no</param>
        /// <param name="applyGrayScale">1=yes, 0=no</param>
        /// <param name="applyMedian">1=yes, 0=no</param>
        /// <param name="applyAdaptiveSmoothing">1=yes, 0=no</param>
        /// <param name="imageSourceFile">Image source file path</param>
        /// <param name="imageResultFile">Image result file path</param>
        /// <returns>OK or execption message</returns>
        public static string applyFilterToImage(string applyHslLinear, string applyGrayScale, string applyMedian, string applyAdaptiveSmoothing, string imageSourceFile, string imageResultFile)
        {
            string returnResult = "OK";

            try
            {
                System.Drawing.Bitmap img = new System.Drawing.Bitmap(imageSourceFile);

                if (applyHslLinear == "1")
                    img = applyFilterHslLinear(img);

                if (applyGrayScale == "1")
                    img = applyFilterGrayscale(img);

                if (applyMedian=="1")
                    img = applyFilterMedian(img);

                if (applyAdaptiveSmoothing == "1")
                    img = applyFilterAdaptiveSmoothing(img);

                img.Save(imageResultFile);
            }
            catch (Exception ex)
            {
                returnResult = ex.Message;
            }

            return returnResult;
            
        }

    }

    
}
