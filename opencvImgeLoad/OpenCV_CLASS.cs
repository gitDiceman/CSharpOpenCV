using System;
using OpenCvSharp; //add//

namespace opencvImgeLoad
{
    class OpenCV_CLASS: IDisposable //자동으로 메모리 관리?
    {
        IplImage gray;
        IplImage inversion;
        IplImage bin;

        public IplImage GrayScale(IplImage src)
        {
            gray = new IplImage(src.Size, BitDepth.U8, 1);//
            Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
            return gray;
        }
        public IplImage InversionImage(IplImage src)
        {
            inversion = new IplImage(src.Size, BitDepth.U8, 3);//
            Cv.Not(src, inversion);
            return inversion;
        }
        public IplImage Binary(IplImage src)
        {
            //bin = new IplImage(src.Size, BitDepth.U8, 1);//
            bin = this.GrayScale(src);
            Cv.CvtColor(src, bin, ColorConversion.BgrToGray);
            Cv.Threshold(bin, bin, 150, 255, ThresholdType.Binary);

            return bin;
        }


        public void Dispose()
        {
            if (gray != null) Cv.ReleaseImage(gray);
            if (inversion != null) Cv.ReleaseImage(inversion);
            if (bin != null) Cv.ReleaseImage(bin);
        }
    }
}
