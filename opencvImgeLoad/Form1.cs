using System;
using System.Windows.Forms;
using OpenCvSharp;

namespace opencvImgeLoad
{
    public partial class Form1 : Form
    {
        IplImage src;

        public Form1()
        {
            InitializeComponent();
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            src = new IplImage("../../../italia.jpg");            
            //
            OpenCV_CLASS Convert = new OpenCV_CLASS();
            pictureBoxIpl1.ImageIpl = src;                          //원본
            pictureBoxIpl2.ImageIpl = Convert.GrayScale(src);       //그레이스케일
            pictureBoxIpl3.ImageIpl = Convert.InversionImage(src);  //반전
            pictureBoxIpl4.ImageIpl = Convert.Binary(src);          //이진화
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if (src != null) src.Dispose();
        }
    }
}
